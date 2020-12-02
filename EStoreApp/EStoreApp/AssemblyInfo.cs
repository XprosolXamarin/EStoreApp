using Android.App;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
[assembly: ExportFont("Roboto-Regular.ttf", Alias = "ThemeFont")]
[assembly: ExportFont("Roboto-Medium.ttf", Alias = "ThemeFontMedium")]
[assembly: ExportFont("Roboto-Bold.ttf", Alias = "ThemeFontBold")]
[assembly: ExportFont("materialdesignicons-webfont.ttf", Alias = "UserIcon")]
[assembly: Application(UsesCleartextTraffic = true)]
[assembly: UsesPermission(Android.Manifest.Permission.AccessNetworkState)]
[assembly: UsesPermission(Android.Manifest.Permission.Vibrate)]