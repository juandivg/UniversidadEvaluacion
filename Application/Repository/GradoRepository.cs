using Domain.Entities;
using Domain.Interfaces;
using Domain.Views;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class GradoRepository : GenericRepository<Grado>, IGrado
{
    private readonly UniversidadAContext _context;
    public GradoRepository(UniversidadAContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Grado> GetByIdAsync(int id)
    {
        return await _context.Grados
                            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<Grado>> GetAllAsync()
    {
        return await _context.Grados.ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Grado> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Grados as IQueryable<Grado>;
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

    public async Task<IEnumerable<AsignaturasxGrado>> GetAsignaturasxGrado()
    {
        var query= await _context.Grados.Include(p=>p.Asignaturas).ToListAsync();
        return query.Select(d=> new AsignaturasxGrado
        {
            NombreGrado=d.Nombre,
            CantidadAsignaturas=d.Asignaturas.Count()
        }).OrderByDescending(p=>p.CantidadAsignaturas);
    }

    public async Task<IEnumerable<Grado>> GetGradoxTipoxCreditos()
    {
          return await _context.Grados.Include(p=>p.Asignaturas.Select(a=> new Asignatura{
            TipoAsignatura=a.TipoAsignatura,
            Creditos=a.TipoAsignatura.Asignaturas.Sum(c=>c.Creditos)
          })).ToListAsync();
    }
    
}