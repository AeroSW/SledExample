using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace SledComponent {
    /// <summary>
    /// Interaction logic for SledComponent.xaml
    /// </summary>
    /// 
    [ContentProperty("MyContent")]
    public partial class Sled : UserControl, INotifyPropertyChanged {
        public static readonly DependencyProperty MyContentProperty = DependencyProperty.Register(
            "MyContent", typeof(object), typeof(Sled));
        public object MyContent {
            get { return (object)GetValue(MyContentProperty); }
            set { SetValue(MyContentProperty, value); }
        }
        public Brush SledColor { get; set; } = new SolidColorBrush(Colors.Gold);
        public Brush EdgeColor { get; set; } = new SolidColorBrush(Colors.Gold);
        public string Label { get; set; } = "Placeholder";
        public Sled() {
            InitializeComponent();
            
            Loaded += delegate {
                TabButton.PropertyChanged += Sled_Expanded;
            };
            DataContext = this;
        }

        private void Sled_Expanded(object? sender, PropertyChangedEventArgs e) {
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e) {
        }
        #region ObjectList

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName) {
            var e = PropertyChanged;
            if (e != null && propertyName != null) {
                e.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
