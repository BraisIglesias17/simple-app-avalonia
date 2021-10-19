using System;

namespace p2ejercicio1.core.aparatos
{


    public enum Banda
    {
        FM,
        AM,
        FM_AM
    }
    public class Radio : Aparato
    {


        public Radio(int numSerie, string modelo, double precio, Banda banda):base(numSerie,modelo,precio)
        {
            this.Banda = banda;
            base.setTipo("radio");
        }

        public Banda Banda
        {
            get;
        }
        public override string ToString()
        {
            string toret="Radio: \n\t"+base.ToString()+"-Banda: "+this.Banda.ToString();

            return toret;

        }
        
        
    }
}