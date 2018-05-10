using Acr.UserDialogs;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Toolbox.Core.Forms.Rest.Implementations;
using Toolbox.Core.Forms.Rest.Interfaces;
using Toolbox.Core.Forms.Services.Implementations;
using Toolbox.Core.Forms.Services.Interfaces;
using Toolbox.Core.Forms.ViewModels;

namespace Toolbox.Core.Forms
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes()
                .EndingWith("Client")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);
            //Mvx.RegisterType<Services.IAppSettings, Services.AppSettings>();
            //Mvx.RegisterType<IMvxJsonConverter, MvxJsonConverter>();
           
                    //Resources.AppResources.Culture = Mvx.Resolve<Services.ILocalizeService>().GetCurrentCultureInfo();
            RegisterCustomAppStart<AppStart<LoginViewModel>>();
        }
    }
}