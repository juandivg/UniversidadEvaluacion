using Domain.Entities;
using Domain.Views;

namespace Domain.Interfaces
{
    public interface IDepartamento : IGeneric<Departamento>
    {
        Task<IEnumerable<Departamento>> GetDepartamentoProfesoresInformatica();
        Task<IEnumerable<DepartamentoAsignaturaSinImpartir>> GetDepartamentoConAsignaturaSinImpartir();
        Task<IEnumerable<ProfesoresxDepartamento>> GetProfesoresxDepartamento();
        Task<IEnumerable<ProfesoresxDepartamento>> GetProfesoresxDepartamento2();

    }
}