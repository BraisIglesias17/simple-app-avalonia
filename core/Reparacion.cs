using System.Dynamic;
using p2ejercicio1.core.reparaciones;

namespace p2ejercicio1.core
{
    
    public abstract class Reparacion
    {
        private static double PRECIO_BASE= 10;


        public static Reparacion Crea(Aparato aparato, double horas, double precioPiezas)
        {
            if (horas <= 60)
            {
                return new SustitucionPiezas(aparato, horas, precioPiezas);
            }
            else
            {
                return new ReparacionCompleja(aparato, horas, precioPiezas);
            }
        }
        public Reparacion(Aparato aparato, double horas, double precioPiezas)
        {
            this.Aparato = aparato;
            this.Horas = horas;
            this.PrecioPiezas = precioPiezas;
            this.PrecioFinal=PRECIO_BASE;
        }

        public Aparato Aparato
        {
            get;
        }
        public abstract double calcularPrecioFinal();


        public double PrecioFinal
        {
            get;
            internal set;
        }

        public double Horas
        {
            get;
        }

        public double PrecioPiezas
        {
            get;
        }

        public abstract string ToString();


    }
}