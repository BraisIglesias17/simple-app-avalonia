using System;

namespace p2ejercicio1.core.aparatos
{
    public class ReproductorDVD: Aparato
    {


        public ReproductorDVD(int numSerie, string modelo, double precio, bool blueRay, bool grabar):base(numSerie,modelo,precio)
        {
            this.BlueRay = blueRay;
            this.PuedeGrabar=grabar;
            this.Minutos = 0;
            base.setTipo("reproductorDVD");
        }
        public ReproductorDVD(int numSerie, string modelo, double precio, bool blueRay, bool grabar, int minutos):base(numSerie,modelo,precio)
        {
            base.setTipo("reproductorDVD");
            this.BlueRay = blueRay;
            this.PuedeGrabar=grabar;
            this.Minutos = minutos;
        }


        public override string ToString()
        {
            string toret = "ReproductorDVD: \n\t" + base.ToString();
            if (!this.PuedeGrabar)
            {
                toret += "-BlueRay: " + this.BlueRay + "\n\t-No puede grabar";

                return toret;
            }
            else
            {
                toret += "-BlueRay: " + this.BlueRay + "\n\t-Puede grabar \n\t-Tiempo maximo de grabacion(min): "+this.Minutos;

                return toret;
               

            }

        }

        public bool BlueRay
        {
            get;
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