namespace p2ejercicio1.core.aparatos
{
    public class AdapdatorTDT : Aparato
    {


        public AdapdatorTDT(int numSerie, string modelo, double precio, bool grabar):base(numSerie,modelo,precio)
        {
           
            base.setTipo("adaptadorTDT");
            this.PuedeGrabar=grabar;
            this.Minutos = 0;
        }
        public AdapdatorTDT(int numSerie, string modelo, double precio, bool grabar, int minutos):base(numSerie,modelo,precio)
        {
            base.setTipo("adaptadorTDT");
            this.PuedeGrabar=grabar;
            this.Minutos = minutos;
        }


        public override string ToString()
        {
            string toret = "ReproductorDVD: \n\t" + base.ToString();
            if (!this.PuedeGrabar)
            {
                toret += "-No puede grabar";

                return toret;
            }
            else
            {
                toret += "-Puede grabar \n\t-Tiempo maximo de grabacion(min): "+this.Minutos;

                return toret;
               

            }
        }

        public bool PuedeGrabar
        {
            get;
        }
        public int Minutos
        {
            get;
        }
       



    }
}