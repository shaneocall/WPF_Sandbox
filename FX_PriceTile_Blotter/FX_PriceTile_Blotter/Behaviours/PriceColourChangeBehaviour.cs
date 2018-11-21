using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using FX_PriceTile_Blotter.Models;

namespace FX_PriceTile_Blotter.Behaviours
{
    public class PriceColourChangeBehaviour : Behavior<TextBlock>
    {
        public static readonly DependencyProperty TradeDirectionProperty =
            DependencyProperty.Register("TradeDirection", typeof(string), typeof(PriceColourChangeBehaviour));


        public string TradeDirection
        {
            get { return (string) GetValue(TradeDirectionProperty); }
            set { SetValue(TradeDirectionProperty, value); }
        }



        protected override void OnAttached()
        {
           
            base.OnAttached();
            AssociatedObject.TextInput += OnAssociatedObjectTextChanged;
        }

        private void OnAssociatedObjectTextChanged(object sender, TextCompositionEventArgs e)
        {
            var check = e.Text;
        }




        protected override void OnDetaching()
        {
            AssociatedObject.TextInput -= OnAssociatedObjectTextChanged;
            base.OnDetaching();
        }

        //void Update()
        //{
        //    if (AssociatedObject == null) return;
        //    if (AssociatedObject.Text == InvalidValue)
        //        AssociatedObject.Foreground = InvalidForeground;
        //    else AssociatedObject.Foreground = ValidForeground;
        //}


    }
}
