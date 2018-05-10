using Android.App;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Forms.Platforms.Android.Views;
using Toolbox.Core.Forms;

namespace Toolbox.Forms.Droid
{
    [Activity(Label = "Toolbox.Forms.Splash", Theme = "@style/MainTheme",
        MainLauncher = true, NoHistory = true)]
    public class SplashScreen : MvxFormsSplashScreenAppCompatActivity<MvxFormsAndroidSetup<App, FormsApp>, App,
        FormsApp>
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
           
        }

        protected override void RunAppStart(Bundle bundle)
        {
            StartActivity(typeof(MainActivity));
            base.RunAppStart(bundle);
        }
    }
}