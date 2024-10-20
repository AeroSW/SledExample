using System;
using System.Collections.Generic;
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

namespace CardComponent
{
    /// <summary>
    /// Interaction logic for RemoveListItemButton.xaml
    /// </summary>
    public partial class AddItemButton : UserControl
    {
#pragma warning disable CS8618
        public AddItemButton()
        {
#pragma warning restore CS8618
            InitializeComponent();
            this.Foreground = new SolidColorBrush(Colors.WhiteSmoke);
            this.Background = new SolidColorBrush(Colors.Aquamarine);
            DataContext = this;
        }
        public event RoutedEventHandler Click;
        private void Button_Click(object sender, RoutedEventArgs e) {
            if (this.Click != null) {
                this.Click(this, e);
            }
        }
    }
}
