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
    /// <summary>
    /// Get user information service provide the injectable way to inject the user details found using userinfo endpoint of identity server.
    /// </summary>
    public class GetUserInformation : IGetUserInformation
    {
        /// <summary>
        /// IHttpContextAccessor provides the Request context for the current request.
        /// </summary>
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Constructor for GetUserInformation
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public GetUserInformation(IHttpContextAccessor httpContextAccessor) {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Get user makes a async calls to Identity server Userinfo of logged in user based on Bearer token.
        /// </summary>
        /// <returns>String email of the logged in user</returns>
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
