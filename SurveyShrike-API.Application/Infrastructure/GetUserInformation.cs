using IdentityModel.Client;
using SurveyShrike_API.Application.Interfaces;
using IdentityModel;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

/// <summary>
/// @author Ankit
/// @date - 10/15/2019 2:44:53 AM 
/// </summary>
namespace SurveyShrike_API.Application.Infrastructure
{
    public class GetUserInformation : IGetUserInformation
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetUserInformation(IHttpContextAccessor httpContextAccessor) {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> GetUser()
        {
            var discoveryClient = new DiscoveryCache("http://localhost:5000");
            var doc = await discoveryClient.GetAsync();

            var client = new HttpClient();
            var token = this._httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty); ;
            var response = await client.GetUserInfoAsync(new UserInfoRequest
            {
                Address = doc.UserInfoEndpoint,
                Token = token
            });

            
            return response.Json != null ? response.Json.TryGetString("email") : null;

            
        }
    }
}
