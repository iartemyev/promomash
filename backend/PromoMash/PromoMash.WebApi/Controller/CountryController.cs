using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PromoMash.Application.Core.Country.Command.Create;
using PromoMash.Application.Core.Country.Command.Delete;
using PromoMash.Application.Core.Country.Command.Update;
using PromoMash.Application.Core.Country.Query.List;
using PromoMash.Application.Core.Country.Query.Read;
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
    public async Task<IActionResult> Create([FromBody] CountryCreateDto dto)
    {
        var command = _mapper.Map<CountryCreateCommand>(dto);

        var entityId = await Mediator.Send(command);
        
        return Created(entityId);
    }
    
    [HttpGet]
    public async Task<IActionResult> Read(string id)
    {
        var query = new CountryReadQuery(id);
        
        var vm = await Mediator.Send(query);
        
        return Ok(vm);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CountryUpdateDto dto)
    {
        var command = _mapper.Map<CountryUpdateCommand>(dto);

        await Mediator.Send(command);
        
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        var command = new CountryDeleteCommand(id);
        
        await Mediator.Send(command);

        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> List(string? text)
    {
        var query = new CountryListQuery(text);

        var vm = await Mediator.Send(query);

        if (!vm.Countries.Any())
        {
            return NoContent();
        }

        return Ok(vm.Countries);
    }
}