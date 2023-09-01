using API.Dtos;
using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

public class VehiculoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public VehiculoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<VehiculoDto>>> Get()
    {
        var Vehiculos = await unitofwork.Vehiculos.GetAllAsync();
        return mapper.Map<List<VehiculoDto>>(Vehiculos);
    }
}
