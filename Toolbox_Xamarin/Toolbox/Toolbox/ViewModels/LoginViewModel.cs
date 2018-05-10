using MvvmCross.ViewModels;

namespace Toolbox.Forms.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        private string _password;
        private string _userName;

        public string UserName
        {
            get => _userName;
            set
            {
                SetProperty(ref _userName, value);
                RaisePropertyChanged(() => UserName);
            }
        }

        public string Password
        {
            get => _userName;
            set
            {
                SetProperty(ref _userName, value);
                RaisePropertyChanged(() => UserName);
            }
        }
    }

    public class MainViewModel : MvxViewModel
    {
    }
}