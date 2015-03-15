using System;
using System.Linq;
using System.Windows.Data;

namespace Calculateur
{
    class SumConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (values[0] is int)
                return values.Cast<int>().Sum().ToString();
            else if (values[0] is double)
                return values.Cast<double>().Sum().ToString();
            else
                return "Error Converting";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
