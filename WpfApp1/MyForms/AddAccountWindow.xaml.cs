using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using static System.Net.WebRequestMethods;

namespace WpfApp1.MyForms
{
    /// <summary>
    /// Логика взаимодействия для AddAccountWindow.xaml
    /// </summary>
    public partial class AddAccountWindow : Window
    {
        public AddAccountWindow()
        {
            InitializeComponent();
            this.Loaded += AddAccountWindow_Loaded;
        }

        private void AddAccountWindow_Loaded(object sender, RoutedEventArgs e)
        {
            cbImage.ItemsSource = GetImage();
        }

        private List<ModelComboBoxImageAccount> GetImage()
        {
            List<ModelComboBoxImageAccount> accounts = new List<ModelComboBoxImageAccount>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            string ddlStart = assembly.Location;
            string dirStart = System.IO.Path.GetDirectoryName(ddlStart);
            string dirImage = dirStart + "/UsersImage";
            var files = Directory.GetFiles(dirImage);
            var absolutionPathFile = files.Where(x => 
                x.ToLower().EndsWith(".png")  || 
                x.ToLower().EndsWith(".jpeg") || 
                x.ToLower().EndsWith(".jpg")).ToArray();
                                                                                                   
            foreach(var file in absolutionPathFile)
            {
                var name = System.IO.Path.GetFileName(file);
                var path = @"pack://application:,,,/UsersImage/" + name;
                var newImage = new ModelComboBoxImageAccount() { Name = name, Path = path };
                accounts.Add(newImage);
            }
            return accounts;
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            DB.MyContext myContext = new();
            try
            {
                var newAccaunt = new DB.Account();
                newAccaunt.Name = tbName.Text;
                var image = cbImage.SelectedItem as ModelComboBoxImageAccount;
                if(image != null)
                {
                    newAccaunt.PathImage = image.Name;
                }
                else
                {
                    MessageBox.Show("Выберите картинку");
                    return;
                }
                
                myContext.Account.Add(newAccaunt);
                btnAddUser.IsEnabled = false;
                myContext.SaveChanges();
                btnAddUser.IsEnabled = true;
                MessageBox.Show("Обьект добавлен в БД");
            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnAddUser.IsEnabled = true;
            }

        }
    }

    internal class ModelComboBoxImageAccount
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
