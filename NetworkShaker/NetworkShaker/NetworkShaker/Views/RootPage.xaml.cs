using NetworkShaker.Models;
using NetworkShaker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetworkShaker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootPage : MasterDetailPage
    {
        public RootPage()
        {
            InitializeComponent();
        }
        private void MasterPage_Appearing(object sender, EventArgs e)
        {
            menuPages = (BindingContext as RootViewModel).AvailablePages.Select(page => (Page)Activator.CreateInstance(page.TargetType))
                                                                        .ToList();
            Detail = menuPages.First(x => x is ShakePage);
        }
        private List<Page> menuPages;

        private void listViewMasterMenu_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as RootPageMenuItem;
            if (item == null)
                return;

            Detail = menuPages.First(x => x.GetType() ==  item.TargetType);
            IsPresented = false;
        }


    }
}