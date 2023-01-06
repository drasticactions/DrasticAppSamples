using Carousel.UIKit;
using Foundation;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Embedding;
using UIKit;
using Carousel.Maui;

namespace Carousel.MacCatalyst;

[Register ("AppDelegate")]
public class AppDelegate : UIApplicationDelegate {
	public override UIWindow? Window {
		get;
		set;
	}
    public static MauiContext MauiContext;

    public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
	{
        ///Your normal iOS registration
                // create a new window instance based on the screen size
        Window = new UIWindow(UIScreen.MainScreen.Bounds);

        //Setup MauiBits
        var builder = MauiApp.CreateBuilder();

        //Add Maui Controls
        builder.UseMauiEmbedding<Microsoft.Maui.Controls.Application>();

        //Using comet?
        //builder.UseComet();

        //iOS/Mac need to register the Window

        builder.Services.Add(new Microsoft.Extensions.DependencyInjection.ServiceDescriptor(typeof(global::UIKit.UIWindow), Window));

        var mauiApp = builder.Build();

        //Create and save a Maui Context. This is needed for creating Platform UI
        MauiContext = new MauiContext(mauiApp.Services);

		// create a UIViewController with a single UILabel
		var vc = new MauiEmbeddingViewController(MauiContext);

		Window.RootViewController = vc;

		// make the window visible
		Window.MakeKeyAndVisible ();

		return true;
	}
}
