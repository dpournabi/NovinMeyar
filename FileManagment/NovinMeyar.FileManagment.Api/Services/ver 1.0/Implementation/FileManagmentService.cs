using System;
using Serilog;
using System.Threading.Tasks;
using NovinMeyar.FileManagment.DataLayer;
using NovinMeyar.Helpers;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NovinMeyar.Common;
using NovinMeyar.FileManagment.Domain;
using NovinMeyar.FileManagment.Domain.Entities;
using NovinMeyar.Common.Mimes;

namespace NovinMeyar.FileManagment.Api.Services.ver_1._0.Implementation
{
    public class FileManagmentService : IFileManagmentService
    {
        private readonly DataContext dataContext;
        public FileManagmentService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<ResponseModel> SaveStreamAsync(IFileStream stream, string userName)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.BadRequest };

            try
            {
                var newStream = new Stream();
                using (var ms = new System.IO.MemoryStream())
                {
                    stream.Photo.CopyTo(ms);
                    newStream.Content = ms.ToArray();
                    newStream.Tag = stream.Tag;
                    newStream.FileName = stream.Photo.FileName;
                    newStream.FileExtention = System.IO.Path.GetExtension(stream.Photo.FileName);
                    newStream.CreateDate = DateTime.Now;
                    newStream.UserCreatorName = userName;
                    newStream.IsValid = true;
                }

                var validation = await OnValidateAsync(newStream);

                if (!validation.Succeed)
                    return validation;

                await dataContext.Streams.AddAsync(newStream);
                await dataContext.SaveChangesAsync();

                response.Message = "عملیات آپلود فایل با موفقیت انجام شد";
                response.Succeed = true;
                response.HttpStatusCode = System.Net.HttpStatusCode.OK;
                response.ExteraInformation = newStream.Id;
            }
            catch (Exception ex)
            {
                response.Message = $"Raised error on --> {nameof(FileManagmentService)} --> {nameof(SaveStreamAsync)} at {DateTime.Now}";
                Log.Error(ex, response.Message);
            }

            return response;
        }
        public async Task<ResponseModel> GetStreamAsync(long id)
        {
            var response = new ResponseModel { Succeed = false };

            if (id <= 0 || await dataContext.Streams.AnyAsync(x=> x.Id == id))
            {
                response.Message = "شناسه مورد نظر یافت نشد";
                return response;
            }

            var objStream =  await dataContext.Streams.FindAsync(id);
            response.Message = DefaultMimeTypes.GetContentType(objStream.FileExtention);
            response.ExteraInformation = objStream.Content;
            response.Succeed = true;

            return response;
        }
        public async Task<ResponseModel> GetLargeStreamAsync(string cipherKey)
        {
            var response = new ResponseModel { Succeed = false };
            if (string.IsNullOrWhiteSpace(cipherKey))
            {
                response.Message = "ارسال کلید اجباری می باشد";
                return response;
            }

            var downloadHistory = await dataContext.DownloadLinkHistories.FirstOrDefaultAsync(x => x.EncryptedKey == cipherKey && x.ExpireDate > DateTime.Now);
            if (downloadHistory == null)
            {
                response.Message = "کلید ارسالی صحیح نمی باشد";
                return response;
            }

            var decryptedKey = Common.Security.Helper.DecryptString(cipherKey);
            if (downloadHistory.StreamId!= long.Parse(decryptedKey))
            {
                response.Message = "کلید ارسالی صحیح نمی باشد";
                return response;
            }

            downloadHistory.ExpireDate = DateTime.Now;
            await dataContext.SaveChangesAsync();

            var objStream = await dataContext.Streams.FindAsync(downloadHistory.StreamId);
            response.Message = DefaultMimeTypes.GetContentType(objStream.FileExtention);
            response.ExteraInformation = objStream.Content;
            response.Data = objStream.FileName;
            response.Succeed = true;

            return response;
        }
        public async Task<ResponseModel> GenerateDownloadKeyAsync(long id, string userName)
        {
            var response = new ResponseModel { Succeed = false };

            if (id <= 0 || !await dataContext.Streams.AnyAsync(x => x.Id == id))
            {
                response.Message = "شناسه مورد نظر یافت نشد";
                return response;
            }

            if (await dataContext.DownloadLinkHistories.AnyAsync(x => x.StreamId == id))
            {
                var expiredDownloadLinks = await dataContext.DownloadLinkHistories
                                                    .Where(x => x.StreamId == id)
                                                    .ToListAsync();
                dataContext.DownloadLinkHistories.RemoveRange(expiredDownloadLinks);
            }

            var cipherText = Common.Security.Helper.EncryptString(id.ToString());
            await dataContext.DownloadLinkHistories.AddAsync(new DownloadLinkHistory
            {
                StreamId = id,
                EncryptedKey = cipherText,
                ExpireDate = DateTime.Now.AddMinutes(5),
                UserCreatorName = userName,
                CreateDate = DateTime.Now
            });

            await dataContext.SaveChangesAsync();

            response.ExteraInformation = cipherText;
            response.Succeed = true;
            return response;
        }
        public async Task<ResponseModel> DeleteStreamAsync(long streamId, string userName, string roleName)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.BadRequest };

            try
            {
                if (streamId <= 0)
                    return response;

                var straem = await dataContext.Streams.FirstOrDefaultAsync(x => x.Id == streamId);
                if(roleName==AssessorsManager.Client)
                {
                    if(straem.UserCreatorName!=userName)
                    {
                        response.HttpStatusCode = System.Net.HttpStatusCode.Unauthorized;
                        response.Message = "شما مجاز به انجام این عملیات نیستید";
                        return response;
                    }
                }

                dataContext.Streams.Remove(straem);
                await dataContext.SaveChangesAsync();

                response.Message = "عملیات حذف فایل با موفقیت انجام شد";
                response.Succeed = true;
                response.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.Message = $"Raised error on --> {nameof(FileManagmentService)} --> {nameof(SaveStreamAsync)} at {DateTime.Now}";
                Log.Error(ex, response.Message);
            }

            return response;
        }

        #region Private Methods

        private async Task<ResponseModel> OnValidateAsync(Stream stream)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.OK };

            if (stream is null)
                return await Task.FromResult(response);

            if (string.IsNullOrWhiteSpace(stream.FileName))
            {
                response.Message = "ورود نام فایل الزامیست";
                return await Task.FromResult(response);
            }

            if (string.IsNullOrWhiteSpace(stream.FileExtention))
            {
                response.Message = "ورود فرمت فایل الزامیست";
                return await Task.FromResult(response);
            }

            if (string.IsNullOrWhiteSpace(stream.Tag))
            {
                response.Message = "ورود تگ فایل الزامیست";
                return await Task.FromResult(response);
            }

            if (stream.Content is null || stream.Content.Length <= 0)
            {
                response.Message = "محتوای فایل الزامیست";
                return await Task.FromResult(response);
            }

            response.Succeed = true;
            return await Task.FromResult(response);
        }
        #endregion
    }
}
