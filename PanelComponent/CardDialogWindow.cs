using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace CardComponent {
    /// <summary>
    /// Interaction logic for CardDialogWindow.xaml
    /// </summary>
    public abstract class CardDialogWindow: Window, INotifyPropertyChanged {
        private string _CardLabel = "";
        private UIElement? _Value = null;
        public string CardLabel {
            get
            {
                return _CardLabel;
            }
            set
            {
                if (_CardLabel != value) {
                    _CardLabel = value;
                    OnPropertyChanged(nameof(CardLabel));
                }
            }
        }
        public UIElement? Value {
            get
            {
                return _Value;
            }
            set
            {
                if (_Value != value) {
                    _Value = value;
                    OnPropertyChanged(nameof(Value));
                }
            }
        }

        public CardDialogWindow() { }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
