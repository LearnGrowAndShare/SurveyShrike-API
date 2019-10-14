using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyShrike_API.Application.Surveys.Commands.CreateSurveyResponse;

namespace SurveyShrike_API.Controllers
{
    public class ReponseController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> Create([FromBody] CreateSurveyCommand command)
        {
            command.IP = HttpContext.Connection.RemoteIpAddress.ToString();
            await Mediator.Send(command);

            return NoContent();
        }

    }
}