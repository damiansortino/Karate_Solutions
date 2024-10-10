using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karate1.Model
{
    public class EspectadorData
    {
        // Penalizaciones
        public string MostrarKinshi1 { get; set; }
        public string MostrarAtenai1 { get; set; }
        public string MostrarKiken1 { get; set; }
        public string MostrarHansoku1 { get; set; }

        public string MostrarKinshi2 { get; set; }
        public string MostrarAtenai2 { get; set; }
        public string MostrarKiken2 { get; set; }
        public string MostrarHansoku2 { get; set; }

        // Puntos
        public string Puntos1 { get; set; }
        public string Puntos2 { get; set; }

        // Otros datos
        public string KumiteKata { get; set; }
        public string Tiempo { get; set; }
        public string Dojo { get; set; }
        public string PTS1 { get; set; }
        public string PTS2 { get; set; }
        public string Modalidad { get; set; }
        public string Ganador { get; set; }

        // Constructor opcional para inicializar con valores predeterminados
        public EspectadorData()
        {
            MostrarKinshi1 = "";
            MostrarAtenai1 = "";
            MostrarKiken1 = "";
            MostrarHansoku1 = "";

            MostrarKinshi2 = "";
            MostrarAtenai2 = "";
            MostrarKiken2 = "";
            MostrarHansoku2 = "";

            Puntos1 = "0";
            Puntos2 = "0";

            KumiteKata = "";
            Tiempo = "00:00";
            PTS1 = "0";
            PTS2 = "0";
            Modalidad = "";
            Ganador = "3";
        }
    }
}
