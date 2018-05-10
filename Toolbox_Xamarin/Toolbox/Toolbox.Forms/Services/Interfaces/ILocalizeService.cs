using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Toolbox.Core.Forms.Services
{
    public interface ILocalizeService
    {
        CultureInfo GetCurrentCultureInfo();
    }
}
