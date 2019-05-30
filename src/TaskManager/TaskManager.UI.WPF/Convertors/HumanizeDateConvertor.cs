using Humanizer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TaskManager.Models.DTO;

namespace TaskManager.UI.WPF.Convertors
{
    public class HumanizeDateConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is DateTime)
            {
                var date = (DateTime) value;
                //return date.Humanize(utcDate : false).Humanize();
                return date.Humanize(utcDate : false);
            }
            else if(value is TimeSpan)
            {
                var date = (TimeSpan)value;
                return date.Humanize();
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
