using CardComponent;
using SledComponent;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace CanvasComponent {
    /// <summary>
    /// Interaction logic for CanvasComponent.xaml
    /// </summary>
    public partial class MyCanvas : UserControl {
        public MyCanvas() {
            InitializeComponent();
        }

        private void CanvasComponentLoaded(object sender, RoutedEventArgs e) {
            var content = this.MySledContainer.MyContent;
            var card_container = (CardContainer)content;
            card_container.DialogType = typeof(SplatForm);
        }
    }
}
