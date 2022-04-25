namespace LcjsMauiTemplate;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		SetWebView();
	}

	async Task SetWebView()
	{
		// First display local HTML/JS application
		string filePath = "index.html";
#if WINDOWS
        var stream = await Microsoft.Maui.Storage.FileSystem.OpenAppPackageFileAsync(filePath);
		if (stream != null)
		{
			string s = (new System.IO.StreamReader(stream)).ReadToEnd();
			this.webView1.Source = new HtmlWebViewSource { Html = s };
		}
#else
		var stream = await Microsoft.Maui.Storage.FileSystem.OpenAppPackageFileAsync(filePath);
		if (stream != null)
		{
			string s = (new System.IO.StreamReader(stream)).ReadToEnd();
			this.webView1.Source = new HtmlWebViewSource { Html = s, BaseUrl = @"file:///android_asset/" };
		}
#endif
		await Task.Delay(20000);

		// Afterwards scroll through Interactive Examples gallery
		string[] sources = {
			"https://arction.github.io/lcjs-example-0913-surfaceScrollingGrid/",
			"https://arction.github.io/lcjs-example-0032-logOHLC/",
			"https://arction.github.io/lcjs-example-0015-confidenceEllipseXY/",
			"https://arction.github.io/lcjs-example-1110-geoChartUsaTemperature/",
			"https://arction.github.io/lcjs-example-0910-3dLiDARPark/",
			"https://arction.github.io/lcjs-example-0010-multiChannelLineProgressive/",
			"https://arction.github.io/lcjs-example-0305-racingbars/",
			"https://arction.github.io/lcjs-example-1002-polarEMFieldStrength/"
		};
		int iSource = 0;
		while (true)
		{
			this.webView1.Source = sources[iSource];
			iSource++;
			iSource = iSource % sources.Length;
			await Task.Delay(10000);
		}
	}
}

