using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Views
{
    public class GradoxTipoxCreditos
    {
        public string NombreGrado { get; set; }
        public ICollection<Asignatura> Asignaturas { get; set; }
    }
}