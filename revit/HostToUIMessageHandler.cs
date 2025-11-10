using Microsoft.Web.WebView2.Wpf;
using Newtonsoft.Json;
using WebAecCommon;

namespace WebAecRevit;

public class HostToUIMessageHandler
{
    public HostToUIMessageHandler(WebView2 webView)
    {
        Application.actionEventHandler.Raise(
            app => app.SelectionChanged += (s, e) =>
            {
                var selectedElements = e.GetSelectedElements().ToElements(e.GetDocument());

                var message = new BridgeMessage()
                {
                    Type = "selection:changed",
                    Data = selectedElements.Select(el => el.ToCommonElement()).ToList()
                };

                webView.CoreWebView2.PostWebMessageAsJson(JsonConvert.SerializeObject(message));
            }
        );
    }
}
