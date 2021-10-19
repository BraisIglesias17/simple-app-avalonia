using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Avalonia.PracticaInicial.iu
{
    
    
    public partial class AboutWindow : Window
    {


        public AboutWindow(string mensaje):this()
        {
            var texBlock = this.FindControl<TextBlock>("AboutText");
            texBlock.Text=mensaje;

        }
        public AboutWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif


            
            
            var boton = this.FindControl<Button>("salirAyuda");
            boton.Click += (_, _) => this.Close();

        }

      
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}