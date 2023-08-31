using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;

public class PaisController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public PaisController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClientesDto>>> Get()
    {
        var Clientes = await unitofwork.Clientes.GetAllAsync();
        return mapper.Map<List<ClientesDto>>(Clientes);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClienteDto>> Get(int id)
    {
        var cliente = await unitofwork.Clientes.GetByIdAsync(id);
        return mapper.Map<ClienteDto>(cliente);
    }

    // [HttpPost]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // public async Task<ActionResult<Pais>> Post(PaisesDto PaisDto)
    // {
    //     var pais = mapper.Map<Pais>(PaisDto);

    //     unitofwork.Paises.Add(pais);
    //     await unitofwork.SaveAsync();
    //     if (pais == null)
    //     {
    //         return BadRequest();
    //     }
    //     PaisDto.Id = pais.Id;
    //     return CreatedAtAction(nameof(Post), new { id = PaisDto.Id }, PaisDto);
    // }

    // [HttpPut("{id}")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status404NotFound)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]

    // public async Task<ActionResult<PaisesDto>> Put(int id, [FromBody] PaisesDto paisDto)
    // {
    //     if (paisDto == null)
    //         return NotFound();

    //     var pais = mapper.Map<Pais>(paisDto);
    //     unitofwork.Paises.Update(pais);
    //     await unitofwork.SaveAsync();
    //     return paisDto;

    // }

    // [HttpDelete("{id}")]
    // [ProducesResponseType(StatusCodes.Status204NoContent)]
    // [ProducesResponseType(StatusCodes.Status404NotFound)]

    // public async Task<ActionResult<PaisDto>> Delete(int id)
    // {
    //     var pais = await unitofwork.Paises.GetByIdAsync(id);
    //     if (pais == null)
    //     {
    //         return NotFound();
    //     }
    //     unitofwork.Paises.Remove(pais);
    //     await unitofwork.SaveAsync();
    //     return NoContent();
    // }



}