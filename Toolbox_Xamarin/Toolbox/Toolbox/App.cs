using MvvmCross.ViewModels;
using Toolbox.Forms.Core.ViewModels;

namespace Toolbox.Forms.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<LoginViewModel>();
        }
    }
}