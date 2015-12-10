using System;
using UIKit;
using System.Threading.Tasks;
using weather.Services;
using CoreGraphics;

namespace MySingleView
{
	public partial class ViewController : UIViewController
	{
		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			var label = new UILabel(new CGRect(100, 100, 400, 400));
			View.AddSubview(label);

			Task.Run(async () =>
			{
				var weather = await WeatherService.Get();

				InvokeOnMainThread ( () => {
					label.Text = weather.ToString();
					label.SizeToFit();
				});

			});
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


