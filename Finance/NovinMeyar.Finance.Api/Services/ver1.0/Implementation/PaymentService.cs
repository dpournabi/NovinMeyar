using System;
using System.Text;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using NovinMeyar.Finance.Domain.Response;
using NovinMeyar.Finance.Domain.DTO;
using NovinMeyar.Common;
using Serilog;
using NovinMeyar.Finance.Domain.Entities;
using NovinMeyar.Finance.DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Serialization;

namespace NovinMeyar.Finance.Api.Services.ver_1._0.Implementation
{
    public class PaymentService : IPaymentService
    {
        private readonly DataContext dataContext;

        public PaymentService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<ResponseModel> SavePaymentInformation(PaymentHistory payment)
        {
            var response = new ResponseModel { Succeed = false };

            try
            {
                Log.Write(Serilog.Events.LogEventLevel.Information, "Starting save payment information....");
                Log.Write(Serilog.Events.LogEventLevel.Information, "Start serialize payment model....");
                Log.Write(Serilog.Events.LogEventLevel.Information, JsonSerializer.Serialize(payment));

                var paymentInfo = await dataContext.PaymentHistories.FirstOrDefaultAsync(x => x.InvoiceNumber == payment.InvoiceNumber);
                if (paymentInfo != null)
                {
                    paymentInfo.IsSuccess = payment.IsSuccess;
                    paymentInfo.ReferenceNumber = payment.ReferenceNumber;
                    paymentInfo.TransactionReferenceID = payment.TransactionReferenceID?.Trim();
                    paymentInfo.TraceNumber = payment.TraceNumber;
                    paymentInfo.TransactionDate = payment.TransactionDate?.Trim();
                    paymentInfo.Message = payment.Message;

                    Log.Write(Serilog.Events.LogEventLevel.Information, "Update payment....");
                }
                else
                {
                    payment.CreateDate = DateTime.Now;
                    await dataContext.PaymentHistories.AddAsync(payment);
                    Log.Write(Serilog.Events.LogEventLevel.Information, "Added payment....");
                }

                await dataContext.SaveChangesAsync();

                response.Succeed = true;
                response.Message = "عملیات ثبت با موفقیت انجام شد";
            }
            catch (Exception ex)
            {
                Log.Write(Serilog.Events.LogEventLevel.Error, $"{DateTime.Now} - {nameof(PaymentService)} --> {nameof(SavePaymentInformation)} --> Error deatail: {(ex.InnerException != null ? ex.InnerException.Message : ex.Message)}");
                response.Message = $"در ثبت اطلاعات مشکلی به وجود آمده است. همکاران بخش فناوری در اسرع وقت نسبت به رفع مشکل اقدام خواهند نمود. ErrorDetails: {(ex.InnerException != null ? ex.InnerException.Message : ex.Message)}";
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }
        public async Task<ResponseModel> GetTokenAsync(PaymentRequestModel model)
        {
            var response = new ResponseModel { Succeed = false };

            if (model.Amount <= 0)
            {
                response.Message = "ارسال مبلغ الزامی می باشد";
                Log.Write(Serilog.Events.LogEventLevel.Error, $"Amount value can not be null");
                return await Task.FromResult(response);
            }

            var decryptedHiddenAmount = decimal.Parse(Common.Security.Helper.DecryptString(model.DataFlag));
            if (model.Amount != decryptedHiddenAmount)
            {
                response.Message = "مبلغ ارسالی با مبلغ کل محاسبه شده یکسان نمی باشند";
                Log.Write(Serilog.Events.LogEventLevel.Error, "Amount value was wrong!");
                Log.Write(Serilog.Events.LogEventLevel.Error, $"Amount value was {model.Amount}");
                Log.Write(Serilog.Events.LogEventLevel.Error, $"Original amount value was {decryptedHiddenAmount}");
                return await Task.FromResult(response);
            }

            Log.Write(Serilog.Events.LogEventLevel.Information, "Starting GetTokenAsync....");
            Log.Write(Serilog.Events.LogEventLevel.Information, "Start serialize input model....");
            Log.Write(Serilog.Events.LogEventLevel.Information, "model--> " + JsonSerializer.Serialize(model));

            var savePaymentInfo = await SavePaymentInformation(new PaymentHistory
            {
                Action = model.Action,
                Amount = Convert.ToDecimal(model.Amount),
                InvoiceDate = model.InvoiceDate,
                InvoiceNumber = model.InvoiceNumber,
                IsSuccess = false,
                MerchantCode = model.MerchantCode,
                TerminalCode = model.TerminalCode,
                Tag = model.Tag,
                SourceTable = model.SourceTable,
                SourceKey = model.SourceKey,
                CreatorUserName = model.CreatorUserName,
                CreateDate = model.CreateDate
            });

            Log.Write(Serilog.Events.LogEventLevel.Information, "savePaymentInfo--> " + JsonSerializer.Serialize(savePaymentInfo));
            if (!savePaymentInfo.Succeed)
                throw new Exception(savePaymentInfo.Message);

            var sendingData = JsonSerializer.Serialize(model);
            var content = new StringContent(sendingData, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("https://pep.shaparak.ir/Api/v1/Payment/GetToken"),
                Method = HttpMethod.Post,
                Content = content
            };
            request.Headers.Add("Sign", PaymentRequestModel.GetSign(sendingData));
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

                Log.Write(Serilog.Events.LogEventLevel.Information, "Starting SendingAsync....");
                HttpResponseMessage res = null;
                try
                {
                    res = await httpClient.SendAsync(request);
                }
                catch (Exception ex)
                {
                    Log.Write(Serilog.Events.LogEventLevel.Error, $"Raised error whenever post data to payment gateway! Error detail: {ex.Message.ToString()}");
                    return new ResponseModel
                    {
                        Succeed = false,
                        Message = $"عملیات پرداخت با خطا مواجه شد \n {ex.Message}"
                    };
                }
                var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(Encoding.UTF8.GetString(await res.Content.ReadAsByteArrayAsync()));

                Log.Write(Serilog.Events.LogEventLevel.Information, "Start serialize response....");
                Log.Write(Serilog.Events.LogEventLevel.Information, JsonSerializer.Serialize(tokenResponse));

                return new ResponseModel
                {
                    Succeed = tokenResponse.IsSuccess,
                    Message = tokenResponse.Message,
                    Data = tokenResponse.Token
                };
            }
        }

        public async Task<PaymentResponse> VerifyTransactionResultAsync(string tref, long invoiceNumber, string invoiceDate)
        {
            var verifyTransactionResult = new PaymentResponse { IsSuccess = false };
            var checkPay = await CheckTransactionResultAsync(tref);

            if (!checkPay.Result)
                return await Task.FromResult(new PaymentResponse { IsSuccess = false, Message = "هیچ پرداختی صورت نگرفته است مجددا پرداخت نمایید" });

            var paymentInfo = await GetPaymentHistoryAsync(invoiceNumber);
            if (paymentInfo == null)
                return await Task.FromResult(new PaymentResponse { IsSuccess = false, Message = "هیچ پرداختی صورت نگرفته است مجددا پرداخت نمایید" });
            var verifyRequest = new VerifyPeymentModel
            {
                Amount = paymentInfo.Amount,
                InvoiceDate = invoiceDate,
                InvoiceNumber = invoiceNumber,
                Timestamp = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
            };

            var sendingData = JsonSerializer.Serialize(verifyRequest);
            var content = new StringContent(sendingData, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("https://pep.shaparak.ir/api/v1/Payment/VerifyPayment"),
                Method = HttpMethod.Post,
                Content = content
            };
            var signData = PaymentRequestModel.GetSign(sendingData);
            request.Headers.Add("Sign", signData);
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Log.Write(Serilog.Events.LogEventLevel.Information, "Starting SendingAsync....");
                HttpResponseMessage res = null;
                try
                {
                    res = await httpClient.SendAsync(request);
                    if (res == null)
                        return new PaymentResponse { IsSuccess = false };
                }
                catch (Exception ex)
                {
                    Log.Write(Serilog.Events.LogEventLevel.Error, $"Raised error whenever post data to payment gateway! Error detail: {ex.Message.ToString()}");

                    return new PaymentResponse
                    {
                        IsSuccess = false,
                        Message = $"عملیات پرداخت با خطا مواجه شد \n {ex.Message}"
                    };
                }
                Log.Write(Serilog.Events.LogEventLevel.Information, "Start get main response....");
                var mainResponse = Encoding.UTF8.GetString(await res.Content.ReadAsByteArrayAsync());

                Log.Write(Serilog.Events.LogEventLevel.Information, $"Main response --> {mainResponse}");

                verifyTransactionResult = JsonSerializer.Deserialize<PaymentResponse>(mainResponse);

                Log.Write(Serilog.Events.LogEventLevel.Information, "Start serialize response....");
                Log.Write(Serilog.Events.LogEventLevel.Information, JsonSerializer.Serialize(verifyTransactionResult));
                if (verifyTransactionResult.IsSuccess)
                {
                    try
                    {
                        paymentInfo.IsSuccess = verifyTransactionResult.IsSuccess;
                        paymentInfo.HashedCardNumber = verifyTransactionResult.HashedCardNumber;
                        paymentInfo.MaskedCardNumber = verifyTransactionResult.MaskedCardNumber;
                        paymentInfo.ShaparakRefNumber = verifyTransactionResult.ShaparakRefNumber;
                        paymentInfo.Message = verifyTransactionResult.Message;
                    }
                    catch (Exception ex)
                    {
                        //DoRefund
                        paymentInfo.IsSuccess = false;
                        var currentDateTime = DateTime.Now;
                        Log.Write(Serilog.Events.LogEventLevel.Error, $"Getting error when try to save payment info for {JsonSerializer.Serialize(verifyTransactionResult)} -- {currentDateTime} -- {ex.Message.ToString()}");
                        paymentInfo.Message += $@"در فرآیند ذخیره سازی اطلاعات تراکنش شما مشکلی پیش آمده است.
                                                        لطفا کد پیگیری تراکنش را جهت بررسی بیشتر در
                                                        اختیار ادمین سیستم قرار دهید جزییات خطا: {ex.Message} -- {currentDateTime} \n";
                    }
                    finally
                    {
                        await dataContext.SaveChangesAsync();
                    }
                }
            }

            verifyTransactionResult.SourceId = long.Parse(paymentInfo.SourceKey);
            verifyTransactionResult.PaymentDate = paymentInfo.CreateDate;
            verifyTransactionResult.PaymentId = paymentInfo.Id;

            return await Task.FromResult(verifyTransactionResult);
        }

        private async Task<CheckTransactionResponse> CheckTransactionResultAsync(string tref)
        {
            Log.Write(Serilog.Events.LogEventLevel.Information, "Starting CheckTransactionResultAsync....");
            Log.Write(Serilog.Events.LogEventLevel.Information, $"tref: --> {tref}");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://pep.shaparak.ir/CheckTransactionResult.aspx");
            string text = "invoiceUID=" + tref;
            byte[] textArray = Encoding.UTF8.GetBytes(text);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = textArray.Length;
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(RemoteCertificateValidation);

            request.GetRequestStream().Write(textArray, 0, textArray.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string result = reader.ReadToEnd();
            if (result == "")
                return new CheckTransactionResponse { Result = false };

            Log.Write(Serilog.Events.LogEventLevel.Information, $"CheckTransactionResult: --> {result}");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(result);
            var nodes = doc.SelectSingleNode("resultObj").ChildNodes;
            var finalResult = bool.Parse(nodes[0].InnerText);
            return await Task.FromResult(new CheckTransactionResponse { Result = bool.Parse(nodes[0].InnerText) });
        }
        private static bool RemoteCertificateValidation(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;
            return false;
        }
        ////        private DoRefund()
        ////        {
        //////            کد پذیرنده // ;115 = merchantCode
        //////کد ترمینال // ;12 = terminalCode
        //////مبلغ فاکتور // ;2000000 = amount
        //////شماره فاکتور // ;1949945 = invoiceNumber
        ////// invoiceDate = 1387 / 10 / 12 12:45:32; // فاکتور تاریخ
        //////            براي درخواست برگشت خرید :1004"; // 1004 = "action
        ////            timeStamp = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        ////            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        ////            rsa.FromXmlString(“< RSAKeyValue >< Modulus > oQRshGhLf2Fh...”);
        ////            string data = "#" + merchantCode + "#" + terminalCode + "#" +
        ////            invoiceNumber + "#" + invoiceDate + "#" + amount + "#" + action + "#" +
        ////            timeStamp + "#";
        ////            byte[] signMain = rsa.SignData(Encoding.UTF8.GetBytes(data), new
        ////             SHA1CryptoServiceProvider());
        ////            sign = Convert.ToBase64String(signMain);
        ////            HttpWebRequest request =
        ////            (HttpWebRequest)WebRequest.Create("https://pep.shaparak.ir/DoRefun
        ////            d.aspx");
        ////            string text = " InvoiceNumber =" + invoiceNumber + "& InvoiceDate=" +
        ////            invoiceDate + "&MerchantCode=" + merchantCode + "&TerminalCode=" +
        ////            terminalCode + "& Amount=" + amount + "& action=" + action + +"&
        ////            TimeStamp = " + timeStamp + " & Sign = " + sign;

        ////             byte[] textArray = Encoding.UTF8.GetBytes(text);
        ////            request.Method = "POST";
        ////            request.ContentType = "application/x-www-form-urlencoded";
        ////            request.ContentLength = textArray.Length;
        ////            request.GetRequestStream().Write(textArray, 0, textArray.Length);
        ////            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        ////            StreamReader reader = new StreamReader(response.GetResponseStream());
        ////            string result = reader.ReadToEnd();
        ////}
        //public async Task<ResponseModel> CheckTransactionResultAsync(VerifyRequestModel model)
        //{
        //    Log.Write(Serilog.Events.LogEventLevel.Information, "Starting CheckTransactionResultAsync....");
        //    Log.Write(Serilog.Events.LogEventLevel.Information, "Start serialize input model....");
        //    Log.Write(Serilog.Events.LogEventLevel.Information, JsonSerializer.Serialize(model));

        //    var sendingData = JsonSerializer.Serialize(model);
        //    var content = new StringContent(sendingData, Encoding.UTF8, "application/json");
        //    var request = new HttpRequestMessage
        //    {
        //        RequestUri = new Uri("https://pep.shaparak.ir/Api/v1/Payment/CheckTransactionResult"),
        //        Method = HttpMethod.Post,
        //        Content = content
        //    };
        //    using (var httpClient = new HttpClient())
        //    {
        //        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

        //        Log.Write(Serilog.Events.LogEventLevel.Information, "Starting SendingAsync....");

        //        var res = await httpClient.SendAsync(request);
        //        var checkTransactionResult = JsonSerializer.Deserialize<PaymentResponse>(Encoding.UTF8.GetString(await res.Content.ReadAsByteArrayAsync()));
        //        Log.Write(Serilog.Events.LogEventLevel.Information, "Start serialize checkTransactionResult....");
        //        Log.Write(Serilog.Events.LogEventLevel.Information, JsonSerializer.Serialize(checkTransactionResult));

        //        return await Task.FromResult(new ResponseModel { Succeed = checkTransactionResult.IsSuccess, Message = checkTransactionResult.Message, Data = checkTransactionResult });
        //    }
        //}
        //public async Task<ResponseModel> VerifyTransactionResultAsync(VerifyRequestModel model)
        //{
        //    var finalResult = new ResponseModel { Succeed = false };

        //    Log.Write(Serilog.Events.LogEventLevel.Information, "Starting CheckTransactionResultAsync....");
        //    Log.Write(Serilog.Events.LogEventLevel.Information, "Start serialize input model....");
        //    Log.Write(Serilog.Events.LogEventLevel.Information, JsonSerializer.Serialize(model));

        //    var sendingData = JsonSerializer.Serialize(model);
        //    var content = new StringContent(sendingData, Encoding.UTF8, "application/json");
        //    var request = new HttpRequestMessage
        //    {
        //        RequestUri = new Uri("https://pep.shaparak.ir/VerifyPayment.aspx"),
        //        Method = HttpMethod.Post,
        //        Content = content
        //    };
        //    using (var httpClient = new HttpClient())
        //    {
        //        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

        //        Log.Write(Serilog.Events.LogEventLevel.Information, "Starting SendingAsync....");

        //        var res = await httpClient.SendAsync(request);
        //        var response = JsonSerializer.Deserialize<PaymentResponse>(Encoding.UTF8.GetString(await res.Content.ReadAsByteArrayAsync()));
        //        Log.Write(Serilog.Events.LogEventLevel.Information, "Start serialize response....");
        //        Log.Write(Serilog.Events.LogEventLevel.Information, JsonSerializer.Serialize(response));

        //        var savePaymentInfo = await SavePaymentInformation(new PaymentHistory
        //        {
        //            IsSuccess = response.IsSuccess,
        //            TraceNumber = response.TraceNumber,
        //            TransactionDate = response.TransactionDate,
        //            TransactionReferenceID = response.TransactionReferenceID,
        //            ReferenceNumber = response.ReferenceNumber,
        //            Message = response.Message
        //        });

        //        finalResult.Succeed = response.IsSuccess;
        //        finalResult.Message = response.Message + " \n";
        //        finalResult.Data = response;

        //        if (!savePaymentInfo.Succeed)
        //        {
        //            var currentDateTime = DateTime.Now;
        //            Log.Write(Serilog.Events.LogEventLevel.Error, $"Getting error when try to save payment info for {JsonSerializer.Serialize(response)} -- {currentDateTime}");
        //            finalResult.Message += $@"در فرآیند ذخیره سازی اطلاعات تراکنش شما مشکلی پیش آمده است.
        //                                    لطفا کد پیگیری تراکنش را جهت بررسی بیشتر در
        //                                    اختیار ادمین سیستم قرار دهید جزییات خطا: {savePaymentInfo.Message} -- {currentDateTime} \n";
        //        }

        //        return await Task.FromResult(finalResult);
        //    }
        //}
        public async Task<PaymentHistory> GetPaymentHistoryAsync(long invoiceNumber) => await dataContext.PaymentHistories.FirstOrDefaultAsync(x => x.InvoiceNumber == invoiceNumber);
    }
}
