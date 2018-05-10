using System.Collections.Generic;
using Acr.UserDialogs;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Toolbox.Core.Forms.Services;
using Toolbox.Core.Forms.Services.Implementations;
using Toolbox.Core.Forms.Services.Interfaces;

namespace Toolbox.Core.Forms.ViewModels
{
    public class LoginViewModel : MvxViewModel<LoginService>
    {
        private readonly ILocalizeService _localizeService;
        private ILoginService _loginService;
        private readonly IMvxNavigationService _navigationService;
        private string _password;
        private IMvxCommand _loginCommand;
        private string _username;
        private readonly IUserDialogs _userDialogs;


        public LoginViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
          //  _loginService = loginService;
            //bool t = Mvx.TryResolve<ILoginService>(out _loginService);
        }

        public override void Prepare(LoginService parameter)
        {
            // receive and store the parameter here
            _loginService = parameter;
        }
        public string Username
        {
            get => _username;

            set
            {
                SetProperty(ref _username, value);
                RaisePropertyChanged(() => Username);
            }
        }

        public string Password
        {
            get => _password;

            set
            {
                SetProperty(ref _password, value);
                RaisePropertyChanged(() => Password);
            }
        }

        private void AttemptLogin()
        {
            if (_loginService.Login(Username, Password))
            {
                _navigationService.Navigate<DashboardViewModel>();
                // await _navigationService.Navigate<MainViewModel, Dictionary<string, string>>(;
            }
            else
            {
                // _dialogService.Alert("We were unable to log you in!", "Login Failed", "OK");
            }
        }

        public virtual IMvxCommand LoginCommand
        {
            get
            {
                _loginCommand = _loginCommand ?? new MvxCommand(AttemptLogin, CanExecuteLogin);
                return _loginCommand;

            }
        }

        /// <summary>
        /// Determines whether this instance [can execute login].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can execute login]; otherwise, <c>false</c>.
        /// </returns>
        private bool CanExecuteLogin()
        {
            return true;
            //return (!string.IsNullOrEmpty(Username) || !string.IsNullOrWhiteSpace(Username))
            //       && (!string.IsNullOrEmpty(Password) || !string.IsNullOrWhiteSpace(Password));
        }
    }

    //This Class is necessary as a workaround for some broken functionality in the mvvmcross framework
    public class MainViewModel : MvxViewModel
    {
    }
}