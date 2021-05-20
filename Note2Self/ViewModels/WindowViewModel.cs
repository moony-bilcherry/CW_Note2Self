using Note2Self.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Note2Self.ViewModels
{
    public class WindowViewModel : BaseViewModel
    {
        #region Приватные поля

        private Window _window;

        /// <summary>
        /// Марджин вокруг окна для создания тени
        /// </summary>
        private int _outerMarginSize = 10;

        /// <summary>
        /// Радиус для закругления углов окна
        /// </summary>
        private int _windowRadius = 10;

        #endregion

        #region Публичные свойства
        /// <summary>
        /// Расстояние, с которого можно изменять размер окна
        /// </summary>
        public int ResizeBorder { get; set; } = 6;
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        /// <summary>
        /// Марджин вокруг окна для создания тени
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                return _window.WindowState == WindowState.Maximized ? 0 : _outerMarginSize;
            }
            set
            {
                _outerMarginSize = value;
            }
        }
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// Радиус для закругления углов окна
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return _window.WindowState == WindowState.Maximized ? 0 : _windowRadius;
            }
            set
            {
                _windowRadius = value;
            }
        }
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        public string Test { get; set; } = "My string";

        /// <summary>
        /// Высота полоски заголовка окна
        /// </summary>
        public int TitleHeight { get; set; } = 40;
        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }

        #endregion

        #region Команды

        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MenuCommand { get; set; }

        /// <summary>
        /// Создание команд
        /// </summary>
        /// <param name="window"></param>
        

        #endregion

        #region Конструктор

        public WindowViewModel(Window window)
        {
            _window = window;

            // Прослушивать изменение размера окна
            _window.StateChanged += (sender, e) =>
            {
                // Отправляет событие всем свойствам, задействованным в изменении размера окна
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            // Создание команд

            MinimizeCommand = new RelayCommand(() => _window.WindowState = WindowState.Minimized);
        }

        #endregion
    }
}
