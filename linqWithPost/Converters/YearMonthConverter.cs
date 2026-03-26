using linqWithPost.Models;
using System.ComponentModel;
using System.Globalization;

namespace linqWithPost.Converters
{
    public class YearMonthConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string strValue)
            {
                var parts = strValue.Split('.');
                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int month) &&
                    int.TryParse(parts[1], out int year) &&
                    month >= 1 && month <= 12 && year > 0)
                {
                    return new YearMonth { Month = month, Year = year };
                }
            }

            return null;
        }
    }
}
