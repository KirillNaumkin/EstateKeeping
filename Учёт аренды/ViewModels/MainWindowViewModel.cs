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
        #region Свойства ViewModel
        /// <summary>Заголовок окна.</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        private string _Title = "Учёт аренды";

        /// <summary>Текущий статус программы.</summary>
        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }
        private string _Status = "Программа запущена";

        /// <summary>Признак показа архивных зданий</summary>
        public bool ShowArchiveBuildings
        {
            get => _ShowArchiveBuildings;
            set => Set(ref _ShowArchiveBuildings, value);
        }
        private bool _ShowArchiveBuildings = false;

        /// <summary>Признак показа свободных помещений</summary>
        public bool ShowVacantRooms
        {
            get => _ShowVacantRooms;
            set => Set(ref _ShowVacantRooms, value);
        }
        private bool _ShowVacantRooms = false;

        /// <summary>Набор объектов (зданий и помещений) для отображения в главном окне.</summary>
        public ObservableCollection<IBuilding> Buildings
        {
            get
            {
                if (_Buildings == null) _Buildings = new ObservableCollection<IBuilding>(DataContext.GetBuildingsAsync(ShowArchiveBuildings).Result);
                return _Buildings;
            }
            set => Set(ref _Buildings, value);
        }
        private ObservableCollection<IBuilding> _Buildings;

        /// <summary>Выбранное пользователем здание; либо здание, в котором расположено выбранное помещение./// </summary>
        public IBuilding SelectedBuilding
        {
            get => _SelectedBuilding;
            set => Set(ref _SelectedBuilding, value);
        }
        private IBuilding _SelectedBuilding;

        /// <summary>Выбранное пользователем помещение./// </summary>
        public IRoom SelectedRoom
        {
            get => _SelectedRoom;
            set => Set(ref _SelectedRoom, value);
        }
        private IRoom _SelectedRoom;
        #endregion

        #region Команды и методы открытия окон
        public ICommand CloseApplicationCommand { get; }
        private bool CanCloseApplicationCommandExecuted(object p) => true;
        private void OnCloseApplicationCommandExecuted(object o) => Application.Current.Shutdown();

        public ICommand OpenBuildingCommand { get; }
        private bool CanOpenBuildingCommandExecuted(object p) => true;
        private void OnOpenBuildingCommandExecuted(object o)
        {
            var newWindow = new Views.BuildingWindow();
            OpenNewWindow(newWindow);
        }

        public ICommand OpenRoomCommand { get; }
        private bool CanOpenRoomCommandExecuted(object p) => true;
        private void OnOpenRoomCommandExecuted(object o)
        {
            var newWindow = new Views.RoomWindow();
            OpenNewWindow(newWindow);
        }

        public ICommand OpenBillingsWindowCommand { get; }
        private bool CanOpenBillingsWindowCommandExecuted(object p) => true;
        private void OnOpenBillingsWindowCommandExecuted(object o)
        {
            var newWindow = new Views.BillingsWindow();
            OpenNewWindow(newWindow);
        }

        public ICommand OpenPaymentWindowCommand { get; }
        private bool CanOpenPaymentWindowCommandExecuted(object p) => true;
        private void OnOpenPaymentWindowCommandExecuted(object o)
        {
            var newWindow = new Views.PaymentWindow();
            OpenNewWindow(newWindow);
        }
        #endregion
        
        private void OpenNewWindow(Window newWindow)
        {
            newWindow.Owner = Application.Current.MainWindow;
            newWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newWindow.ShowDialog();
        }

        public MainWindowViewModel()
        {
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecuted);
            OpenBuildingCommand = new LambdaCommand(OnOpenBuildingCommandExecuted, CanOpenBuildingCommandExecuted);
            OpenRoomCommand = new LambdaCommand(OnOpenRoomCommandExecuted, CanOpenRoomCommandExecuted);
            OpenBillingsWindowCommand = new LambdaCommand(OnOpenBillingsWindowCommandExecuted, CanOpenBillingsWindowCommandExecuted);
            OpenPaymentWindowCommand = new LambdaCommand(OnOpenPaymentWindowCommandExecuted, CanOpenPaymentWindowCommandExecuted);

        }
    }
}
