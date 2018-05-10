using Android.App;
using Android.Content.PM;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Forms.Platforms.Android.Views;
using Toolbox.Core.Forms;
using Toolbox.Core.Forms.ViewModels;

namespace Toolbox.Forms.Droid
{
    [Activity(Label = "Toolbox.Forms", Icon = "@mipmap/icon", Theme = "@style/MainTheme",
        // MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : MvxFormsAppCompatActivity<MvxFormsAndroidSetup<App, FormsApp>, App, FormsApp, MainViewModel>
    // public class MainActivity : MvxFormsAppCompatActivity<MainViewModel>
    {
        //protected override void OnCreate(Bundle bundle)
        //{
        //    TabLayoutResource = Resource.Layout.Tabbar;
        //    ToolbarResource = Resource.Layout.Toolbar;

        //    base.OnCreate(bundle);

        //    global::Xamarin.Forms.Forms.Init(this, bundle);
        //    LoadApplication(new App());
        //}
    }
}