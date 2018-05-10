using MvvmCross.Base;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Toolbox.Core.Forms.Rest.Implementations;
using Toolbox.Core.Forms.Services.Implementations;
using Toolbox.Core.Forms.ViewModels;

namespace Toolbox.Core.Forms
{
    public class AppStart<TViewModel> : MvxAppStart<TViewModel> where TViewModel : IMvxViewModel
    {
        private readonly IMvxNavigationService _mvxNavigationService;

        public AppStart(IMvxApplication app, IMvxNavigationService mvxNavigationService)
            : base(app, mvxNavigationService)
        {
            _mvxNavigationService = mvxNavigationService;
        }

        protected override void NavigateToFirstViewModel(object hint)
        {
            NavigationService.Navigate<LoginViewModel,LoginService>(new LoginService(new RestClient()));
        }
    }
}