using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using p2ejercicio1.core;
using p2ejercicio1.core.aparatos;
using p2ejercicio1.core.IO;

namespace Avalonia.PracticaInicial.iu
{
    
    
    public partial class InsertWindow : Window
    {

        
        private RegistroReparaciones rp;
        
        public InsertWindow( RegistroReparaciones rp):this()
        {
            this.rp = rp;
            

        }
        public InsertWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif


            var CbAparato = this.FindControl<ComboBox>("CbTiposAparato");
            var boton = this.FindControl<Button>("volverInicio");
            var btInsetar = this.FindControl<Button>("btInsertar");

            CbAparato.SelectionChanged += (sender,_) => this.setRightParameter(sender);
            boton.Click += (_, _) => this.Close();
            btInsetar.Click += (_, _) => this.InsertarReparacion();

        }

        private void InsertarReparacion()
        {
            try
            {

                int op = this.FindControl<ComboBox>("CbTiposAparato").SelectedIndex;
                
            
            double horas=Convert.ToDouble(this.FindControl<TextBox>("TbHoras").Text);
           
           
           
            
            int numSerie=Convert.ToInt32(this.FindControl<TextBox>("TbNumeroSerie").Text);;
            
            var tbPrecioPiezas = this.FindControl<TextBox>("TbPrecioPiezas");    
            double precioPiezas = Convert.ToDouble(tbPrecioPiezas.Text);
            string modelo=this.FindControl<TextBox>("TbModelo").Text;
            double precio=Convert.ToDouble(this.FindControl<TextBox>("TbPrecio").Text);;
            
            
            switch (op)
            {
                case 0: double pulgadas=double.Parse(this.FindControl<TextBox>("TbPulgadas").Text);
                        this.rp.addReparacion(Reparacion.Crea(new Television(numSerie,modelo,precio,pulgadas),horas,precioPiezas));
                    break;
                case 1:
                    Banda banda=Banda.FM;
                    switch (this.FindControl<ComboBox>("CbBanda").SelectedIndex)
                    {
                        case 0:
                            banda = Banda.FM;
                            break;
                        case 1:
                            banda = Banda.AM;
                            break;
                        case 2:
                            banda = Banda.FM_AM;
                            break;
                        default: break;
                    }
                        
                    this.rp.addReparacion(Reparacion.Crea(new Radio(numSerie,modelo,precio,banda),horas,precioPiezas));
                    break;
                case 2:
                    bool blueRay = false;
                    bool grabar = false;
                    int min = 0;

                    switch (this.FindControl<ComboBox>("CbBlueRay").SelectedIndex)
                    {
                        case 0:
                            blueRay = true;
                            break;
                        case 1: blueRay = false;
                            break;
                        default: break;
                    }
                    switch (this.FindControl<ComboBox>("CbGrabar").SelectedIndex)
                    {
                        case 0:
                            grabar = true;
                            min=Int32.Parse(this.FindControl<TextBox>("TbTiempoMaxGrabacion").Text);
                            break;
                        case 1:
                            grabar = false;
                            break;
                        default: break;
                    }
                    
                    this.rp.addReparacion(Reparacion.Crea(new ReproductorDVD(numSerie,modelo,precio,blueRay,grabar,min),horas,precioPiezas));
                    break;
                case 3:
                    grabar = false;
                    min = 0;
                    switch (this.FindControl<ComboBox>("CbGrabar").SelectedIndex)
                    {
                        case 0:
                            grabar = true;
                            min=Int32.Parse(this.FindControl<TextBox>("TbTiempoMaxGrabacion").Text);
                            break;
                        case 1:
                            grabar = false;
                            break;
                        default: break;
                    }
                    
                    this.rp.addReparacion(Reparacion.Crea(new AdapdatorTDT(numSerie,modelo,precio,grabar,min),horas,precioPiezas));
                    break;
                default:
                    break;
                
            }
            
            this.Close();
            new AboutWindow("Reparacion introducida correctamente").Show();
            }
            catch (Exception e)
            {
                new AboutWindow(e.StackTrace).Show();
                //Console.WriteLine(e.Message);
               
            }
        }

        private void setRightParameter(object sender)
        {
            ComboBox cb = (ComboBox) sender;

            int op=cb.SelectedIndex;
            
            var tv=this.FindControl<DockPanel>("PanelTV");
           var radio=this.FindControl<DockPanel>("PanelRadio");;
            var reproductor=this.FindControl<DockPanel>("PanelReproductorDVD");;
            var adaptador=this.FindControl<DockPanel>("PanelAdaptadorTDT");;

            switch (op)
            {
                case 0:
                    this.tipo = "tv";
                    tv.IsVisible = true;
                    adaptador.IsVisible = false;
                    radio.IsVisible = false;
                    reproductor.IsVisible = false;
                    break;
                case 1:
                    this.tipo = "radio";
                    tv.IsVisible = false;
                    adaptador.IsVisible = false;
                    radio.IsVisible = true;
                    reproductor.IsVisible = false;
                    break;
                case 2:
                    this.tipo = "reproductor";
                    tv.IsVisible = false;
                    radio.IsVisible = false;
                    reproductor.IsVisible = true;
                    adaptador.IsVisible = true;
                    break;
                case 3:
                    this.tipo="adaptador";
                    tv.IsVisible = false;
                    radio.IsVisible = false;
                    reproductor.IsVisible = false;
                    adaptador.IsVisible = true;
                    break;
                default:
                    break;
            }
        }


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }


        private string tipo;
    }
}