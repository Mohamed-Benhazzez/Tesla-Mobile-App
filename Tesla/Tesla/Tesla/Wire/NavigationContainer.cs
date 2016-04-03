using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tesla.Wire
{
    public class NavigationContainer : INavigationPage
    {

        private readonly NavigationPage _page = null;
        public event EventHandler<IPageNavigationArgs> OnPopped;
        private Queue<object> _argQueue = new Queue<object>();
        private AsyncLock _lock = new AsyncLock();
        public string CurrentPageKey { get; set; }

        public NavigationContainer(NavigationPage page)
        {
            _page = page;
            _page.Popped += _page_Popped;
        }

        private void _page_Popped(object sender, NavigationEventArgs e)
        {
            if (OnPopped != null)
            {
                var poppedPage = e.Page as IPage;
                var currentPage = _page.CurrentPage as IPage;
                var parameter = _argQueue.Count > 0 ? _argQueue.Dequeue() : null;
                OnPopped(this, new PageNavigationArgs() { Parameter = parameter, CurrentPage = currentPage, PoppedPage = poppedPage });

            }
        }

        public void SetNavigationBar(bool isVisible, object page)
        {
            var bindableObject = page as BindableObject;
            if (bindableObject != null)
                NavigationPage.SetHasNavigationBar(bindableObject, isVisible);
        }

        public object Page { get { return _page; } }

        public bool CanGoBack()
        {
            return _page.Navigation.NavigationStack.Count > 1;
        }

        public async Task PopAsync(object parameter)
        {
            using (var releaser = await _lock.LockAsync())
            {
                _argQueue.Enqueue(parameter);
                await _page.PopAsync();
            }
        }

        public async Task PopAsync()
        {
            using (var releaser = await _lock.LockAsync())
            {
                await _page.PopAsync();
            }
        }

        public async Task PushAsync(object page)
        {
            await ThreadHelper.RunOnUIThreadAsync(async () =>
            {
                var xamarinPage = page as Page;

                if (xamarinPage == null)
                    throw new Exception("PushAsync can not push a non Xamarin Page");

                await _page.PushAsync(xamarinPage); // Must be run on the Main Thread
            });
        }
    }
}
