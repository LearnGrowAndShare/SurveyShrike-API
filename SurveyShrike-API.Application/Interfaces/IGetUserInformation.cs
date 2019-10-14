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
    public interface IGetUserInformation
    {
        Task<string> GetUser();
    }
}
