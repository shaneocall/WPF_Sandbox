using System;

namespace FX_PriceTile_Blotter
{
    /// <summary>
    /// Startup class for the  application
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        [STAThread]
        public static void Main(string[] args)
        {
            App app = new App(args);
            app.InitializeComponent();
            app.Run();
            
        }

    }
}

