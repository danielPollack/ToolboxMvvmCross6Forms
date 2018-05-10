using MvvmCross.Forms.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Toolbox.Core.Forms
{

    public partial class FormsApp : Application
    {
        public FormsApp()
        {
            InitializeComponent();
        }
    }
}