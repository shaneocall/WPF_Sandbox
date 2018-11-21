using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FX_PriceTile_Blotter.Interfaces;
using MahApps.Metro.Controls;

namespace FX_PriceTile_Blotter.Views
{
    /// <summary>
    /// Interaction logic for AppShell.xaml
    /// </summary>
    public partial class AppShell : MetroWindow, IView
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private void HamburgerMenuControl_OnItemClick(object sender, ItemClickEventArgs e)
        {
            // set the content
            this.HamburgerMenuControl.Content = e.ClickedItem;
            // close the pane
            this.HamburgerMenuControl.IsPaneOpen = false;
        }
    }
}
