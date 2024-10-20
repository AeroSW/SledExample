using CardComponent;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace CanvasComponent {
    /// <summary>
    /// Interaction logic for SplatForm.xaml
    /// </summary>
    public partial class SplatForm : CardDialogWindow {
        public Color _MyColor { get; set; } = Colors.Red;
        public Color MyColor {
            get
            {
                return _MyColor;
            }
            set
            {
                if (_MyColor != value)
                {
                    _MyColor = value;
                    OnPropertyChanged(nameof(MyColor));
                }
            }
        }
        public SplatForm() : base() {
            InitializeComponent();
            base.DataContext = this;
        }

        private void Save_Click(object sender, RoutedEventArgs e) {
            SolidColorBrush scb = new(MyColor);
            base.Value = new Splat() { MyColour = scb };
            base.DialogResult = true;
        }

        #region OnNotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
