using Domain.Entities;
using Domain.Interfaces;
using Domain.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Persistence;

namespace Application.Repository;
public class PersonaRepository : GenericRepository<Persona>, IPersona
{
    private readonly UniversidadAContext _context;
    public PersonaRepository(UniversidadAContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Persona> GetByIdAsync(int id)
    {
        return await _context.Personas
                            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<Persona>> GetAllAsync()
    {
        return await _context.Personas.ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Persona> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Personas as IQueryable<Persona>;
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        return (totalRegistros, registros);
    }

    public async Task<IEnumerable<Persona>> GetAlumnosxNombre()
    {
        return await _context.Personas
                                    .Where(p => p.IdTipoPersonafk == 2)
                                    .OrderBy(p => p.Apellido1)
                                    .ThenBy(p => p.Apellido2)
                                    .ThenBy(p => p.Nombre)
                                    .Select(p => new Persona { Apellido1 = p.Apellido1, Apellido2 = p.Apellido2, Nombre = p.Nombre })
                                    .ToListAsync();
    }
    public async Task<IEnumerable<Persona>> GetAlumnosSinTelefono()
    {
        return await _context.Personas
                                    .Where(p => p.IdTipoPersonafk == 2 && p.Telefono == null)
                                    .Select(p => new Persona { Apellido1 = p.Apellido1, Apellido2 = p.Apellido2, Nombre = p.Nombre })
                                    .ToListAsync();
    }
    public async Task<IEnumerable<Persona>> GetAlumnosNacieron1999()
    {
        return await _context.Personas
                                    .Where(p => p.IdTipoPersonafk == 2 && p.FechaNacimiento.Year == 1999)
                                    .ToListAsync();
    }

    public async Task<IEnumerable<Persona>> GetProfesoresSinTelefono()
    {
        return await _context.Personas
                                    .Where(p => p.IdTipoPersonafk == 1 && p.Telefono == null && p.Nif.EndsWith("K"))
                                    .ToListAsync();
    }

    public async Task<IEnumerable<Persona>> GetAlumnasEnSistemas()
    {
        var alumnas = await _context.Personas
                                        .Include(p => p.AlumnoMatriculaAsignaturas)
                                        .ThenInclude(p => p.Asignatura)
                                        .ThenInclude(p => p.Grado)
                                        .Where(p => p.IdSexofk == 2 && p.AlumnoMatriculaAsignaturas.Any(p => p.Asignatura.Grado.Id == 4))
                                        .GroupBy(entry => new
                                        {
                                            entry.Id,
                                            entry.Nif,
                                            entry.Nombre,
                                            entry.Apellido1,
                                            entry.Apellido2,
                                            entry.Ciudad,
                                            entry.Direccion,
                                            entry.Telefono,
                                            entry.FechaNacimiento,
                                            entry.IdSexofk,
                                            entry.IdTipoPersonafk
                                        })
                                        .Select(grupo => new Persona
                                        {
                                            Id = grupo.Key.Id,
                                            Nif = grupo.Key.Nif,
                                            Nombre = grupo.Key.Nombre,
                                            Apellido1 = grupo.Key.Apellido1,
                                            Apellido2 = grupo.Key.Apellido2,
                                            Ciudad = grupo.Key.Ciudad,
                                            Direccion = grupo.Key.Direccion,
                                            Telefono = grupo.Key.Telefono,
                                            FechaNacimiento = grupo.Key.FechaNacimiento,
                                            IdSexofk = grupo.Key.IdSexofk,
                                            IdTipoPersonafk = grupo.Key.IdTipoPersonafk
                                        })
                                        .ToListAsync();

        return alumnas;
    }

    public async Task<IEnumerable<Persona>> GetProfesoresConDepartamento()
    {
        return await _context.Personas
                                .Include(p => p.Profesores)
                                .ThenInclude(p => p.Departamento)
                                .Where(p => p.IdTipoPersonafk == 1)
                                .ToListAsync();
    }

    public async Task<IEnumerable<Persona>> GetAlumnosMatriculadosAnyo()
    {
        return await _context.Personas
                                    .Include(p => p.AlumnoMatriculaAsignaturas)
                                    .ThenInclude(p => p.CursoEscolar)
                                    .Where(p => p.AlumnoMatriculaAsignaturas.Any(p => p.CursoEscolar.AnyoInicio == 2018 && p.CursoEscolar.AnyoFinal == 2019))
                                    .ToListAsync();
    }
    public async Task<IEnumerable<ProfesoresConDepartamento>> GetProfesoresConDepartamentos()
    {
        var query = from p in _context.Personas
            join pro in _context.Profesores on p.Id equals pro.IdPersonafk into proGroup
            from pro in proGroup.DefaultIfEmpty()
            join d in _context.Departamentos on pro.IdDepartamentofk equals d.Id into deptGroup
            from d in deptGroup.DefaultIfEmpty()
            where p.IdTipoPersonafk == 1
            orderby d.Nombre, p.Apellido1, p.Apellido2, p.Nombre
            select new ProfesoresConDepartamento
            {
                Departamento = d.Nombre,
                Apellido1 = p.Apellido1,
                Apellido2 = p.Apellido2,
                Nombre = p.Nombre
            };

        return await query.ToListAsync();
    }
    public async Task<CantidadAlumnas> GetCantidadAlumnas()
    {
        var cantidad= await _context.Personas.Where(p=>p.IdTipoPersonafk==2 && p.IdSexofk==2).CountAsync();
        
        return new CantidadAlumnas { Cantidad=cantidad};
    
    }

    public async Task<CantidadAlumnas> GetCantidadAlumnosAnio()
    {
        var cantidad= await _context.Personas.Where(p=>p.FechaNacimiento.Year==1999).CountAsync();
         return new CantidadAlumnas { Cantidad=cantidad};
    }
}