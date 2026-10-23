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
using System.Windows.Shapes;
using ЛР1_2_Латыпова_БАИ_24.Model;
using ЛР1_2_Латыпова_БАИ_24.ViewModel;

namespace ЛР1_2_Латыпова_БАИ_24.View
{
    /// <summary>
    /// Логика взаимодействия для WindowNewEmployee.xaml
    /// </summary>
    public partial class WindowNewEmployee : Window
    {
        // Конструктор принимает RoleViewModel, чтобы взять оттуда актуальный ListRole
        public WindowNewEmployee(RoleViewModel roleVM)
        {
            InitializeComponent();

            // Привязываем ComboBox к ОБЩЕМУ списку должностей
            CbRole.ItemsSource = roleVM.ListRole;

            Loaded += (s, e) =>
            {
                PersonDpo p = DataContext as PersonDpo;
                if (p == null) return;
                foreach (Role r in CbRole.Items)
                {
                    if (r.NameRole == p.RoleName)
                    {
                        CbRole.SelectedItem = r;
                        break;
                    }
                }
            };
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}