using StyleAndValidation.Models;
using StyleAndValidation.Services;
using StyleAndValidation.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StyleAndValidation.ViewModels
{
    public class RegisterPageViewModel:ViewModelBase
    {
        #region Service
        AppServices appServices;
        #endregion

        #region Fields
        
        string username;
        string password;
        string fullName;
        string email;
        DateTime birthDate;
        #region validation messages
        bool showUserNameError;
        string userNameErrorMessage;
        #endregion
        #endregion

        #region Properties
        public string Username
        { get => username;
            set { if (username != value)
                    { 
                    username = value;
                    ValidateUserName();
                    OnPropertyChanged();
                    //בדיקה האם הכפתור צריך להיות מנוטרל או פעיל
                    var cmd = RegisterCommand as Command;
                    cmd.ChangeCanExecute();
                }
            }
        }


        public string Password { get=>password; set { password = value; OnPropertyChanged(); } }
        public string FullName { get=>fullName; set { fullName = value; OnPropertyChanged(); } }
        public string Email { get=>email; set { email = value; OnPropertyChanged(); } }

        public DateTime BirthDate { get => birthDate; set { birthDate = value; OnPropertyChanged(); } }

        #region Validation Properties
        public bool ShowUserNameError { get=>showUserNameError;  set { showUserNameError = value; OnPropertyChanged(); } }
        public string UserNameErrorMEssage { get => userNameErrorMessage; set { userNameErrorMessage = value; OnPropertyChanged(); } }
        #endregion
        
    #endregion

        
        #region Commands
        public ICommand RegisterCommand { get; protected set; }
        
        #endregion
        public RegisterPageViewModel(AppServices service)
        {
            appServices = service;
            RegisterCommand = new Command(async () => await RegisterUser(),()=>ValidateAll()) ;
        }


        private async Task RegisterUser()
        {
           User registered=new User() { BirthDate=BirthDate, Email=Email, FullName=FullName, Password=Password, Username=Username};
            #region מסך טעינה
            //await AppShell.Current.GoToAsync("Loading");
            //var loading=AppShell.Current.CurrentPage.BindingContext as LoadingPageViewModel;
            #endregion
            bool ok = await appServices.RegisterUserAsync(registered);

           if (ok)
            {
                #region סגירת מסך טעינה
                //await loading.Close();
                #endregion
                await AppShell.Current.DisplayAlert("הצלחה", "הנך מועבר.ת למסך הכניסה", "Ok");
                await AppShell.Current.GoToAsync("Login");
            }
           else
            {
                await loading.Close();
                await AppShell.Current.DisplayAlert("או ויי", "משהו לא טוב קרה", "Ok");
            }
          
        }

        #region Validation
        private bool ValidateUserName()
        {
           bool ok=(!string.IsNullOrEmpty(Username)) && (Username.Length > 3);
            switch (ok)
            {
                case false:
                //הצג הודעת שגיאה
                ShowUserNameError = true;
                UserNameErrorMEssage = "שם משתמש וסיסמה לא תקינים";
                    break;
                case true:
                    //בטל הודעת שגיאה
                ShowUserNameError = false;
                UserNameErrorMEssage = string.Empty;
                    break;

            }
           
            return ok;
        }

        

        private bool ValidateAll()
        {
            return ValidateUserName();
        }

        #endregion
    }
}
