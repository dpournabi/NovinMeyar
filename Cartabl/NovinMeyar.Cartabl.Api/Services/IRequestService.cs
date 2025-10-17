using NovinMeyar.Common;
using NovinMeyar.Common.MessageBrokers;
using System.Threading.Tasks;

namespace NovinMeyar.Cartabl.Api.Services
{
    public interface IRequestService
    {
        Task<ResponseModel> RegisterNewRequest(RequestRegistrationBroker model);
        Task<ResponseModel> UpdateRequest(UpdateRequestBroker model);
    }
}
