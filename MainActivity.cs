using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace com.LongTech.Android.BooksNBytes
{
  [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
  public class MainActivity : AppCompatActivity
  {
    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.content_main);

      var wv = FindViewById<WebView>(Resource.Id.webView1);
      wv.SetWebViewClient(new MyBrowser());

      string url = "https://www.booksnbytes.net/";
      wv.Settings.LoadsImagesAutomatically = true;
      wv.Settings.JavaScriptEnabled = true;
      wv.ScrollBarStyle = ScrollbarStyles.InsideOverlay;
      wv.LoadUrl(url);
    }

    private class MyBrowser : WebViewClient
    {
      public override bool ShouldOverrideUrlLoading(WebView view, string url)
      {
        view.LoadUrl(url);
        return true;
      }
    }
  }
}
