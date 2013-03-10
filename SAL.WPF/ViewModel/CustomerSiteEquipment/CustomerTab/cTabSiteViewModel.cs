using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAL.EFLib;
using System.Collections.ObjectModel;
using System.Windows;
using SAL.WPF.Command;
using SAL.WPF.View.CustomerSiteEquipment;
using System.Windows.Controls;

namespace SAL.WPF.ViewModel.CustomerSiteEquipment.CustomerTab
{
    public class cTabSiteViewModel : ViewModelBase
    {
        #region Field

        private CommandViewModel _selectedCommand;
        private CommandViewModel _addSiteCommand;

        #endregion

        #region Dependency Property

        public ObservableCollection<Site> ItemList
        {
            get { return (ObservableCollection<Site>)GetValue(ItemListProperty); }
            set { SetValue(ItemListProperty, value); }
        }

        public static readonly DependencyProperty ItemListProperty =
            DependencyProperty.Register("ItemList", typeof(ObservableCollection<Site>), typeof(cTabSiteViewModel), new UIPropertyMetadata(null));

        #endregion

        #region Command Property

        public CommandViewModel SelectedCommand
        {
            get
            {
                if (_selectedCommand == null)
                {
                    _selectedCommand = new CommandViewModel(new RelayCommand(OnSelected));
                }
                return _selectedCommand;
            }
        }

        public CommandViewModel AddSiteCommand
        {
            get
            {
                if (_addSiteCommand == null)
                {
                    _addSiteCommand = new CommandViewModel(new RelayCommand(OnAddSite), "Add Site");
                }
                return _addSiteCommand;
            }
        }

        #endregion

        #region Constructor

        public cTabSiteViewModel(ViewModelBase parent)
        {
            Parent = parent;

            Customer customer = ((CustomerViewModel)Parent.Parent).SelectedCustomer;

            ItemList = new ObservableCollection<Site>(customer.Sites);
        }

        #endregion

        #region Command Method

        private void OnSelected(object obj)
        {
            ToSiteView(obj as Site);
        }

        private void OnAddSite(object obj)
        {
            var page = new AddEditSitePage();
            page.DataContext = new AddEditSiteViewModel(Parent, new Site());
            ((CustomerRightViewModel)Parent).Tab1Page = page;
        }

        private void ToSiteView(Site site)
        {
            MainViewModel model = ((MainViewModel)Parent.Parent.Parent);

            Page page = new CustomerSiteEquipmentPage();
            page.DataContext = new SiteViewModel(model, site);
            model.CustomerSiteEquipmentPage = page;
        }

        #endregion
    }
}
