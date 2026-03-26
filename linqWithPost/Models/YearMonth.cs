using linqWithPost.Converters;
using System.ComponentModel;

namespace linqWithPost.Models
{
    [TypeConverter(typeof(YearMonthConverter))]
    public class YearMonth
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string Display => $"{Month}.{Year}";
    }

}
