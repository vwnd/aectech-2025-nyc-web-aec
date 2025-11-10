using System.Collections.Generic;
using System.Linq;
using Microsoft.Web.WebView2.Wpf;
using Newtonsoft.Json;
using WebAecCommon;

namespace WebAecRhino;

public class HostToUIMessageHandler
{
    public HostToUIMessageHandler(WebView2 webView)
    {
        Rhino.RhinoDoc.SelectObjects += (s, e) =>
        {
            var message = new BridgeMessage()
            {
                Type = "selection:changed",
                Data = e.RhinoObjects.Select(r => r.ToCommonElement()).ToList()
            };

            webView.CoreWebView2.PostWebMessageAsJson(JsonConvert.SerializeObject(message));
        };

        Rhino.RhinoDoc.DeselectObjects += (s, e) =>
        {
            var message = new BridgeMessage()
            {
                Type = "selection:changed",
                Data = new List<CommonElement>()
            };

            webView.CoreWebView2.PostWebMessageAsJson(JsonConvert.SerializeObject(message));
        };

        Rhino.RhinoDoc.DeselectAllObjects += (s, e) =>
        {
            var message = new BridgeMessage()
            {
                Type = "selection:changed",
                Data = new List<CommonElement>()
            };

            webView.CoreWebView2.PostWebMessageAsJson(JsonConvert.SerializeObject(message));
        };
    }
}
