using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SurveyShrike_API.Application.Surveys.Commands.CreateSurvey;
using SurveyShrike_API.Application.Surveys.Commands.DeleteSurvey;
using SurveyShrike_API.Application.Surveys.Commands.UpdateSurvey;
using SurveyShrike_API.Application.Surveys.Queries.GetSurveyDetails;
using SurveyShrike_API.Application.Surveys.Queries.GetSurveyList;
using SurveyShrike_API.Controllers;

namespace Surveyhrike_API.Controllers
{
    public class SurveyController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<SurveyListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetSurveyListQuery()));
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SurveyShrike_API.Application.Surveys.Queries.GetSurveyDetailsWithResponses.SurveyDetailModel>> GetSummary(Guid id)
        {
            return Ok(await Mediator.Send(new SurveyShrike_API.Application.Surveys.Queries.GetSurveyDetailsWithResponses.GetSurveyDetailQuery { Id = id }));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SurveyDetailModel>> Get(Guid id)
        {
            return Ok(await Mediator.Send(new GetSurveyDetailQuery { Id = id }));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> Create([FromBody] CreateSurveyCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IActionResult>> Update([FromBody] UpdateSurveyCommand command)
        { 
            await Mediator.Send(command);
             return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(Guid id)
        {

            await Mediator.Send(new DeleteSurveyCommand { Id = id });

            return NoContent();
        }
    }
}
