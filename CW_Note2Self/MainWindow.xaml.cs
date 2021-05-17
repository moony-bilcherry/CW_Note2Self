using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq.Expressions;


namespace CW_Note2Self
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public List<ICalendarEvent> _events;
        public List<ICalendarEvent> Events
        {
            get { return _events; }
            set
            {
                if (_events != value)
                {
                    _events = value;
                    OnPropertyChanged(() => Events);

                    // redraw days with events when Events property changes
                    Calendar.DrawDays();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;



        public MainWindow()
        {
            InitializeComponent();

            // set date of first example event to +- middle of month
            DateTime startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 15);

            // add example events
            Events = new List<ICalendarEvent>();
            Events.Add(new MyCustomEvent() { DateFrom = DateTime.Now, DateTo = DateTime.Now.AddDays(2), Label = "Event 1" });
            Events.Add(new MyCustomEvent() { DateFrom = startDate.AddDays(2), DateTo = startDate.AddDays(5), Label = "Overlapping event 2" });
            //Events.Add(new MyCustomEvent() { DateFrom = startDate.AddDays(4), DateTo = startDate.AddDays(6), Label = "Overlapping event 3" });
            //Events.Add(new MyCustomEvent() { DateFrom = startDate.AddDays(7), DateTo = startDate.AddDays(8), Label = "Event 4" });

            // draw days with events calendar
            Calendar.DrawDays();

            // subscribe to double cliked event
            Calendar.CalendarEventDoubleClickedEvent += Calendar_CalendarEventDoubleClickedEvent;
        }
    }
}
