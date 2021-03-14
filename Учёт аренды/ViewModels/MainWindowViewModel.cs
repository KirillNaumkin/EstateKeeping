using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Учёт_аренды.Commands;
using Учёт_аренды.Data;
using Учёт_аренды.Models;

namespace Учёт_аренды.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        private string _Title = "Учёт аренды";
        /// <summary>Заголовок окна.</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        /// <summary>Текущий статус программы.</summary>
        private string _Status = "Программа запущена";
        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }
        /// <summary>Выбранное пользователем здание; либо здание, в котором расположено выбранное помещение./// </summary>
        private IBuilding _SelectedBuilding;
        public IBuilding SelectedBuilding
        {
            get => _SelectedBuilding;
            set => Set(ref _SelectedBuilding, value);
        }
        /// <summary>Выбранное пользователем помещение./// </summary>
        private IRoom _SelectedRoom;
        public IRoom SelectedRoom
        {
            get => _SelectedRoom;
            set => Set(ref _SelectedRoom, value);
        }

        public ICommand CloseApplicationCommand { get; }
        private bool CanCloseApplicationCommandExecuted(object p) => true;
        private void OnCloseApplicationCommandExecuted(object o) => Application.Current.Shutdown();

        public ICommand OpenBuildingCommand { get; }
        private bool CanOpenBuildingCommandExecuted(object p) => true;
        private void OnOpenBuildingCommandExecuted(object o) => throw new NotImplementedException();

        public ObservableCollection<IBuilding> Buildings
        {
            get
            {
                return new ObservableCollection<IBuilding>(DataContext.GetBuildings().Result);
            }
        }


        public MainWindowViewModel()
        {
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecuted);
            OpenBuildingCommand = new LambdaCommand(OnOpenBuildingCommandExecuted, CanOpenBuildingCommandExecuted);
            
        }
    }
}
