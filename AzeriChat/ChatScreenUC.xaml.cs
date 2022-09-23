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
    /// Interaction logic for ChatScreenUC.xaml
    /// </summary>
    public partial class ChatScreenUC : UserControl
    {
        public Image Img { get; set; }
        public string UserName { get; set; }
        public ChatScreenUC(Image image,string name)
        {
            InitializeComponent();
            this.DataContext = this;
            Img = image;
            UserName = name;
        }

        private void SendMsgBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageUC messageUC = new MessageUC(DateTime.Now.ToString(),TextBox.Text);
            MessagesStackPanel.Children.Add(messageUC);
            
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var parent = this.Parent as Grid;
            parent.Children.Remove(this);
        }
    }
}
