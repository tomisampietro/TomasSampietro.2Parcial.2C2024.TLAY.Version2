namespace practica2doParcial
{
    public abstract class Modalidad

    {
        public string NombreModalidad { get; set; }

        public Modalidad(string pNombreModalidad)
        {
            NombreModalidad = pNombreModalidad;
        }

        public abstract bool validarRestricciones(double kgItem, double m3);
        public abstract double calcularImporte(double kgItem, double m3);
    }


    internal class Tren : Modalidad
    {


        public Tren() :base("TREN")
        { 
        
        }

        private double pesoMinimo = 5;
        private double precioPorM3 = 15;

        public override bool validarRestricciones(double kgItem, double m3)
        {

            bool retorno;
            if (kgItem < pesoMinimo)
            {
                retorno = false;
            }
            else
            {
                retorno = true;
            }
            return retorno;
        }

        public override double calcularImporte(double kgItem, double m3)
        {
            double retorno = m3 * precioPorM3;
            return retorno;
        }
    }


    internal class Deposito: Modalidad
    {
        public Deposito():base("DEPOSITO") 
        { 
        }

        public override bool validarRestricciones(double kgItem, double m3)
        {
            // Asumimos que no hay restricciones para el depósito
            return true;
        }

        public override double calcularImporte(double kgItem, double m3)
        {
            // Asumimos que el importe es cero para el depósito
            return 0;
        }

    }

    internal class Camion : Modalidad
    {
        public Camion():base("CAMION")
        {

        }

        private double pesoMax = 55;
        private double volumneMaximo = 100;

        private double precioPorM3 = 15;
        private double precioPorKg = 1;

        public override bool validarRestricciones(double kgItem, double m3)
        {
            bool retorno;
            if ((m3 > volumneMaximo) || kgItem > pesoMax)
            {
                retorno = false;
            }
            else
            {
                retorno = true;
            }
            return retorno;
        }

        public override double calcularImporte(double kgDelItem, double m3Transportado)
        {
            return ((m3Transportado * precioPorM3) + (kgDelItem * precioPorKg));
        }
    }

    internal class Barco : Modalidad
    {
        public Barco(): base("BARCO")
        {

        }

        private double pesoMinimo = 5;
        private double volumenMinimo = 2;
        private double precioPorM3 = 10;

        public override bool validarRestricciones(double kgItem, double m3)
        {
            bool retorno;
            if (kgItem < pesoMinimo || m3 < volumenMinimo)
            {
                retorno = false;
            }
            else
            {
                retorno = true;
            }
            return retorno;
        }

        public override double calcularImporte(double kgDelItem, double m3Transportado)
        {
            return (m3Transportado * precioPorM3);
        }

    }


    internal class Avion : Modalidad
    {
        public Avion():base("AVION")
        {

        }

        private double pesoMax = 55;
        private double volumneMaximo = 100;

        private double precioPorM3 = 15;
        private double precioPorKg = 1;

        public override bool validarRestricciones(double kgItem, double m3)
        {
            bool retorno;
            if (kgItem > pesoMax || m3 > volumneMaximo)
            {
                retorno = false;
            }
            else
            {
                retorno = true;
            }
            return retorno;
        }

        public override double calcularImporte(double kgDelItem, double m3Transportado)
        {
            return ((m3Transportado * precioPorM3) + (kgDelItem * precioPorKg));
        }
    }
}
