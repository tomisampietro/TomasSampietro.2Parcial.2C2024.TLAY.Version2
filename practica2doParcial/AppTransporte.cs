using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica2doParcial
{
    internal class AppTransporte
    {
        Validador validador;
        List<Cotizacion> cotizaciones;
        List<Modalidad> modalidades;

        public AppTransporte()
        {
            cotizaciones = new List<Cotizacion>();
            modalidades = new List<Modalidad>();
            validador = new Validador();
        }

        public void ejecutar()
        {
            cargaIncial();
            cargarModalidades();

            string opcion = "";
            do
            {

                opcion = validador.pedirStringNoVacio("Ingrese una opcion: \n\nA. Nueva Cotizacion\nB. Listar Cotizaciones \nC.Salir");

                if (opcion == "A")
                {
                    cargarCotizacion();
                }
                else if (opcion == "B")
                {
                    listarCotizacion();
                }
                else if (opcion == "C")
                {
                    Console.WriteLine("Ha salido del programa.");
                }
                else
                {
                    Console.WriteLine("Esa opcion no existe.");
                }
            } while (opcion != "C");
        }

        public void cargarCotizacion()
        {
            int numCot = cotizaciones.Count() + 1;
            string emailCli = validador.pedirStringNoVacio("Ingrese email: ");

            Cotizacion cotAAgregar = new Cotizacion(numCot, emailCli);


            string seguirCargandoItems = "";


            string descripcionItem = "";
            double m3;
            double kgItem;

            do
            {
                descripcionItem = validador.pedirStringNoVacio("Descripcion item: ");
                kgItem = validador.pedirDouble("KG del item: ");
                m3 = validador.pedirDouble("m3 del item: ");

                Items itemAAgregar = new Items(descripcionItem, kgItem, m3);
                cotAAgregar.items.Add(itemAAgregar);
                seguirCargandoItems = validador.pedirStringNoVacio("desea seguir cargando items 's' o 'n'");


            } while (seguirCargandoItems != "N");

            string seguirCargandoTramos = "";
            do
            {
                bool cumpleRestricciones = false;
                double precioModalidad = 0;
                string origen = "";
                string destino = "";
                string modalidadNombre = "";
                do
                {
                    modalidadNombre = validador.pedirStringNoVacio("Modalidad a cargar: ");

                    Modalidad modalidadSeleccionada = modalidades.Find(p => p.NombreModalidad == modalidadNombre);

                    //Validar restricciones
                    if (modalidadSeleccionada != null )
                    {
                        cumpleRestricciones = modalidadSeleccionada.validarRestricciones(kgItem, m3);
                        precioModalidad = modalidadSeleccionada.calcularImporte(kgItem, m3);

                        if (!cumpleRestricciones)
                        {
                            Console.WriteLine("No se permite llevar el item en la modalidad indicada.");
                        }
                    }
                    else //Significa que el resulta es null --> La modalidad no existe. 
                    {
                        Console.WriteLine("Esa modalidad no existe. ");
                    }
                }
                while (!cumpleRestricciones);
                
                  origen = validador.pedirStringNoVacio("Ingrese origen: ");
                  destino = validador.pedirStringNoVacio("Ingrese destino: ");
                

                int numTramo = cotAAgregar.tramos.Count();
                string esIntermedio = validador.pedirStringNoVacio("El tramo, es intermedio?: ");

                Tramo tramoAAgregar = new Tramo(numTramo, origen, destino, esIntermedio, modalidadNombre, precioModalidad);
                
                
                cotAAgregar.tramos.Add(tramoAAgregar);


                seguirCargandoTramos = validador.pedirStringNoVacio("desea seguir cargando items 's' o 'n'");

            } while (seguirCargandoTramos != "N");

            cotizaciones.Add(cotAAgregar);
            Console.WriteLine("Se agrego la siguiente cotizacion: " + cotAAgregar.ToString()); 
        }


        public void cargarModalidades()
        {
            modalidades.Add(new Tren());
            modalidades.Add(new Camion());
            modalidades.Add(new Barco());
            modalidades.Add(new Avion());
            modalidades.Add(new Deposito());
        }


        public void listarCotizacion()
        {
            foreach(Cotizacion cot in cotizaciones)
            {
                Console.WriteLine(cot.ToString());
            }
        }


        public int getNumeroCotizacion()
        {
            int retorno = cotizaciones.Count() + 1;
            return retorno;

        }


        public void cargaIncial()
        {
            // Ejemplo 1
            Cotizacion cotizacion1 = new Cotizacion(getNumeroCotizacion(), "cliente1@example.com");
            cotizacion1.items.Add(new Items("Item 1", 10.5, 20));
            cotizacion1.items.Add(new Items("Item 2", 5.0, 10));
            cotizacion1.tramos.Add(new Tramo(cotizacion1.getNumTramo(), "Origen 1", "Destino 1", "No", "TREN", 150));
            cotizacion1.tramos.Add(new Tramo(cotizacion1.getNumTramo(), "Origen 2", "Destino 2", "Si", "CAMION", 200));
            cotizaciones.Add(cotizacion1);

            // Ejemplo 2
            Cotizacion cotizacion2 = new Cotizacion(getNumeroCotizacion(), "cliente2@example.com");
            cotizacion2.items.Add(new Items("Item 3", 15.0, 25));
            cotizacion2.items.Add(new Items("Item 4", 7.5, 12));
            cotizacion2.tramos.Add(new Tramo(cotizacion2.getNumTramo(), "Origen 3", "Destino 3", "No", "AVION", 300));
            cotizacion2.tramos.Add(new Tramo(cotizacion2.getNumTramo(), "Origen 4", "Destino 4", "Si", "BARCO", 400));
            cotizaciones.Add(cotizacion2);

            // Ejemplo 3
            Cotizacion cotizacion3 = new Cotizacion(getNumeroCotizacion(), "cliente3@example.com");
            cotizacion3.items.Add(new Items("Item 5", 20.0, 30));
            cotizacion3.items.Add(new Items("Item 6", 10.0, 15));
            cotizacion3.tramos.Add(new Tramo(cotizacion3.getNumTramo(), "Origen 5", "Destino 5", "No", "DEPOSITO", 100));
            cotizacion3.tramos.Add(new Tramo(cotizacion3.getNumTramo(), "Origen 6", "Destino 6", "Si", "TREN", 250));
            cotizaciones.Add(cotizacion3);
        }
    }
}
