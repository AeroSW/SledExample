using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace CardComponent {
    /// <summary>
    /// Interaction logic for SledPanel.xaml
    /// </summary>
    public delegate bool MethodInvoker(Card panel);
    [ContentProperty("MyContent")]
    public partial class Card : UserControl, INotifyPropertyChanged {
        private MethodInvoker? _DeleteFunction { get; set; } = null;
        public MethodInvoker? DeleteFunction {
            get { return _DeleteFunction; }
            set {
                if (_DeleteFunction != value) {
                    _DeleteFunction = value;
                    OnPropertyChanged(nameof(DeleteFunction));
                    OnPropertyChanged(nameof(AbleToDelete));
                }
            }
        }
        private bool _EnableDelete = false;
        public bool EnableDelete {
            get { return _EnableDelete; }
            set {
                if (_EnableDelete != value) 
                {
                    _EnableDelete = value;
                    OnPropertyChanged(nameof(EnableDelete));
                    OnPropertyChanged(nameof(AbleToDelete));
                }
            }
        }
        public bool AbleToDelete {
            get
            {
                return EnableDelete && DeleteFunction != null;
            }
        }
        public UIElement? _MyContent { get; set; } = null;
        public UIElement? CardContent {
            get
            {
                return _MyContent;
            }
            set
            {
                if (_MyContent != value) {
                    _MyContent = value;
                    OnPropertyChanged(nameof(CardContent));
                }
            }
        }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Card() {
            InitializeComponent();
            mName = "Placeholder";
            Colour = new SolidColorBrush(Colors.MediumAquamarine);
            DataContext = this;
        }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private void RemoveElement(object sender, RoutedEventArgs e) {
            Debug.WriteLine("Hello World");
            if (EnableDelete && DeleteFunction != null) {
                DeleteFunction(this);
            }
        }
        public string mName { get; set; }
        public Brush Colour { get; set; }

    #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string property_name) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(property_name));
            }
        }

    #endregion
    }
}
