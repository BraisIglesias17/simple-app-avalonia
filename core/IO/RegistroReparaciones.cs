

using System;

namespace p2ejercicio1.core.IO
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using p2ejercicio1.core.aparatos;

    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Collections;
    using System.Xml.Linq;  
    using System.Collections.Generic;
    
    
   /// <summary>
   /// Esta clase representa la estructura de datos que va a servir para proporcionar y recibir datos de la IU.
   /// Su comportamiento se corresponde con el de una lista
   /// </summary>
    public class RegistroReparaciones
   {
       
       /// <summary>
       /// Parametro que representa la lista que almacenara las reparaciones
       /// </summary>
       private ObservableCollection<Reparacion> lista;
        /// <summary>
        /// Constructor para cuando no exista ningun archivo reparaciones xml
        /// </summary>
        public RegistroReparaciones()
        {
            this.lista = new ObservableCollection<Reparacion>();
            
            
        }

        /// <summary>
        /// constructor por si se quiere pasar una lista  ya creada
        /// </summary>
        /// <param name="l">representa la lista ya hecha</param>
        public RegistroReparaciones(ObservableCollection<Reparacion> l)
        {
            this.lista = l;
        }
        /*
        public void AddRange(IEnumerable<Reparacion> coleccion)
        {
            this.lista.AddRange(coleccion);
        }*/
        public void addReparacion(Reparacion x)
        {
            this.lista.Add(x);
        }

        public Reparacion[] ToArray()
        {
            return this.ToArray();
        }


        public ObservableCollection<Reparacion> Lista => this.lista;
        

        public override string ToString()
        {
            var toret=new StringBuilder();
            foreach (var s in this.lista)
            {
                toret.AppendLine(s.ToString());
            }

            return toret.ToString();
        }

        

       
    }
}