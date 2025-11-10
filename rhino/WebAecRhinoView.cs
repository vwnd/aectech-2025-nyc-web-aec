using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;

namespace WebAecRhino;

public class WebAecRhinoView : UserControl
{
    // private readonly WebView2 webView;
    public WebAecRhinoView()
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
    //     var messageHandler = new HostToUIMessageHandler(webView);
    // }
}