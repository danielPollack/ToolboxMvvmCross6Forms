using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Toolbox.Core.Forms.Rest.Interfaces
{
    public interface IRestClient
    {
        Task<TResult> MakeAsyncApiCall<TResult>(string url, HttpMethod method, object data = null)
            where TResult : class;

        string MakeApiCall(string url, HttpMethod method, object data = null);



    }
}
