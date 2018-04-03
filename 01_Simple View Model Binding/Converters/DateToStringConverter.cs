using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MVVMSamples.Converters
{
    [ValueConversion(typeof(DateTime), typeof(string))]
    public class DateToStringConverter : IValueConverter
    {
        public static DateToStringConverter Instance { get; private set; }

        static DateToStringConverter()
        {
            Instance = new DateToStringConverter();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "";

            DateTime _date = (DateTime)value;

            return _date.ToShortDateString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
