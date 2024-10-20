using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace SledComponent {
    /// <summary>
    /// Interaction logic for CardListContainer.xaml
    /// </summary>
    [ContentProperty("Content")]
    public partial class SledContainer : UserControl {
        DependencyProperty TransitionProperty = DependencyProperty.Register(
            "TransitionHandler", typeof(bool), typeof(SledContainer), 
            new PropertyMetadata(false, HandleTransition));

        private static void HandleTransition(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var new_value = (e.NewValue != null) ? (bool)e.NewValue : false;
            ((SledContainer)d).TransitionHandler = new_value;
        }
        private bool _TransitionHandler = false;
        public bool TransitionHandler {
            get { return _TransitionHandler; }
            set
            {
                if (_TransitionHandler != value) {
                    _TransitionHandler = value;
                }
            }
        }
        public SledContainer() {
            InitializeComponent();
            this.Width = 0;
            this.VerticalAlignment = VerticalAlignment.Stretch;
        }
    }
}
