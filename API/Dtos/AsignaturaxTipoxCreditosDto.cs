using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class AsignaturaxTipoxCreditosDto
    {
        public TipoAsignaturaDto TipoAsignatura { get; set; }
        public float Creditos { get; set; }
    }
}