using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace DisqusExample
{
    public sealed partial class MainPage : Page
    {
        // The Disqus shortname of the thread to load
        // TODO: Replace 'example' with your own Disqus shortname
        private const string _shortname = "example";

        // The custom identifier associated with the thread
        // TODO: Replace 'testembed' with your thread's identifier
        private const string _identifier = "testembed";

        // The URL that is associated with the thread. Should match the URL that is publicly-accessible for the article/post
        // TODO: Replace with the URL associated with the original discussion
        private const string _url = "http://example.com/path/to/content/url/";

        // The title you want saved with the thread, if we have to create it
        // TODO: Replace with your thread's preferred title
        private const string _title = "Disqus Test Embed";

        // Static-hosted template which includes this code: https://github.com/ryanvalentin/disqus-install-examples/blob/master/universal/static_template.html
        // TODO: Replace this with your own version because this resource could go missing any time.
        private const string _staticUrlBase = "http://media.disquscdn.com/appresources/mobiletemplate.html";

        // Possible paths that would be used for logging in
        private readonly List<string> _loginUrlEntryPaths = new List<string>
        {
            "/_ax/facebook/begin/",
            "/_ax/twitter/begin/",
            "/_ax/google/begin/",
            "/next/login/",
            "/profile/login/",
            "/next/register/",
        };

        private bool _isInLoginMode { get; set; }

        public MainPage()
        {
            InitializeComponent();
        }

        private void LoadDisqusButton_Click(object sender, RoutedEventArgs e)
        {
            LoadDisqusButton.Visibility = Visibility.Collapsed;
            DisqusCommandBar.Visibility = Visibility.Visible;

            LoadDisqus();
        }

        private void LoadDisqus()
        {
            Uri navigateUrl = new Uri($"{_staticUrlBase}?shortname={_shortname}&identifier={_identifier}&title={WebUtility.UrlEncode(_title)}&url={WebUtility.UrlEncode(_url)}");

            DisqusWebView.Navigate(navigateUrl);
        }

        private void DisqusWebView_NewWindowRequested(WebView sender, WebViewNewWindowRequestedEventArgs args)
        {
            // Handle the event so we don't end up in the Web Browser
            if (args.Uri.Host == "disqus.com" && _loginUrlEntryPaths.Contains(args.Uri.AbsolutePath))
            {
                // Prevent web browser from being opened
                args.Handled = true;

                // Launch the login experience here. You can either navigate to the URL in this page, or open a new WebView window
                _isInLoginMode = true;
                DisqusWebView.Navigate(args.Uri);
            }
        }

        private async void DisqusWebView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            // Handle external links by launching the web browser instead. We don't want to launch "disqus.com"
            // paths or our original static embed URL in the external browser, however.
            if (args.Uri.AbsoluteUri.Split('?')[0] == _staticUrlBase)
                return;

            if (_isInLoginMode)
            {
                System.Diagnostics.Debug.WriteLine("Navigating in login mode: " + args.Uri.ToString());
                
                if (!String.IsNullOrEmpty(args.Uri.Fragment))
                {
                    switch (args.Uri.Fragment)
                    {
                        case "#!auth%3Acancel":
                        case "#!auth%3Asuccess":
                        case "#!auth%3Afail":
                            args.Cancel = true;
                            LoadDisqus();
                            _isInLoginMode = false;
                            return;
                    }
                }
                
                // Allow anything that reaches this point to continue navigating
            }
            else
            {
                args.Cancel = true;

                await Windows.System.Launcher.LaunchUriAsync(args.Uri);
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadDisqus();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (DisqusWebView.CanGoBack)
                DisqusWebView.GoBack();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DisqusWebView.Stop();
        }
    }
}
