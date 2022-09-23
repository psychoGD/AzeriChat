using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for AddContactUC.xaml
    /// </summary>
    public partial class AddContactUC : UserControl
    {
        public ObservableCollection<user> Users { get; set; }
        public AddContactUC(ObservableCollection<user> users)
        {   
            InitializeComponent();
            Users = users;
        }
        public Image img { get; set; }
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                if (op.CheckFileExists == true)
                {
                    Image newPhoto = new Image();
                    newPhoto.Source = new BitmapImage(new Uri(op.FileName));
                    
                    img = newPhoto;
                }

            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var parent = this.Parent as Grid;
            parent.Children.Remove(this);
        }



        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            user user = new user();
            user.UserName = txtUser.Text;
            user.Phone = txtPhone.Text;
            user.UserImg = img;
            if(user.UserImg == null || user.UserImg.Source.ToString() == string.Empty)
            {
                user.UserImg = new Image();
                user.UserImg.Source = new ImageSourceConverter().ConvertFromString(@"C:\Users\Huseyn\source\repos\AzeriChat\AzeriChat\Images\defaultUser.png") as ImageSource;
            }
            
            Users.Add(user);

            var parent = this.Parent as Grid;
            parent.Children.Remove(this);
        }
    }
}
