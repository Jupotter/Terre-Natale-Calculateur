﻿using System;
using System.Linq;
using System.Windows.Data;

namespace Calculateur
{
    class SumConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            double total = values.Cast<double>().Sum();
            return total.ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
