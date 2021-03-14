using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Учёт_аренды.Commands;

namespace Учёт_аренды.ViewModels
{
    class BuildingWindowViewModel : ViewModelBase
    {
        public ICommand CloseWindowCommand { get; }
        private bool CanCloseWindowCommandExecuted(object p) => true;
        private void OnCloseWindowCommandExecuted(object o) => Window.GetWindow(o as DependencyObject).Close();

        public BuildingWindowViewModel()
        {
            CloseWindowCommand = new LambdaCommand(OnCloseWindowCommandExecuted, CanCloseWindowCommandExecuted);
        }
    }
}
