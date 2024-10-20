using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace SledComponent {
    /// <summary>
    /// Interaction logic for SidePanelTab.xaml
    /// </summary>
    public partial class SledTab : UserControl, INotifyPropertyChanged {
        public DependencyProperty ShowPanelProperty = DependencyProperty.Register("ShowPanel",
            typeof(bool), typeof(SledTab), new PropertyMetadata(false, PanelToggle));
        public DependencyProperty LabelProperty = DependencyProperty.Register("Label",
            typeof(string), typeof(SledTab), new PropertyMetadata("Placeholder", LabelChange));
        public DependencyProperty StrokeColorProperty = DependencyProperty.Register("StrokeColor",
            typeof(Brush), typeof(SledTab), new PropertyMetadata(new SolidColorBrush(Colors.Gold), StrokeChange));
        public DependencyProperty FillColorProperty = DependencyProperty.Register("FillColor",
            typeof(Brush), typeof(SledTab), new PropertyMetadata(new SolidColorBrush(Colors.Gold), FillChange));

        private bool _ShowPanel = false;
        private Brush _StrokeColor = new SolidColorBrush(Colors.Gold);
        public Brush StrokeColor 
        {
            get
            {
                return _StrokeColor;
            }
            set {
                if (value != _StrokeColor) {
                    _StrokeColor = value;
                    OnPropertyChange(nameof(StrokeColor));
                }
            }
        }
        private Brush _FillColor = new SolidColorBrush(Colors.Gold);
        public Brush FillColor {
            get {
                return _FillColor;
            } set {
                if (value != _FillColor) {
                    _FillColor = value;
                    OnPropertyChange(nameof(FillColor));
                }
            }
        }
        private string _Label = "Placeholder";
        public string Label { 
            get
            {
                return _Label;
            }
            set
            {
                if (value != _Label) {
                    _Label = value;
                    OnPropertyChange(nameof(Label));
                }
            }
        }
        public Brush LabelColor { get; set; } = new SolidColorBrush(Colors.Black);
        public bool ShowPanel {
            get {
                return _ShowPanel;
            } set {
                if (_ShowPanel != value) {
                    _ShowPanel = value;
                    OnPropertyChange("ShowPanel");
                }
            } 
        }
        public SledTab() {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private static void PanelToggle(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            ((SledTab)d).ShowPanel = (bool)e.NewValue;
        }
        private static void StrokeChange(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            ((SledTab)d).StrokeColor = (Brush)e.NewValue;
        }
        private static void FillChange(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            ((SledTab)d).FillColor = (Brush)e.NewValue;
        }
        private static void LabelChange(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            ((SledTab)d).Label = (string)e.NewValue;
        }

        private void OnPropertyChange(String propertyName) {
            PropertyChangedEventHandler? handler = PropertyChanged;
            if (handler != null) {
                var args = new PropertyChangedEventArgs(propertyName);
                handler(this, args);
            }
        }

        private void SledTabButton_Loaded(object sender, RoutedEventArgs e) {
            PropertyChanged += SidePanelTab_PropertyChanged;
        }

        private void SidePanelTab_PropertyChanged(object? sender, PropertyChangedEventArgs e) {
            if (e.PropertyName == "ShowPanel") {
                Debug.WriteLine($"Button Toggled: {ShowPanel}");
            }
        }
    }
}
