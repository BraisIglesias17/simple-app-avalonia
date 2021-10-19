using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Principal;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using p2ejercicio1.core;
using p2ejercicio1.core.aparatos;
using p2ejercicio1.core.IO;
using p2ejercicio1.core.reparaciones;


namespace Avalonia.PracticaInicial.iu
{
    
    
    public partial class MainWindow : Window
    {
        private RegistroReparaciones registro;
        private XmlRegistroReparaciones toXML;
        public MainWindow()
        {
            
            
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif


            try
            {
                //this.registro = this.cargarArchivo();
                this.registro = new RegistroReparaciones();
            }
            catch (Exception exc)
            {
                new AboutWindow(exc.Message + " \n " + exc.StackTrace).Show();
                this.registro = new RegistroReparaciones();
            }

            
            var opInsertar = this.FindControl<MenuItem>("OpInsert");
            var opGuardar = this.FindControl<MenuItem>("OpGuardar");
            var opAyuda = this.FindControl<MenuItem>("OpAbout");
            var opSalir = this.FindControl<MenuItem>("OpExit");
            var dtGrid = this.FindControl<DataGrid>("DtReparaciones");
            
            //dtGrid.SelectionChanged += (_, _) => this.OnTripSelected();
            //IEnumerable<Reparacion> r = this.registro.Lista as IEnumerable<Reparacion>;
            
            
            
           opGuardar.Click += (_, _) => this.guardarArchivo(this.registro);
            opInsertar.Click += (_, _) => this.OnInsert();
            opAyuda.Click+= (_,_) => this.onAbout();
            opSalir.Click += (_,_) => this.onExit();
            
            
            dtGrid.Items = this.registro.Lista;
        }

        private void onExit()
        {
            //OpenFileDialog f = new OpenFileDialog();
            
        }

        private void OnTripSelected()
        {
            throw new NotImplementedException();
        }

        private void OnInsert()
        {
            new InsertWindow(this.registro).Show();
        }

        /*
         
        private RegistroReparaciones cargarArchivo()
        {
            this.toXML = new XmlRegistroReparaciones();
            return new RegistroReparaciones(toXML.RecuperarXML());
        }
        private RegistroReparaciones cargarArchivo(string nf)
        {
            this.toXML = new XmlRegistroReparaciones();
            return new RegistroReparaciones(toXML.RecuperarXML(nf));

        }*/
        private void guardarArchivo(RegistroReparaciones reg)
        {
            try
            {
                this.toXML = new XmlRegistroReparaciones(reg);
                toXML.GuardaXML();
            }
            catch (Exception exc)
            {
                new AboutWindow(exc.Message + " \n " + exc.StackTrace).Show();
            }
           
        }
        private void guardarArchivo(RegistroReparaciones reg,string nf)
        {
            this.toXML = new XmlRegistroReparaciones(reg);
            toXML.GuardaXML(nf);
        }
        private void onAbout()
        {
            
            string about = "Esta aplicacion permite visualizar las reparaciones existentes así como insertar nuevas";
            new AboutWindow(about).Show();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        
      
    }
}