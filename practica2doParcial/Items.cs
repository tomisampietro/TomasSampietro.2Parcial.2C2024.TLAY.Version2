using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica2doParcial
{
    public class Items
    {
        //Propiedades
        public string Descripcion { get; set; }
        public double MetrosCubicos { get; set; }
        public double Kg { get; set; }

        //Constructor
        public Items(string pDescripcion, double pMetrosCubicos, double pKg)
        {
            Descripcion = pDescripcion;
            MetrosCubicos = pMetrosCubicos;
            Kg = pKg;
        }

        public override string ToString()
        {
            return (
                $"Descripción: {Descripcion}\n" +
                $"Metros cúbicos: {MetrosCubicos}\n" +
                $"Kg: {Kg}\n"
            );
        }
    }
}
