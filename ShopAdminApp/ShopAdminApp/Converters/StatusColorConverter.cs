using System;
using Xamarin.Forms;

namespace ShopAdminApp.Converters
{
    public class StatusColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;

            string statusName = value.ToString();

            switch (statusName.ToUpper())
            {
                case "DRAFT":
                    return Color.Black;
                case "PENDING":
                    return Color.Blue;
                case "DELIVERED":
                    return Color.Green;
                default:
                    return Color.Black; // Default color
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
