﻿using DataLib.Models;
using System.Globalization;

namespace eCommerceClone.Converters
{
	public class StatusToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (bool)value ? 1 : 0;
		}
	}

	public class BoolToImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is bool boolValue)			
				return boolValue ? "icon_fullheart.png" : "icon_emptyheart.png";
			
			return "icon_emptyheart.png";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (bool)value ? 1 : 0;
		}
	}


	public class CurrencyToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is Currency currencylValue)
				return currencylValue.ToString();

			return string.Empty;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (bool)value ? 1 : 0;
		}
	}


	public class ByteArrayToImageSourceConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			ImageSource imageSource = null;
			if (value is byte[] imageByteArray)
				imageSource = ImageSource.FromStream(() => new MemoryStream(imageByteArray));
			return imageSource;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (bool)value ? 1 : 0;
		}
	}

	public class ImageByteListToImageListConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			IEnumerable<ImageSource> imageList = null;
			if (value is IEnumerable<byte[]> imageByteList)
				//imageList = imageByteList.Select(imageByte => new Image { Source = ImageSource.FromStream(() => new MemoryStream(imageByte)) });
				imageList = imageByteList.Select(imageByte => ImageSource.FromStream(() => new MemoryStream(imageByte)));

			return imageList;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (bool)value ? 1 : 0;
		}
	}
}
