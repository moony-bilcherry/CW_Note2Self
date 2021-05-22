using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Note2Self
{
    /// <summary>
    /// Базовый конвертер, позволяющий использование прямо в XAML
    /// </summary>
    /// <typeparam name="T">Тип этого конвертера</typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        #region Приватные свойства

        private static T _converter = null;

        #endregion

        #region Методы Markup Extension

        /// <summary>
        /// Предоставляет статичный конвертер
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter ?? (_converter = new T());
        }

        #endregion

        #region Методы конвертера

        /// <summary>
        /// Метод для конвертации одного типа в другой
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// Метод для конвертации value обратно в его исходный тип
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion
    }
}
