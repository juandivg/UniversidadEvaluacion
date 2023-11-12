using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class GradoxAsignaturasCreditosDto
    {
        public string Nombre { get; set; }
        public List<AsignaturaxTipoxCreditosDto> Asignaturas { get; set; }
    }
}