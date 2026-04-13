using Microsoft.Maui.Controls;

namespace GaussSystemSolver;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        
        // Brave attempt to fight white screen during initialization
        blazorWebView.BlazorWebViewInitialized += (sender, e) =>
        {
        #if WINDOWS
            e.WebView.DefaultBackgroundColor = Microsoft.UI.ColorHelper.FromArgb(255, 28, 26, 24);
        #endif
        };
    }
}