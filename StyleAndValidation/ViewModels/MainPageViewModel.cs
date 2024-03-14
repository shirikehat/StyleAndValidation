using StyleAndValidation.Services;
using StyleAndValidation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StyleAndValidation.ViewModels
{
    public class MainPageViewModel:ViewModelBase
    {
      

        public ICommand LoginCommand { get; protected set; }
        public ICommand RegisterCommand {  get; protected set; }    
        public MainPageViewModel()
        {
            
            LoginCommand = new Command(async () => await AppShell.Current.GoToAsync("Login"));
            RegisterCommand = new Command(async () => await AppShell.Current.GoToAsync("Register"));

        }
    }
}
