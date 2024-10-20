using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SledComponent {
    /// <summary>
    /// Interaction logic for SledPanel.xaml
    /// </summary>
    public delegate bool MethodInvoker(SledPanel panel);
    public partial class SledPanel : UserControl {
        public MethodInvoker DeleteFunction { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public SledPanel() {
            InitializeComponent();
            mName = "Placeholder";
            Colour = new SolidColorBrush(Colors.MediumAquamarine);
            DataContext = this;
        }

        public void ConfigurePanelEvents(object sender, EventArgs e) {
            //RemoveBtn.MouseDown += RemoveElement;
        }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private void RemoveElement(object sender, RoutedEventArgs e) {
            Debug.WriteLine("Hello, Delete!");
            DeleteFunction(this);
        }
        public string mName { get; set; }
        public Brush Colour { get; set; }
    }
}
