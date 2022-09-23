using System;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using System.Text;

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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();

        public ObservableCollection<user> Users { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Users = new ObservableCollection<user>();

            //Add Default User
            user user = new user();
            user.UserName = "Jake";
            user.Phone = "+112 987 1265 34";
            user.UserImg = new Image();
            user.UserImg.Source = new ImageSourceConverter().ConvertFromString(@"C:\Users\Huseyn\source\repos\AzeriChat\AzeriChat\Images\download.jpg") as ImageSource;
            Users.Add(user);

            //Clock
            Timer.Tick += new EventHandler(Timer_Click);

            Timer.Interval = new TimeSpan(0, 0, 0);

            Timer.Start();
            
        }
        private void Timer_Click(object sender, EventArgs e)

        {

            DateTime d;

            d = DateTime.Now;

            ClockLbl.Text = d.Hour + " : " + d.Minute;

        }


        private void AddContactBtn_Click(object sender, RoutedEventArgs e)
        {
            AddContactUC addContactUC = new AddContactUC(Users);
            MainGrid.Children.Add(addContactUC);
        }



        private void MainListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            user user = (user)MainListBox.SelectedItem;
            ChatScreenUC chatScreenUC = new ChatScreenUC(user.UserImg, user.UserName);

            MainGrid.Children.Add(chatScreenUC);
        }
    }
}
