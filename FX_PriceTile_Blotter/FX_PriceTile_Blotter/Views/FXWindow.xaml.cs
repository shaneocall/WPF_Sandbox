
using System.Windows;
using System.Windows.Controls;
using FX_PriceTile_Blotter.Interfaces;

namespace FX_PriceTile_Blotter.Views
{
    /// <summary>
    /// Interaction logic for FXWindow.xaml
    /// </summary>
    public partial class FXWindow : UserControl, IView
    {
        public FXWindow(IViewModel viewModel)
        {
           DataContext = viewModel;
          InitializeComponent();
        }

        public FXWindow()
        {
            InitializeComponent();
        }
    }
}
