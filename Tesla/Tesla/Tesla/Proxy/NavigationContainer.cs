using Exrin.Abstraction;
using Exrin.Common;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tesla.Proxy
{
    public class NavigationContainer : INavigationContainer
    {

        private NavigationPage _page = null;
        public event EventHandler<IViewNavigationArgs> OnPopped;
        private Queue<object> _argQueue = new Queue<object>();
        private AsyncLock _lock = new AsyncLock();
        public string CurrentViewKey { get; set; }
        public VisualStatus ViewStatus { get; set; } = VisualStatus.Unseen;

        public NavigationContainer(NavigationPage page)
        {
            _page = page;
            _page.Popped += _page_Popped;
        }

        private void _page_Popped(object sender, NavigationEventArgs e)
        {
            if (OnPopped != null)
            {
                var poppedPage = e.Page as IView;
                var currentPage = _page.CurrentPage as IView;
                var parameter = _argQueue.Count > 0 ? _argQueue.Dequeue() : null;
                OnPopped(this, new ViewNavigationArgs() { Parameter = parameter, CurrentView = currentPage, PoppedView = poppedPage });
            }
        }

        public void SetNavigationBar(bool isVisible, object page)
        {
            var bindableObject = page as BindableObject;
            if (bindableObject != null)
                NavigationPage.SetHasNavigationBar(bindableObject, isVisible);
        }

        public object View { get { return _page; } }

        public object CurrentView { get { return _page.CurrentPage; } }

        public bool CanGoBack()
        {
            return _page.Navigation.NavigationStack.Count > 1;
        }

        public async Task PopAsync(object parameter)
        {
            using (var releaser = await _lock.LockAsync())
            {
                _argQueue.Enqueue(parameter);
                await ThreadHelper.RunOnUIThreadAsync(async () => { await _page.PopAsync(); });
            }
        }

        public async Task PopAsync()
        {
            using (var releaser = await _lock.LockAsync())
            {
                await ThreadHelper.RunOnUIThreadAsync(async () => { await _page.PopAsync(); });
            }
        }

        public async Task PushAsync(object page)
        {
            using (var releaser = await _lock.LockAsync())
            {
                await ThreadHelper.RunOnUIThreadAsync(async () =>
                {
                    var xamarinPage = page as Page;

                    if (xamarinPage == null)
                        throw new Exception("PushAsync can not push a non Xamarin Page");

                    await _page.PushAsync(xamarinPage); // Must be run on the Main Thread
                }).ContinueWith(t =>
                {
                    if (t.Exception != null)
                        throw t.Exception.InnerException;
                });
            }
        }

        public async Task ShowDialog(IDialogOptions dialogOptions)
        {
            await ThreadHelper.RunOnUIThreadAsync(async () =>
            {
                try
                {
                    if (ViewStatus == VisualStatus.Visible)
                    {
                        await _page.DisplayAlert(dialogOptions.Title, dialogOptions.Message, "OK");
                        dialogOptions.Result = true;
                    }
                    else
                    {
                        dialogOptions.Result = false; // TODO: Should report to insights as never should be called in prod app
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message); // TODO: Change to application insights
                }
            });


        }

        public Task ClearAsync()
        {
            _page = new NavigationPage();
            return Task.FromResult(true);
        }

        public Task SilentPopAsync(int indexFromTop)
        {
            _page.Navigation.RemovePage(_page.Navigation.NavigationStack[_page.Navigation.NavigationStack.Count - indexFromTop - 1]);

            return Task.FromResult(true);
        }
    }
}
