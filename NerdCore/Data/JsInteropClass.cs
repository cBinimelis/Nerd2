using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdCore.Data
{
    public class JsInteropClass
    {
        private readonly IJSRuntime _jsRuntime;

        public JsInteropClass(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public ValueTask<string> TickerChanged(string data)
        {
            return _jsRuntime.InvokeAsync<string>(
                "handleTickerChanged");
        }
    }
}
