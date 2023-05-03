using ElectionsPrerequisites.Models;
using ElectionsPrerequisites.Models.Dto;
using ElectionsPrerequisites.Services.IServices;
using ElectionsPrerequisites_Utility;

namespace ElectionsPrerequisites.Services
{
    public class ElectionService : BaseService, IElectionService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string electionUrl;
        public ElectionService(IHttpClientFactory clientFactory,IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            electionUrl = configuration.GetValue<string>("ServiceUrls:ElectionAPI");
        }

        public Task<T> CreateAsync<T>(ElectionCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = electionUrl + "/api/ElectionAPI"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = electionUrl + "/api/ElectionAPI/" + id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = electionUrl + "/api/ElectionAPI"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = electionUrl + "/api/ElectionAPI/" + id
            }) ;
        }

        public Task<T> UpdateAsync<T>(ElectionUpdateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = electionUrl + "/api/ElectionAPI/" +dto.Id
            });
        }
    }
}
