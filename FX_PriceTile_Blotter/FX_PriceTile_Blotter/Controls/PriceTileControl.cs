using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FX_PriceTile_Blotter.Controls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:FX_PriceTile_Blotter.Controls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:FX_PriceTile_Blotter.Controls;assembly=FX_PriceTile_Blotter.Controls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:PriceTileControl/>
    ///
    /// </summary>
    [TemplatePart(Name = "PART_PriceBlock", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_ArrowBlock", Type = typeof(TextBlock))]
    public class PriceTileControl : Control
    {
        static PriceTileControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PriceTileControl), new FrameworkPropertyMetadata(typeof(PriceTileControl)));
        }

        public override void OnApplyTemplate()
        {
            ApplyTemplate();
            
            _redColourBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
            _greenColourBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));

        }

       
        public static readonly DependencyProperty PriceProperty = DependencyProperty.Register("Price",
            typeof(string),
            typeof(PriceTileControl),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(Target)));

        private static void Target(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PriceTileControl originator = d as PriceTileControl;
            originator?.HandlePriceChange(e);
        }


        private TextBlock _priceBlock;
        private TextBlock _arrowBlock;

        private void HandlePriceChange(DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue == null || e.NewValue == null) return;


            if (_priceBlock == null) _priceBlock = this.Template.FindName("PART_PriceBlock", this) as TextBlock;
            if (_arrowBlock == null) _arrowBlock = this.Template.FindName("PART_ArrowBlock", this) as TextBlock;

            if (Convert.ToDouble(e.OldValue) < Convert.ToDouble(e.NewValue))
            {
                if (_priceBlock != null) _priceBlock.Foreground = _greenColourBrush;
                if (_arrowBlock != null) _arrowBlock.Text = ((char) 11205).ToString();
            }
            else
            {
                if (_priceBlock != null) _priceBlock.Foreground = _redColourBrush;
                if (_arrowBlock != null) _arrowBlock.Text = ((char) 11206).ToString();
            }
        }


        private  SolidColorBrush _redColourBrush;
        private  SolidColorBrush _greenColourBrush;

        [Bindable(true)]
        public string Price
        {
            get
            {
                return (string)this.GetValue(PriceProperty);
            }
            set
            {
                this.SetValue(PriceProperty, value);
            }
        }

        public static readonly DependencyProperty TradeDirectionProperty = DependencyProperty.Register("TradeDirection",
            typeof(string),
            typeof(PriceTileControl),
            new PropertyMetadata(string.Empty));



        public string TradeDirection
        {
            get
            {
                return (string)this.GetValue(TradeDirectionProperty);
            }
            set
            {
                this.SetValue(TradeDirectionProperty, value);
            }
        }

        public static readonly DependencyProperty ExecuteTradeCommandProperty =
            DependencyProperty.Register("ExecuteTradeCommand", typeof(ICommand), typeof(PriceTileControl), new UIPropertyMetadata(null));

        public ICommand ExecuteTradeCommand
        {
            get
            {
                return (ICommand)GetValue(ExecuteTradeCommandProperty);
            }
            set
            {
                SetValue(ExecuteTradeCommandProperty, value);
            }
        }
    }
}
