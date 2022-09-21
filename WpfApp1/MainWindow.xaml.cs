using System;
using System.Collections;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            lbContent.ItemsSource = GetContent();
        }

        private List<ModeView.EntryControlView> GetContent()
        {
            return new List<ModeView.EntryControlView>
            {
                new ModeView.EntryControlView()
                {
                    MyPathImage=@"C:\Users\stud.107-2\source\repos\WpfApp1\WpfApp1\UsersImage\Dragon.png",
                    NameEdnMessage="Jorno",
                    ColorBorder1="red",
                    ColorBorder2="red",
                    ColorBorder3="white",
                    ColorBorder4="red",
                    ColorBorder5="white",
                }
            };
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            MyForms.AddAccountWindow addAccountWindow = new MyForms.AddAccountWindow();
            addAccountWindow.ShowDialog();
        }
    }
}
