using System;
using CoreGraphics;
using Drastic.iCarousel;
using Drastic.PureLayout;
using Foundation;
using Microsoft.Maui.Platform;
using UIKit;

namespace Carousel.Maui
{
	public class MauiEmbeddingViewController : UIViewController
	{
        public DrasticCarousel carousel;

        public MauiEmbeddingViewController(MauiContext context)
		{
            this.carousel = new DrasticCarousel(context);
            this.carousel.Type = iCarouselType.Cylinder;
            this.View!.AddSubview(this.carousel);
            this.carousel.AutoPinEdgesToSuperviewEdges();
        }

        public class DrasticCarousel : iCarousel
        {
            public override nint NumberOfItems => 10;

            public DrasticCarousel(MauiContext context)
            {
                this.DataSource = new DrasticCarouselDataSource(context);
            }
        }

        public class DrasticCarouselDataSource : iCarouselDataSource
        {
            private Random random;
            private MauiContext context;

            public DrasticCarouselDataSource(MauiContext context)
            {
                this.random = new Random();
                this.context = context;
            }
            [Export("numberOfItemsInCarousel:")]
            public nint NumberOfItemsInCarousel(iCarousel carousel)
            {
                return 10;
            }

            public override UIView CarouselWithView(iCarousel carousel, nint index, UIView? view)
            {
                if (view is null)
                {
                    var test = new TestPage();
                    view = (test.ToUIViewController(this.context)).View;
                    view.Frame = new CGRect(0, 0, 500, 500);
                }

                return view!;
            }
        }
    }
}