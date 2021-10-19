using System;

namespace p2ejercicio1.core.reparaciones
{
    public class SustitucionPiezas : Reparacion
    {

        public SustitucionPiezas(Aparato a, double horas, double precioPiezas):base(a,horas,precioPiezas)
        {
            base.PrecioFinal = this.calcularPrecioFinal();
        }

        public override double calcularPrecioFinal()
        {
            return (base.Horas * this.Aparato.PrecioHora)+base.PrecioPiezas;
        }

        
        public override string ToString()
        {
            string toret="Reparacion compleja:\n";
            toret += "- Aparato: "+ base.Aparato.ToString();

            toret += "\n\t- Detalles de la reparacion: \n\tNumero de horas: " + base.Horas + "\n\tPrecio de las piezas: " +
                     base.PrecioPiezas+"\t\n Precio final: "+base.PrecioFinal;
                
                
    
            return toret;
        }
        
    }
}