using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace FX_PriceTile_Blotter.Converters
{
    public class BrushColourConveter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var exception = new Exception("Cannot resolve colour!");

            var combinedColor = new Color();

            foreach (var value in values)
            {
                if (value == null || string.IsNullOrEmpty(value.ToString())) throw exception;

                var color = (Color) ColorConverter.ConvertFromString(value.ToString());

                combinedColor = Color.Add(combinedColor, color);
            }

            if (targetType == typeof(Color))
            {
                return combinedColor;
            }

            if (targetType == typeof(Brush))
            {
                return new SolidColorBrush(combinedColor);
            }

            throw exception;
        }



        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        //public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        //{
        //    var exception = new Exception("Cannot resolve colour!");

        //    var combinedColor = new Color();


        //    if (value == null || string.IsNullOrEmpty(value.ToString())) throw exception;

        //    var color = (Color)ColorConverter.ConvertFromString(value.ToString());

        //    combinedColor = color;


        //    if (targetType == typeof(Color))
        //    {
        //        return combinedColor;
        //    }

        //    if (targetType == typeof(Brush))
        //    {
        //        return new SolidColorBrush(combinedColor);
        //    }

        //    throw exception;
        //}

        //public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
