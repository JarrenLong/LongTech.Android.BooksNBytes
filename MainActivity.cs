using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Webkit;
using System;

namespace com.LongTech.Android.BooksNBytes
{
  [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
  public class MainActivity : AppCompatActivity
  {
    private WebView webView;

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.content_main);

      webView = FindViewById<WebView>(Resource.Id.webView1);
      webView.SetWebViewClient(new MyBrowser());

      string url = "https://www.booksnbytes.net/";
      webView.Settings.LoadsImagesAutomatically = true;
      webView.Settings.JavaScriptEnabled = true;
      webView.ScrollBarStyle = ScrollbarStyles.InsideOverlay;
      webView.LoadUrl(url);
    }

    public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
    {
      if (keyCode == Keycode.Back && webView.CanGoBack())
      {
        webView.GoBack();
        return true;
      }
      return base.OnKeyDown(keyCode, e);
    }

    private class MyBrowser : WebViewClient
    {
      // For API level 24 and later
      public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
      {
        view.LoadUrl(request.Url.ToString());
        return false;
      }

      // Pre-API level 24
      [Obsolete]
      public override bool ShouldOverrideUrlLoading(WebView view, string url)
      {
        view.LoadUrl(url);
        return true;
      }

      public override void OnPageStarted(WebView view, string url, Bitmap favicon)
      {
        base.OnPageStarted(view, url, favicon);
      }

      public override void OnPageFinished(WebView view, string url)
      {
        base.OnPageFinished(view, url);
      }

      [Obsolete]
      public override void OnReceivedError(WebView view, [GeneratedEnum] ClientError errorCode, string description, string failingUrl)
      {
        base.OnReceivedError(view, errorCode, description, failingUrl);
      }
    }
  }
}
