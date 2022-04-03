using System.ComponentModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PromoMash.Application.Core.Country.Commands.Create;
using PromoMash.Application.Core.Country.Commands.Delete;
using PromoMash.Application.Core.Country.Commands.Update;
using PromoMash.Application.Core.Country.Queries.List;
using PromoMash.Application.Core.Country.Queries.Read;
using PromoMash.WebApi.Model.Country;

namespace PromoMash.WebApi.Controller;

public class CountryController : BaseController
{
    private readonly IMapper _mapper;

    public CountryController(IMapper mapper)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpPost]
    [Description("Create country")]
    public async Task<IActionResult> Create([FromBody] CountryCreateDto dto)
    {
        var command = _mapper.Map<CountryCreateCommand>(dto);

        var entityId = await Mediator.Send(command);
        
        return Created(entityId);
    }
    
    [HttpGet("{id}")]
    [Description("Get country by id")]
    public async Task<IActionResult> Read(string id)
    {
        var query = new CountryReadQuery(id);
        
        var vm = await Mediator.Send(query);
        
        return Ok(vm);
    }
    
    [HttpPut]
    [Description("Udate country")]
    public async Task<IActionResult> Update([FromBody] CountryUpdateDto dto)
    {
        var command = _mapper.Map<CountryUpdateCommand>(dto);

        await Mediator.Send(command);
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Description("Update country by id")]
    public async Task<IActionResult> Delete(string id)
    {
        var command = new CountryDeleteCommand(id);
        
        await Mediator.Send(command);

        return NoContent();
    }

    [HttpGet]
    [Description("Get a list of countries")]
    public async Task<IActionResult> List(string? text)
    {
        var query = new CountryListQuery(text);
        
        var vm = await Mediator.Send(query);

        if (!vm.Countries.Any())
        {
            return NoContent();
        }

        return Ok(vm);
    }
}