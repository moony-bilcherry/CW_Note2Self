using System;
using System.ComponentModel;
using System.Windows;

namespace Note2Self
{
    /// <summary>
    /// Базовая attached property, чтобы удобнее использовать в WPF
    /// </summary>
    /// <typeparam name="Parent">Родительский класс который будет attached property</typeparam>
    /// <typeparam name="Property">Тип этой attached property</typeparam>
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : BaseAttachedProperty<Parent, Property>, new()
    {
        #region Публичные события

        /// <summary>
        /// Запускается когда меняется значение
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        #endregion

        #region Публичные свойства

        /// <summary>
        /// Единственный экземпляр родительского класса
        /// </summary>
        public static Parent Instance { get; private set; } = new Parent();

        #endregion

        #region Определения Attached Property

        /// <summary>
        /// Attached property для этого класса
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value", typeof(Property), typeof(BaseAttachedProperty<Parent, Property>), new UIPropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));

        /// <summary>
        /// Коллбэк событие, вызываемое, когда <see cref="ValueProperty"/> изменено
        /// </summary>
        /// <param name="d">элемент, у которого изменилось свойство</param>
        /// <param name="e">аргументы для события</param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Вызываем родительскую функцию
            Instance.OnValueChanged(d, e);

            // Прослушиваем события
            Instance.ValueChanged(d, e);
        }

        /// <summary>
        /// Получаем attached property
        /// </summary>
        /// <param name="d">Элемент, от которого получаем свойство</param>
        /// <returns></returns>
        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);

        /// <summary>
        /// Устанавливаем attached property
        /// </summary>
        /// <param name="d">Элемент, от которого берем свойство</param>
        /// <param name="value">Значение, которое засовываем в свойство</param>
        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);

        #endregion

        #region Методы событий

        /// <summary>
        /// Метод, вызываемый, когда любое attached property этого типа изменено
        /// </summary>
        /// <param name="sender">Элемент, для которого изменили это свойство</param>
        /// <param name="e">Аргументы для событияt</param>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }

        #endregion
    }
}