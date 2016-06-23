using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace NobleProg.RentBikes.WPFClient.Converters
{
    public class RomanConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var number = (int)value;
            string retVal;
            switch (number)
            {
                case 1: retVal = "I"; break;
                case 2: retVal = "II"; break;
                case 3: retVal = "III"; break;
                case 4: retVal = "IV"; break;
                default:
                    throw new NotSupportedException();
            }
            return retVal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string roman = value.ToString();
            int retVal;

            switch (roman)
            {
                case "I": retVal = 1; break;
                case "II": retVal = 2; break;
                case "III": retVal = 3; break;
                case "IV": retVal = 4; break;
                default:
                    throw new NotSupportedException();
            }
            return retVal;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
