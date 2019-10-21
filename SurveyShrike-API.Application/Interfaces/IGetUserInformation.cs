using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// @author Ankit
/// @date - 10/15/2019 2:44:09 AM 
/// </summary>
namespace SurveyShrike_API.Application.Interfaces
{
    /// <summary>
    /// DI for get user information.
    /// </summary>
    public interface IGetUserInformation
    {
        /// <summary>
        /// Get user to provide the logged in user email
        /// </summary>
        /// <returns>Email of the logged in user.</returns>
        Task<string> GetUser();
    }
}
