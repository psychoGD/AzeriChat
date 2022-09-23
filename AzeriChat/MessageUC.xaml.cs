using System;
using System.Collections.Generic;
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

namespace AzeriChat
{
    /// <summary>
    /// Interaction logic for MessageUC.xaml
    /// </summary>
    public partial class MessageUC : UserControl
    {
        public string Time { get; set; }
        public string Message { get; set; }
        public MessageUC( string time, string message)
        {
            InitializeComponent();
            Time = time;
            Message = message;
        }
    }
}
