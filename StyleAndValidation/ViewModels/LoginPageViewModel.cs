using StyleAndValidation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StyleAndValidation.ViewModels
{
    public class LoginPageViewModel:ViewModelBase
    {
        AppServices appServices;
        #region Fields

        string username;
        string password;
        #endregion

        #region Properties
        public string Username
        {
            get => username;
            set
            {
                if (username != value)
                {
                    username = value;
                  
                    OnPropertyChanged();
                    //בדיקה האם הכפתור צריך להיות מנוטרל או פעיל
                    var cmd = LoginCommand as Command;
                    cmd.ChangeCanExecute();
                }
            }
        }


        public string Password { get => password; set { password = value; OnPropertyChanged(); } }
        #endregion

        #region Commands
        public ICommand LoginCommand { get; protected set; }

        #endregion

        public LoginPageViewModel(AppServices service)
        {
            appServices = service;
            LoginCommand = new Command(() => { });
        }
    }
}
