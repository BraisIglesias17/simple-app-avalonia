using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

using p2ejercicio1.core.aparatos;

namespace p2ejercicio1.core.IO
{
    public class XmlRegistroReparaciones
    {
        //declaro las etiquetas necesarias
        public static string archivo_xml = "reparaciones.xml";
        
        
        public static string TAG_BLUERAY = "blueRay";
        public static string TAG_TIPO = "tipo";
        public static string TAG_PULGADAS = "pulgadas";
        public static string TAG_APARATO = "aparato";
        public static string TAG_REPARACION = "reparacion";
        public static string TAG_PRECIOHORA = "precioHora";
        public static string TAG_MODELO = "modelo";
        public static string TAG_SERIE = "serie";
        public static string TAG_GRABACION = "grabacion";
        public static string TAG_TIEMPO_GRABACION = "maxGrabacion";
        public static string TAG_BANDA = "banda";
        public static string TAG_PRECIO_PIEZAS = "precioPiezas";
        public static string TAG_PRECIOFINAL = "precioFinal"; 
        public static string TAG_HORAS = "horas";
        public static string TAG_ROOT = "reparaciones";


        private List<Reparacion> auxiliar;
        /// <summary>
        /// metodo por defecto para guardar la informacion enn el archivo reparaciones.xml
        /// </summary>
        public void GuardaXML()
        {
            this.GuardaXML(XmlRegistroReparaciones.archivo_xml);
        }

        /// <summary>
        /// metodo para guardar en un archivo los cambios especificando el archivo destino
        /// </summary>
        /// <param name="nf"> nombre del fichero destino</param>
        public void GuardaXML(string nf)
        {
            this.toXML(nf);
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="r"> registro de reparaciones</param>
        public XmlRegistroReparaciones(RegistroReparaciones r)
        {
            this.RegistroReparaciones = r;
            
            
        }
        
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public XmlRegistroReparaciones()
        {
            this.RegistroReparaciones = new RegistroReparaciones();
        }

        /// <summary>
        /// propiedad para poder visualizar la lista desde afuera
        /// </summary>
        public RegistroReparaciones RegistroReparaciones
        {
            get;
        }
        
        /// <summary>
        /// metodo encargado de convertir la informacion de la estructura de registroreparaciones a un formato XML en el archivo especificado
        /// </summary>
        /// <param name="nf"> archivo de salida</param>
          private void toXML(string nf)
          {
            var doc = new XDocument();
            var root = new XElement(XmlRegistroReparaciones.TAG_ROOT);
            
     
            foreach (Reparacion r in this.RegistroReparaciones.Lista)
            {
                Console.WriteLine(r.ToString());
                XElement aparato;
                if (r.Aparato.Tipo.Equals("television"))
                {
                    Television tv = (Television) r.Aparato;
                    aparato=new XElement(TAG_APARATO,
                        new XAttribute(TAG_TIPO,r.Aparato.Tipo),
                        new XAttribute(TAG_MODELO,r.Aparato.Modelo),
                        new XAttribute(TAG_SERIE,r.Aparato.NumSerie),
                        new XAttribute(TAG_PRECIOHORA,r.Aparato.PrecioHora),
                        new XAttribute(TAG_PULGADAS,tv.Pulgadas)
                    );
                }else if (r.Aparato.Tipo.Equals("radio"))
                {
                    Radio tv = (Radio) r.Aparato;
                    aparato=new XElement(TAG_APARATO,
                        new XAttribute(TAG_TIPO,r.Aparato.Tipo),
                        new XAttribute(TAG_MODELO,r.Aparato.Modelo),
                        new XAttribute(TAG_SERIE,r.Aparato.NumSerie),
                        new XAttribute(TAG_PRECIOHORA,r.Aparato.PrecioHora),
                        new XAttribute(TAG_BANDA,tv.Banda)
                    ); 
                }else if (r.Aparato.Tipo.Equals("reproductorDVD"))
                {
                    ReproductorDVD tv = (ReproductorDVD) r.Aparato;
                    aparato=new XElement(TAG_APARATO,
                        new XAttribute(TAG_TIPO,r.Aparato.Tipo),
                        new XAttribute(TAG_MODELO,r.Aparato.Modelo),
                        new XAttribute(TAG_SERIE,r.Aparato.NumSerie),
                        new XAttribute(TAG_PRECIOHORA,r.Aparato.PrecioHora),
                        new XAttribute(TAG_BLUERAY,tv.BlueRay),
                        new XAttribute(TAG_GRABACION,tv.PuedeGrabar),
                        new XAttribute(TAG_TIEMPO_GRABACION,tv.Minutos)
                    );
                }
                else
                {
                    AdapdatorTDT tv = (AdapdatorTDT) r.Aparato;
                    aparato=new XElement(TAG_APARATO,
                        new XAttribute(TAG_TIPO,r.Aparato.Tipo),
                        new XAttribute(TAG_MODELO,r.Aparato.Modelo),
                        new XAttribute(TAG_SERIE,r.Aparato.NumSerie),
                        new XAttribute(TAG_PRECIOHORA,r.Aparato.PrecioHora),
                        new XAttribute(TAG_GRABACION,tv.PuedeGrabar),
                        new XAttribute(TAG_TIEMPO_GRABACION,tv.Minutos)
                    );
                }

                
                
                
                root.Add(new XElement( TAG_REPARACION,
                                        aparato,
                                        new XAttribute(TAG_PRECIO_PIEZAS,r.PrecioPiezas),
                                        new XAttribute(TAG_HORAS,r.Horas),
                                        new XAttribute(TAG_PRECIOFINAL,r.PrecioFinal)
                    )
                );
                
            }
            doc.Add(root);
            doc.Save(nf);
            
        }

        public List<Reparacion> RecuperarXML()
        {
            return this.RecuperarXML(archivo_xml);
        }
        public List<Reparacion> RecuperarXML(string nf)
        {
            var lista = new List<Reparacion>();

            try
            {
                var doc = XDocument.Load(nf);
                var rootTag = doc?.Root?.Name.ToString() ?? "";
                
                if (doc?.Root != null && rootTag == TAG_ROOT)
                {
                    var reparaciones = doc.Root.Elements();
                    
                    foreach (XElement reparacion in reparaciones)
                    {
                        
                        double precioFinal=Convert.ToDouble((string?) reparacion.Attribute(TAG_PRECIOFINAL) ?? "0");
                        double precioPiezas=Convert.ToDouble((string?) reparacion.Attribute(TAG_PRECIO_PIEZAS) ?? "0");
                        double horas=Convert.ToDouble((string?) reparacion.Attribute(TAG_HORAS) ?? "0");

                        XElement aparato = reparacion.Element(TAG_APARATO);

                        string tipo=(string?) aparato.Attribute(TAG_TIPO) ?? "TIPO";
                        string modelo=(string?) aparato.Attribute(TAG_MODELO) ?? "TIPO";
                        int numSerie=Convert.ToInt32((string?) aparato.Attribute(TAG_SERIE)?? "0");
                        double precio=Convert.ToDouble((string?) aparato.Attribute(TAG_PRECIOHORA)?? "0");
                        Aparato ap;
                        switch (tipo)
                        {
                            case "television":
                                double pulgadas=Convert.ToDouble((string?) aparato.Attribute(TAG_PULGADAS)?? "0");;
                                ap = new Television(numSerie,modelo,precio,pulgadas);
                                break;
                            case "radio": 
                                string banda=(string?) aparato.Attribute(TAG_BANDA) ?? "AM";
                                Banda bd;
                                switch (banda)
                                {
                                    case "AM" :
                                        bd = Banda.AM;
                                        break;
                                    case "FM": bd=Banda.FM;
                                        break;
                                    case "FM_AM": bd=Banda.FM_AM;
                                        break;
                                    default:
                                        bd = Banda.AM;
                                        break;
                                }
                                    ap = new Radio(numSerie,modelo,precio,bd);
                                break;
                            case "adaptadorTDT":
                                bool grabar=Convert.ToBoolean((string?) aparato.Attribute(TAG_GRABACION) ?? "false");
                                int min = Convert.ToInt32((string?)  aparato.Attribute(TAG_TIEMPO_GRABACION)  ?? "0");
                                
                                ap = new AdapdatorTDT(numSerie,modelo,precio,grabar,min);
                                break;
                            case "reproductorDVD":
                                bool blueRay=Convert.ToBoolean((string?) aparato.Attribute(TAG_GRABACION) ?? "false");
                                grabar=Convert.ToBoolean((string?) aparato.Attribute(TAG_GRABACION) ?? "false");
                                min = Convert.ToInt32((string?) aparato.Attribute(TAG_TIEMPO_GRABACION) ?? "0");
                                
                                ap = new ReproductorDVD(numSerie,modelo,precio,blueRay,grabar,min);
                                break;
                            default:
                                

                                throw new Exception("Aparato ni reconocido");
                                break;
                        }
                        
                        lista.Add(Reparacion.Crea(ap,horas,precioPiezas));
                        
                    }
                }
               
            }
            catch (XmlException exc)
            {
                Console.WriteLine("ERROR XML: "+exc.Message+"\n"+exc.StackTrace);
            }
            catch (Exception exc)
            {
                Console.WriteLine("ERROR: "+exc.Message+"\n"+exc.StackTrace);
            }

            return lista;
        }
    }
}