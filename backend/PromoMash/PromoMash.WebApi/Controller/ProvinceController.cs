using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PromoMash.Application.Core.Province.Command.Create;
using PromoMash.Application.Core.Province.Command.Delete;
using PromoMash.Application.Core.Province.Command.Update;
using PromoMash.Application.Core.Province.Query.List;
using PromoMash.Application.Core.Province.Query.Read;
using PromoMash.WebApi.Model.Province;

namespace PromoMash.WebApi.Controller;

public class ProvinceController : BaseController
{
    private readonly IMapper _mapper;

    public ProvinceController(IMapper mapper)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProvinceCreateDto dto)
    {
        var command = _mapper.Map<ProvinceCreateCommand>(dto);

        var entityId = await Mediator.Send(command);
        
        return Created(entityId);
    }
    
    [HttpGet]
    public async Task<IActionResult> Read(string id)
    {
        var query = new ProvinceReadQuery(id);
        
        var vm = await Mediator.Send(query);
        
        return Ok(vm);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ProvinceUpdateDto dto)
    {
        var command = _mapper.Map<ProvinceUpdateCommand>(dto);

        await Mediator.Send(command);
        
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        var command = new ProvinceDeleteCommand(id);
        
        await Mediator.Send(command);

        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> List(string countryId)
    {
        var query = new ProvinceListQuery(countryId);
        
        var vm = await Mediator.Send(query);

        if (!vm.Provincies.Any())
        {
            return NoContent();
        }

        return Ok(vm);
    }
}