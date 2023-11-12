using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class AlumnoMatriculaAsignaturaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AlumnoMatriculaAsignaturaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    //[Authorize(Roles = "Administrator,Employee")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AlumnoMatriculaAsignaturaDto>>> Get1()
    {
        var results = await _unitOfWork.AlumnoMatriculaAsignaturas
                                    .GetAllAsync();
        return _mapper.Map<List<AlumnoMatriculaAsignaturaDto>>(results);
    }

    [HttpGet("{id}")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AlumnoMatriculaAsignaturaDto>> Get2(int id)
    {
        var result = await _unitOfWork.AlumnoMatriculaAsignaturas.GetByIdAsync(id);
        return _mapper.Map<AlumnoMatriculaAsignaturaDto>(result);
    }

    [HttpPost]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AlumnoMatriculaAsignatura>> Post(AlumnoMatriculaAsignaturaDto resultDto)
    {
        var result = _mapper.Map<AlumnoMatriculaAsignatura>(resultDto);
        this._unitOfWork.AlumnoMatriculaAsignaturas.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
        {
            return BadRequest();
        }
        resultDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { id = resultDto.Id }, resultDto);
    }

    [HttpPut("{id}")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AlumnoMatriculaAsignatura>> Put(int id, [FromBody] AlumnoMatriculaAsignaturaDto resultDto)
    {
        var result = _mapper.Map<AlumnoMatriculaAsignatura>(resultDto);
        if (result == null)
        {
            return NotFound();
        }
        _unitOfWork.AlumnoMatriculaAsignaturas.Update(result);
        await _unitOfWork.SaveAsync();
        return result;
    }

    [HttpDelete("{id}")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _unitOfWork.AlumnoMatriculaAsignaturas.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        _unitOfWork.AlumnoMatriculaAsignaturas.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<AlumnoMatriculaAsignaturaDto>>> GetPag([FromQuery] Params resultParams)
    {
        var result = await _unitOfWork.AlumnoMatriculaAsignaturas.GetAllAsync(resultParams.PageIndex, resultParams.PageSize, resultParams.Search);
        var lstResultDto = _mapper.Map<List<AlumnoMatriculaAsignaturaDto>>(result.registros);
        return new Pager<AlumnoMatriculaAsignaturaDto>(lstResultDto, result.totalRegistros, resultParams.PageIndex, resultParams.PageSize, resultParams.Search);
    }
}
