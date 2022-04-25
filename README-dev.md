# LightningChart JS x MAUI project template (for developers)

This repository was built by referencing official MAUI "Getting started" documentation. More specifically, [this page](https://docs.microsoft.com/en-us/dotnet/maui/get-started/first-app). To use LightningChart JS inside MAUI, **no extra dependencies, configurations, etc. are needed** to this getting started project.

As MAUI is still in preview, it is important to keep in mind that it can change rapidly along with the getting started template. This repository was created on 22nd April 2022 with Visual Studio 2022 17.2.0 Preview 4.0 and .NET framework 4.8.04084.

As MAUI targets desktop and mobile, there are generally 3 relevant types of testing environments: native desktop, mobile emulator and local mobile devices. LightningChart JS is based on WebGL, which is poorly supported by present day mobile emulators. Due to this, it is safe to say that **developing with mobile emulators is not supported**.

Technically, native desktop (both Windows and iOS) apps should work, but at present state the application is not working correctly in Windows at least. There are no errors, so our understanding is that this is simply due to us not understanding how to use MAUI properly in this use case.

Currently the only tested debug target where the project works in stable manner is a local Android device.

## Running the template project

- Open `LcjsMauiTemplate.sln` with [Visual Studio 2022 Preview](https://docs.microsoft.com/en-us/dotnet/maui/get-started/first-app#get-started-with-visual-studio-2022-172-preview).
    - Requires "Mobile development with .NET" workload

- Set up a local Android device.
    - https://docs.microsoft.com/en-us/dotnet/maui/android/device/setup

- Select the local device as target and run.

![Visual Studio Run Target UI](./pictures/run-target.png)

## How to use LightningChart JS in MAUI

To use LightningChart JS in MAUI, you have to use the MAUI `WebView` component which is capable of loading web applications and web pages. In theory this makes it possible to embed any web application inside MAUI.

It is also possible to communicate with the web app running within the `WebView`, see [Invoke JavaScript](https://docs.microsoft.com/en-us/dotnet/maui/user-interface/controls/webview#invoke-javascript) from MAUI documentation.

The template project showcases usage of these capabilities in two ways:

1. Loading remotely hosted web app from URL ([Interactive Examples](https://www.arction.com/lightningchart-js-interactive-examples/)).

2. Loading local web app from HTML/CSS/JS files.

Displaying remote web apps is as simple as setting a single URL:

```c#
this.webView.Source = "https://arction.github.io/lcjs-example-0010-multiChannelLineProgressive/";
```

Note, that the site might have to be secure (`https`).

To load a local web app, you have to place the HTML/CSS/JS files of the web app inside `Resources/Raw` folder and then load it like this:

```c#
string filePath = "index.html";
#if WINDOWS
var stream = await Microsoft.Maui.Essentials.FileSystem.OpenAppPackageFileAsync("Assets/" + filePath);
#else
var stream = await Microsoft.Maui.Essentials.FileSystem.OpenAppPackageFileAsync(filePath);
#endif
if (stream != null)
{
    string s = (new System.IO.StreamReader(stream)).ReadToEnd();
    this.webView.Source = new HtmlWebViewSource { Html = s, BaseUrl = @"file:///android_asset/" };
}
```

## Support

If you notice an error in the example code, please open an issue on [GitHub](https://github.com/Arction/lcjs-maui-template/issues). Official [API documentation][3] can be found on [Arction](https://www.arction.com/lightningchart-js-api-documentation) website. If the docs and other materials do not solve your problem as well as implementation help is needed, ask on [StackOverflow](https://stackoverflow.com/questions/tagged/lightningchart) (tagged lightningchart). If you think you found a bug in the LightningChart JavaScript library, please contact support@arction.com. Direct developer email support can be purchased through a [Support Plan](https://www.arction.com/support-services/) or by contacting sales@arction.com.

© Arction Ltd 2009-2022. All rights reserved.