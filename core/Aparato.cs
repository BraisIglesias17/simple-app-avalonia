namespace p2ejercicio1.core
{
    public abstract class Aparato
    {
        //Aparato (num serie, modelo, precioxhora)
        /*
         * Radio (banda)
	Television (pulgadas)
	ReproductorDVD (blue-ray,grabar,tiempo de grabacion)
	adaptadorTDT(grabar,tiempo max grabacion)
         */

        
        /// <summary>
        /// Constructor del objeto abstracto Aparato
        /// </summary>
        /// <param name="numSerie"> indica el numero de serie del aparto</param>
        /// <param name="modelo"> indica el modelo del aparato</param>
        /// <param name="precio"> indica el precio por hora del aparato</param>
        public Aparato(int numSerie, string modelo, double precio)
        {
            this.Modelo = modelo;
            this.NumSerie = numSerie;
            this.PrecioHora = precio;
        }



        /// <summary>
        /// Propiedad que permite recuperar el valor del modelo de un aparato, este no es modificable
        /// </summary>
        public string Modelo
        {
            get;
        }

        /// <summary>
        /// Propiedad que permite recuperar el valor del numero de serie de un aparato, este no es modificable
        /// </summary>
        public int NumSerie
        {
            get;
        }

        /// <summary>
        /// propiedad que permite recuperar y modificar el valor del precio de reparacion del aparato
        /// </summary>
        public double PrecioHora
        {
            get;
            set;
        }

        /// <summary>
        /// metodo abstracto para que las subclases lo implementen
        /// </summary>
        /// <returns> string con la informacion del aparato</returns>
        public override string ToString()
        {
            return string.Format("-Numero de serie: {0}\n\t-Modelo: {1}\n\t-Precio por hora{2}\n\t",this.NumSerie,this.Modelo,this.PrecioHora);
        }

        
        
    
        protected string tipo;


        protected void setTipo(string tipo)
        {
            this.tipo = tipo;
        }

        public string Tipo => this.tipo;

    }
}