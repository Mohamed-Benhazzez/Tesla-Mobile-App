using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Wire;
using Xamarin.Forms;
using Xunit;

namespace Tesla.Tests.Wire
{
    public class NavigationContainerTest
    {
		Mock<NavigationPage> _mock = null;
			
		public NavigationContainer GetNavigationContainer()
		{
			if (_mock == null)
			{
				_mock = new Moq.Mock<NavigationPage>();
				//_mock.Setup(x=>x.Se)
			}

			return new NavigationContainer(_mock.Object);
		}

		[Fact]
		public void SetNavigationBar()
		{
			var b = new ContentPage();
			var container = GetNavigationContainer();
			container.SetNavigationBar(true, b);

			Assert.Equal(true, NavigationPage.GetHasNavigationBar(b));

			container.SetNavigationBar(false, b);

			Assert.Equal(false, NavigationPage.GetHasNavigationBar(b));
		}

		//public bool CanGoBack()
		//{
		//	return _page.Navigation.NavigationStack.Count > 1;
		//}

		//public async Task PopAsync(object parameter)
		//{
		//	using (var releaser = await _lock.LockAsync())
		//	{
		//		_argQueue.Enqueue(parameter);
		//		await _page.PopAsync();
		//	}
		//}

		//public async Task PopAsync()
		//{
		//	using (var releaser = await _lock.LockAsync())
		//	{
		//		await _page.PopAsync();
		//	}
		//}

		//public async Task PushAsync(object page)
		//{
		//	using (var releaser = await _lock.LockAsync())
		//	{
		//		await ThreadHelper.RunOnUIThreadAsync(async () =>
		//		{
		//			var xamarinPage = page as Page;

		//			if (xamarinPage == null)
		//				throw new Exception("PushAsync can not push a non Xamarin Page");

		//			await _page.PushAsync(xamarinPage); // Must be run on the Main Thread
		//		});
		//	}
		//}

		//public async Task ShowDialog(IDialogOptions dialogOptions)
		//{
		//	await ThreadHelper.RunOnUIThreadAsync(async () =>
		//	{
		//		try
		//		{
		//			if (ViewStatus == VisualStatus.Visible)
		//				await _page.DisplayAlert(dialogOptions.Title, dialogOptions.Message, "OK");
		//			else
		//				await Task.Delay(0); //TODO: Should log to insights. Should never be calling a DisplayAlert on a non-viewable stack
		//		}
		//		catch (Exception ex)
		//		{
		//			Debug.WriteLine(ex.Message); // TODO: Change to application insights
		//		}
		//	});
		//}


	}
}
