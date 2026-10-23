using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ЛР1_2_Латыпова_БАИ_24.Helper;
using ЛР1_2_Латыпова_БАИ_24.View;

namespace ЛР1_2_Латыпова_БАИ_24.ViewModel
{
    public class MainWindowViewModel
    {
        // RoleVM создаётся один раз и передаётся в PersonVM
        public RoleViewModel RoleVM { get; set; }
        public PersonViewModel PersonVM { get; set; }

        public MainWindowViewModel()
        {
            // создаем RoleVM один раз на все приложение
            RoleVM = new RoleViewModel();
            // передаем RoleVM внутрь PersonVM, чтобы они были связаны
            PersonVM = new PersonViewModel(RoleVM);
        }

        private RelayCommand openEmployee;
        public RelayCommand OpenEmployee
        {
            get
            {
                return openEmployee ??
                (openEmployee = new RelayCommand(obj =>
                {
                    WindowEmployee wnEmployee = new WindowEmployee
                    {
                        Title = "Сотрудники"
                    };
                    wnEmployee.DataContext = PersonVM;
                    wnEmployee.ShowDialog();
                }));
            }
        }

        private RelayCommand openRole;
        public RelayCommand OpenRole
        {
            get
            {
                return openRole ??
                (openRole = new RelayCommand(obj =>
                {
                    WindowRole wnRole = new WindowRole
                    {
                        Title = "Должности"
                    };
                    wnRole.DataContext = RoleVM;
                    wnRole.ShowDialog();
                }));
            }
        }

        private RelayCommand exitApp;
        public RelayCommand ExitApp
        {
            get
            {
                return exitApp ??
                (exitApp = new RelayCommand(obj =>
                {
                    Application.Current.Shutdown();
                }));
            }
        }
    }
}
