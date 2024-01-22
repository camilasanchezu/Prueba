using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Models
{
   public class Tarea
    {
        [Key]
        public int IdTarea { get; set; }
        public string NombreTarea { get; set; }

        public string DescripcionTarea { get; set; }

        public int Estado { get; set; }

    }
}
