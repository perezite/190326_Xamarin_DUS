using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NavigationXForms.MD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MD_DemoMaster : ContentPage
    {
        public ListView ListView;

        public MD_DemoMaster()
        {
            InitializeComponent();

            BindingContext = new MD_DemoMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MD_DemoMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MD_DemoMenuItem> MenuItems { get; set; }
            
            public MD_DemoMasterViewModel()
            {
                MenuItems = new ObservableCollection<MD_DemoMenuItem>(new[]
                {
                    new MD_DemoMenuItem(typeof(MD_DemoDetail)) { Id = 0, Title = "Page 1" },
                    new MD_DemoMenuItem(typeof(MD_DemoDetail)) { Id = 1, Title = "Page 2" },
                    new MD_DemoMenuItem(typeof(MD_DemoDetail)) { Id = 2, Title = "Page 3" },
                    new MD_DemoMenuItem(typeof(Seite2)) { Id = 3, Title = "Seite 2" },
                    new MD_DemoMenuItem(typeof(TabbedPage_Demo)) { Id = 4, Title = "TabPageRoot" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}