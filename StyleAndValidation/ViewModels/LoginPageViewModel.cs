﻿using StyleAndValidation.Services;
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
       readonly AppServices appServices;
        #region Fields

        string username;
        string password;
        bool showPassword;
        #endregion

        #region Properties
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }
        public bool ShowPassword { get => showPassword; set{ showPassword = value; OnPropertyChanged(); } }
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


        #endregion

        #region Commands
        public ICommand LoginCommand { get; protected set; }
        public ICommand RegisterCommand { get; protected set; }
        public ICommand ForgotPasswordCommand { get; protected set; }

        public ICommand ShowPasswordCommand { get; protected set; }

        #endregion

        public LoginPageViewModel(AppServices service)
        {
            appServices = service;

            LoginCommand = new Command(async() => 
            {
                await AppShell.Current.GoToAsync("Loading");
                var loading = AppShell.Current.CurrentPage.BindingContext as LoadingPageViewModel;
                bool success= await appServices.Login(Username, Password); 
                await AppShell.Current.Navigation.PopModalAsync();
                if (success) await AppShell.Current.GoToAsync("///MyPage");
            });

            RegisterCommand = new Command(async () => { await AppShell.Current.GoToAsync("Register"); });
            ForgotPasswordCommand = new Command( () => { });
            ShowPasswordCommand = new Command(() => ShowPassword = !ShowPassword);
            ShowPassword = true;
        }
    }
}
