using System;
using System.Reflection;
using Drastic.iCarousel;
using Drastic.PureLayout;

namespace Carousel.UIKit
{
    public class ExampleViewController : UIViewController
    {
        public DrasticCarousel carousel;

        public ExampleViewController()
        {
            this.carousel = new DrasticCarousel();
            this.carousel.Type = iCarouselType.Cylinder;
            this.View!.AddSubview(this.carousel);
            this.carousel.AutoPinEdgesToSuperviewEdges();
        }

        public class DrasticCarousel : iCarousel
        {
            public override nint NumberOfItems => 10;

            public DrasticCarousel()
            {
                this.DataSource = new DrasticCarouselDataSource();
            }
        }

        public class DrasticCarouselDataSource : iCarouselDataSource
        {
            private Random random;
            public DrasticCarouselDataSource()
            {
                this.random = new Random();
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
                    view = new UIImageView(new CGRect(0, 0, 500, 500));
                }

                if (view is UIImageView imageView)
                {
                    var image = random.Next(1, 8);
                    imageView.Image = UIImage.LoadFromData(NSData.FromStream(Images.GetResourceFileContent($"Images.{image}.png")));
                }

                return view;
            }
        }
    }

    public static class Images
    {
        /// <summary>
        /// Get Resource File Content via FileName.
        /// </summary>
        /// <param name="fileName">Filename.</param>
        /// <returns>Stream.</returns>
        public static Stream? GetResourceFileContent(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Carousel.UIKit." + fileName;
            if (assembly is null)
            {
                return null;
            }

            return assembly.GetManifestResourceStream(resourceName);
        }
    }
}