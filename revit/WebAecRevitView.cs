using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using Newtonsoft.Json;
using WebAecCommon;


namespace WebAecRevit.Views;

public sealed class WebAecRevitView : UserControl
{
    // private readonly WebView2 webView;
    public WebAecRevitView()
    {
        var grid = new System.Windows.Controls.Grid();
        Content = grid;

        var textBlock = new TextBlock
        {
            Text = "Hello WPF World!",
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center
        };

        grid.Children.Add(textBlock);
        // webView = new WebView2()
        // {
        //     HorizontalAlignment = HorizontalAlignment.Stretch,
        //     VerticalAlignment = VerticalAlignment.Stretch
        // };

        // grid.Children.Add(webView);

        // Dispatcher.InvokeAsync(InitializeWebViewAsync);
    }

    // public async void InitializeWebViewAsync()
    // {
    //     var userDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WebAecNYC2025");

    //     // Ensure the directory exists
    //     Directory.CreateDirectory(userDataFolder);

    //     var environment = await CoreWebView2Environment.CreateAsync(userDataFolder: userDataFolder);

    //     await webView.EnsureCoreWebView2Async(environment);
    //     var settings = webView.CoreWebView2.Settings;
    //     settings.AreDevToolsEnabled = true;

    //     webView.Source = new Uri("http://localhost:5173/");

    //     new HostToUIMessageHandler(webView);

    //     webView.CoreWebView2.WebMessageReceived += (sender, args) =>
    //     {
    //         string jsonMessage = args.WebMessageAsJson;
    //         var bridgeMessage = JsonConvert.DeserializeObject<BridgeMessage>(jsonMessage);

    //         if (bridgeMessage == null) throw new Exception("Failed to deserialize message from web content.");

    //         if (bridgeMessage.Type == "create:text")
    //         {
    //             Utilities.CreateTextElement(bridgeMessage.Data as string ?? "No data provided");
    //         }
    //     };
    // }
}