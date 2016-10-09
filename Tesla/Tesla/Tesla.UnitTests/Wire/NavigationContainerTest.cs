using Exrin.Abstraction;
using Exrin.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Proxy;
using Xamarin.Forms;
using Xunit;

namespace Tesla.Tests.Wire
{
	public class NavigationContainerTest
	{
		Mock<NavigationPage> _mock = null;
		private ContentPage _page = new ContentPage();
		private ContentPage _page2 = new ContentPage();

		public NavigationContainer GetNavigationContainer()
		{
			Exrin.Framework.App.Init();

			if (_mock == null)
			{
				_mock = new Moq.Mock<NavigationPage>();
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

		[Fact]
		public async Task CanGoBack()
		{
			var container = GetNavigationContainer();

			await container.PushAsync(_page);

			Assert.Equal(false, container.CanGoBack());

			await container.PushAsync(_page2);

			Assert.Equal(true, container.CanGoBack());

		}

		[Fact]
		public async Task PopAsync()
		{
			var container = GetNavigationContainer();

			await container.PushAsync(_page);
			await container.PushAsync(_page2);

			Assert.Equal(true, container.CanGoBack());

			await container.PopAsync();

			Assert.Equal(false, container.CanGoBack());

			// No exception thrown on last pop, just silent ignore.
			await container.PopAsync();

		}

		public static TheoryData<object> NullPage { get { return new TheoryData<object>() { null }; } }
		public static TheoryData<object> ContentPage { get { return new TheoryData<object>() { new ContentPage() }; } }
		public static TheoryData<object> NonPage { get { return new TheoryData<object>() { new object() }; } }


		[Theory]
		[MemberData(nameof(NullPage))]
		[MemberData(nameof(ContentPage))]
		[MemberData(nameof(NonPage))]
		public async Task PushAsync(object page)
		{
			var container = GetNavigationContainer();

			if (page == null)
				await Assert.ThrowsAsync(typeof(Exception), async () => await container.PushAsync(page));
			else if (page.GetType() != typeof(ContentPage))
				await Assert.ThrowsAsync(typeof(Exception), async () => await container.PushAsync(page));

		}

		public static TheoryData<IDialogOptions> Dialog { get { return new TheoryData<IDialogOptions>() { new DialogOptions() { Title = "Test", Message = "Message" } }; } }

		[Theory]
		[MemberData(nameof(Dialog))]
		public async Task ShowDialog(IDialogOptions dialogOptions)
		{

			var container = GetNavigationContainer();

			container.ViewStatus = VisualStatus.Hidden;
			await container.ShowDialog(dialogOptions);

			Assert.Equal(false, dialogOptions.Result);

			container.ViewStatus = VisualStatus.Visible;
			await container.ShowDialog(dialogOptions);
			Assert.Equal(true, dialogOptions.Result);

		}

	}
}
