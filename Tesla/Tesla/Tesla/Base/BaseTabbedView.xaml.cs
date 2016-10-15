namespace Tesla.Base
{
    using Exrin.Abstraction;
    using System;
    using System.Collections.Generic;
    using Xamarin.Forms;

    public partial class BaseTabbedView : TabbedPage, IMultiView
    {
        public BaseTabbedView()
        {
            InitializeComponent();          
        }

        public IList<IView> Views
        {
            get
            {
                var children = new List<IView>();

                foreach (var page in this.Children)
                    if (page is IView)
                        children.Add(page as IView);

                return children;

            }
        }

        protected override bool OnBackButtonPressed()
        {
            return ((IView)this).OnBackButtonPressed();
        }

        Func<bool> IView.OnBackButtonPressed
        { get; set; }
    }
}
