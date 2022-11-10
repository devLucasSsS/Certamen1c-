using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Inscripcion
    {
        public Profesion Profesion { get; set; }
        public Experiencia Experiencia { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Bono { get; set; }
        public double Sueldo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string BonoExp { get; set; }
        public int MyProperty { get; set; }

        public override string ToString()
        {
            return this.Nombre + "\n" + this.Edad + "\n" + this.Profesion + "\n" + this.Experiencia + "\n" + this.Bono + "\n" + this.Sueldo + "\n" ;
        }
    }
}
