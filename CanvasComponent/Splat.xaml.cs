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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CanvasComponent {
    /// <summary>
    /// Interaction logic for Splat.xaml
    /// </summary>
    public partial class Splat : UserControl, INotifyPropertyChanged {
        public SolidColorBrush _MyColour = Brushes.BlueViolet;
        public SolidColorBrush MyColour {
            get { return _MyColour; }
            set
            {
                if (_MyColour != value) {
                    _MyColour = value;
                    OnPropertyChanged(nameof(MyColour));
                }
            }
        }
        public Splat() {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
