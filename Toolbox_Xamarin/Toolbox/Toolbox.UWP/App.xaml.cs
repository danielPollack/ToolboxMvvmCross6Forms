using MvvmCross.Forms.Platforms.Uap.Core;
using MvvmCross.Forms.Platforms.Uap.Views;
using Toolbox.Forms;

namespace Toolbox.UWP
{
    /// <summary>
    ///     Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    internal sealed partial class App : ProxyMvxApplication
    {
        public App()
        {
            InitializeComponent();
        }
    }

    abstract class ProxyMvxApplication : MvxWindowsApplication<MvxFormsWindowsSetup<Forms.App, FormsApp>, Forms.App, FormsApp, MainPage>
    {
    }
}