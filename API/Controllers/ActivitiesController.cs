using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    private readonly IMediator _mediator;
    public ActivitiesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet] // api/activities
    public async Task<ActionResult<List<Activity>>> GetActivities(){
        return await _mediator.Send(new List.Query());
    }

    [HttpGet("{id}")] // api/activities/234KAAB
    public async Task<ActionResult<Activity>> GetActivity([FromRoute] Guid id){
        return Ok();
    }

    
}