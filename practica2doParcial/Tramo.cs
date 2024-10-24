using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica2doParcial
{
    internal class Tramo
    {
        public int NumeroTramo { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string EsIntermediario { get; set; }
        public string Modalidad { get; set; }
        public double Importe { get; set; }

        //Constructor
        public Tramo(int pNumeroTramo, string pOrigen, string pDestino, string pEsIntermediario, string pModalidad, double pImporte)
        {
            NumeroTramo = pNumeroTramo;
            Origen = pOrigen;
            Destino = pDestino;
            EsIntermediario = pEsIntermediario;
            Modalidad = pModalidad;
            Importe = pImporte;
        }

        public override string ToString()
        {
            return $"Tramo: {NumeroTramo}, Origen: {Origen}, Destino: {Destino}, Intermediario: {EsIntermediario}, Modalidad: {Modalidad}, Importe: {Importe:C}";
        }


    }
}
