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
        /// Последняя известная док-позиция
        /// </summary>
        private WindowDockPosition _dockPosition = WindowDockPosition.Undocked;

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
        /// Есть ли у окна границы (границ нет, если окно развернуто или в док-позиции)
        /// </summary>
        public bool Borderless { get { return (_window.WindowState == WindowState.Maximized || _dockPosition != WindowDockPosition.Undocked); } }

        /// <summary>
        /// Отступ от краев окна для контента (рамочка вокруг контента)
        /// </summary>
        public int InnerContentPadding { get; set; } = 6;
        public Thickness InnerContentPaddingThickness { get { return new Thickness(InnerContentPadding); } }

        /// <summary>
        /// Минимальный рзмер окна
        /// </summary>
        public double WindowMinWidth { get; set; } = 400;
        public double WindowMinHeight { get; set; } = 400;


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
                // return _window.WindowState == WindowState.Maximized ? 0 : _outerMarginSize;
                return Borderless ? 0 : _outerMarginSize;
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
                //return _window.WindowState == WindowState.Maximized ? 0 : _windowRadius;
                return Borderless ? 0 : _windowRadius;
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
        public int TitleHeight { get; set; } = 34;
        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }

        #endregion

        #region Команды

        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MenuCommand { get; set; }

        #endregion

        #region Конструктор

        public WindowViewModel(Window window)
        {
            _window = window;

            // Прослушивать изменение размера окна
            _window.StateChanged += (sender, e) =>
            {
                // Отправляет событие всем свойствам, задействованным в изменении размера окна
                WindowResized();
            };

            // Создание команд

            MinimizeCommand = new RelayCommand(() => _window.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => _window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => _window.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(_window, GetMousePosition()));

            // Ресайзер чинит баг WindowChrome с развернутым окном и док-позициями
            var resizer = new WindowResizer(_window);

            // Следим за изменениями доков
            resizer.WindowDockChanged += (dock) =>
            {
                // Сохраняем последний док
                _dockPosition = dock;

                // Запуск событий изменения размера окна
                WindowResized();
            };
        }

        #endregion

        #region Приватные методы в помощь

        /// <summary>
        /// Получить текущее положение курсора на экране
        /// </summary>
        private Point GetMousePosition()
        {
            // позиция относительно окна
            var position = Mouse.GetPosition(_window);
            // если окно развернуто, не добавлять положение окна
            if(_window.WindowState == WindowState.Maximized)
                return new Point(position.X, position.Y);
            // положение в окне + положение окна в экране
            return new Point(position.X + _window.Left, position.Y + _window.Top);
        }

        /// <summary>
        /// Если окно меняет размер в спешл позицию (docked or maximized), этот метод обновит
        /// все нужные property changed события чтобы установить правильный внешний вид
        /// </summary>
        private void WindowResized()
        {
            // Отправляет событие всем свойствам, задействованным в изменении размера окна
            OnPropertyChanged(nameof(Borderless));
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(OuterMarginSizeThickness));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));
        }

        #endregion
    }
}
