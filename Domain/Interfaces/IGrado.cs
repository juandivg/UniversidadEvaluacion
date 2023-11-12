using Domain.Entities;
using Domain.Views;

namespace Domain.Interfaces
{
    public interface IGrado : IGeneric<Grado>
    {
        Task<IEnumerable<AsignaturasxGrado>> GetAsignaturasxGrado();
        Task<IEnumerable<Grado>> GetGradoxTipoxCreditos();
    }
}