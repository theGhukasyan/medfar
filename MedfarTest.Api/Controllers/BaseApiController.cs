using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MedfarTest.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseApiController : ControllerBase
{
    protected readonly IMediator _mediator;
    
    public BaseApiController(IMediator mediator)
    {
        _mediator = mediator;
    }
}