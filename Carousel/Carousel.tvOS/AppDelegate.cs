using Carousel.UIKit;

namespace Carousel.tvOS;

[Register ("AppDelegate")]
public class AppDelegate : UIApplicationDelegate {
	public override UIWindow? Window {
		get;
		set;
	}

	public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
	{
        this.Window = new UIWindow();

        this.Window.RootViewController = new ExampleViewController();

        this.Window.MakeKeyAndVisible();

        return true;
	}
}
