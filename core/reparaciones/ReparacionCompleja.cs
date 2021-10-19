namespace p2ejercicio1.core.reparaciones
{
    public class ReparacionCompleja : Reparacion
    {
        public ReparacionCompleja(Aparato a, double horas, double precioPiezas) : base(a, horas, precioPiezas)
        {
            base.PrecioFinal = this.calcularPrecioFinal();
        }
            
        

        public override double calcularPrecioFinal()
        {
            return (base.Horas * (this.Aparato.PrecioHora+this.Aparato.PrecioHora*0.25))+base.PrecioPiezas;
        }

        public override string ToString()
        {
            string toret="Reparacion compleja:\n"; 
            toret += "- Aparato: "+ base.Aparato.ToString();

            toret += "- \t\nDetalles de la reparacion: \n\tNumero de horas: " + base.Horas + "\n\tPrecio de las piezas: " +
                     base.PrecioPiezas+"\t\n Precio final: "+base.PrecioFinal;
                
                
    
            return toret;
        }
    }
}