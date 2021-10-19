namespace p2ejercicio1.core.aparatos
{
    public class Television: Aparato
    {

        public Television(int numSerie, string modelo, double precio, double pulgadas):base(numSerie,modelo,precio)
        {
            this.Pulgadas = pulgadas;
            base.setTipo("television");
        }


        public double Pulgadas
        {
            get;
        }
        

    /// <summary>
    /// metodo de  visualizacion del objeto television
    /// </summary>
    /// <returns> String </returns>
        public override string ToString()
    {
        string toret = "TV: \n\t" + base.ToString() + "-Pulgadas: " + this.Pulgadas;

            return toret;
        }
    }
}