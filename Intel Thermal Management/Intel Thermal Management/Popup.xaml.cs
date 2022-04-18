using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Intel_Thermal_Management
{
    /// <summary>
    /// Interaction logic for Popup.xaml
    /// </summary>
    public partial class Popup : Window
    {
        private Action callback;

        public Popup()
        {
            InitializeComponent();

            Closing += OnClosing;
            Topmost = true;
        }

        public void SetMessage(string message)
        {
            Message.Text = message;
        }

        public void SetClosingCallBack(Action callback)
        {
            this.callback = callback;
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            this.callback();
        }

        private void ButtonOkClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
