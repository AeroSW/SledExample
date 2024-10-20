using CardComponent;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CardComponent {
    /// <summary>
    /// Interaction logic for CardContainer.xaml
    /// </summary>
    [ContentProperty("Form")]
    public partial class CardContainer : UserControl, INotifyPropertyChanged {
        public DependencyProperty LabelProperty = DependencyProperty.Register(
            "Label", typeof(string), typeof(CardContainer), new PropertyMetadata(""));
        public DependencyProperty EnableAddProperty = DependencyProperty.Register(
            "EnableAdd", typeof(bool), typeof(CardContainer), new PropertyMetadata(false, OnEnableAddUpdate));
        public DependencyProperty EnableRemoveProperty = DependencyProperty.Register(
            "EnableRemove", typeof(bool), typeof(CardContainer), new PropertyMetadata(false, OnEnableRemoveUpdate));


        private string _Label = "";
        public string Label {
            get { return _Label; }
            set {
                if (_Label != value) {
                    _Label = value;
                    OnPropertyChanged(nameof(Label));
                }
            }
        }
        public bool _EnableAdd = false;
        public bool EnableAdd {
            get { return _EnableAdd; }
            set
            {
                if (_EnableAdd != value) {
                    _EnableAdd = value;
                    Debug.WriteLine($"(Enable Add: {EnableAdd}) and (DialogType is not Null: {_DialogType != null})");
                    OnPropertyChanged(nameof(EnableAdd));
                    OnPropertyChanged(nameof(IsAbleToAdd));
                }
            }
        }
        private Type? _DialogType { get; set; } = null;
        public Type? DialogType {
            get { return _DialogType; }
            set
            {
                if (_DialogType != value && value != null && value.IsAssignableTo(typeof(CardDialogWindow))) {
                    _DialogType = value;
                    Debug.WriteLine($"(Enable Add: {EnableAdd}) and (DialogType is not Null: {_DialogType != null})");
                    OnPropertyChanged(nameof(DialogType));
                    OnPropertyChanged(nameof(IsAbleToAdd));
                }
            }
        }
        public bool IsAbleToAdd { 
            get
            {
                return EnableAdd && DialogType != null;
            }
        }
        private bool _EnableRemove = false;
        public bool EnableRemove {
            get { return _EnableRemove; }
            set {
                if (_EnableRemove != value) {
                    _EnableRemove = value;
                    OnPropertyChanged(nameof(EnableRemove));
                }
            }
        }
        public ObservableCollection<Card> Cards { get; set; }

        public CardContainer() {
            InitializeComponent();
            Cards = new ObservableCollection<Card>();
            DataContext = this;
        }
        public void Add(string label, UIElement value) {
            Card card = new();
            card.mName = label;
            card.CardContent = value;

            if (EnableRemove) {
                card.EnableDelete = true;
                card.DeleteFunction = (card) => _ = Cards.Remove(card);
            }
            Cards.Add(card);
        }
        public void OpenAddModal(object sender, RoutedEventArgs e) {
            Debug.WriteLine($"Open modal function called.  Able to open dialog: {(IsAbleToAdd ? "Yes" : "No")}");
            if (IsAbleToAdd) 
            {
                #pragma warning disable CS8600, CS8604
                var window = (CardDialogWindow)Activator.CreateInstance(DialogType);
                if (window != null) {
                    window.ShowDialog();
                    if (window.Value != null) {
                        Add(window.CardLabel, window.Value);
                    }
                }
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private static void OnEnableAddUpdate(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            ((CardContainer)d).EnableRemove = (bool)e.NewValue;
        }
        private static void OnEnableRemoveUpdate(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            ((CardContainer)d).EnableRemove = (bool)e.NewValue;
        }
        #endregion
    }
}
