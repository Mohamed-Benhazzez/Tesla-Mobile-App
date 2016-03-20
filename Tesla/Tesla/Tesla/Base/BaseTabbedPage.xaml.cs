using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exrin.Abstraction;
using Xamarin.Forms;

namespace Tesla.Base
{
    public partial class BaseTabbedPage : TabbedPage, IMultiPage
    {
        public BaseTabbedPage()
        {
            InitializeComponent();
        }

        public IList<IPage> Pages
        {
            get
            {
                var children = new List<IPage>();

                foreach (var page in this.Children)
                    if (page is IPage)
                        children.Add(page as IPage);

                return children;

            }
        }



    }
}
