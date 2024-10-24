using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica2doParcial
{
    internal class Cotizacion
    {
        public int NumeroCotizacion { get; set; }
        public string EmailCliente { get; set; }
        public string FechaCotizacion { get; set; } // no parametro
        public double ImporteTotal { get; set; }

        public List<Items> items { get; set; }
        public List<Tramo> tramos { get; set; }


        //Constructor
        public Cotizacion(int pNumeroCotizacion, string pEmailCliente)
        {
            NumeroCotizacion = pNumeroCotizacion;
            EmailCliente = pEmailCliente;
            FechaCotizacion = DateTime.Now.ToString();

            items = new List<Items>();
            tramos = new List<Tramo>();
        }

        public int getNumTramo()
        {
            int retorno = tramos.Count() + 1;
            return retorno;
        }

        public override string ToString()
        {
            StringBuilder itemsAMostrar = new StringBuilder();
            foreach(Items item in items)
            {
                itemsAMostrar.AppendLine(item.ToString());
            }

            StringBuilder tramosAMostrar = new StringBuilder();
            foreach(Tramo tramo in tramos)
            {
                tramosAMostrar.AppendLine(tramo.ToString());
            }

            return (
                $"Número de Cotización: {NumeroCotizacion}" +
                $"Email del Cliente: {EmailCliente}" +
                $"Fecha de Cotización: {FechaCotizacion}" +
                $"Importe Total: {ImporteTotal}" +
                $"ITEMS: {itemsAMostrar}" +
                $"Tramos: {tramosAMostrar}" 
                );
        }



    }
}
