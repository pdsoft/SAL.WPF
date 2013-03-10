using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAL.WPF.Helper;
using System.Windows;
using SAL.EFLib.Repository;
using SAL.EFLib;
using SAL.WPF.View.CustomerSiteEquipment;
using System.Windows.Controls;
using SAL.WPF.Command;

namespace SAL.WPF.ViewModel.CustomerSiteEquipment
{
    public class SiteLeftViewModel : LeftViewModelBase
    {
        #region Field

        private Site _selectedSite;
        private CommandViewModel _addCommand;

        #endregion
      
        #region Constructor

        public SiteLeftViewModel(ViewModelBase parent)
            : base()     // call base class to initialize the dialogService
        {
            Parent = parent;

            _selectedSite = ((SiteViewModel)Parent).SelectedSite;

            Title = "SITE";
            Label1 = "Company: ";
            Label2 = "Address: ";

            LoadSiteRadioButtonList();

            ReturnVisibility = Visibility.Visible;
        }

        #endregion

        #region Command

        public CommandViewModel AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new CommandViewModel(new RelayCommand(OnAddSite), "Add Site");
                }

                return _addCommand;
            }
        }

        #endregion

        #region Method

        private void LoadSiteRadioButtonList()
        {
            List<CustomRadioButton> list = new List<CustomRadioButton>();

            var sites = _selectedSite.Customer.Sites;

             foreach (var site in sites)
            {
                if (site.ROW_ID == _selectedSite.ROW_ID)
                {
                    list.Add(new CustomRadioButton(site.ROW_ID, site.SiteName, true));
                }
                else
                {
                    list.Add(new CustomRadioButton(site.ROW_ID, site.SiteName));
                }
            }

            RadioButtonList = list;
        }

        protected override void OnSelected(object obj)
        {
            CustomRadioButton rdb = obj as CustomRadioButton;

            ((SiteViewModel)Parent).SelectedSite = new UnitOfWork().SiteRepository.GetByID(rdb.ID);
        }

        protected override void OnReturn(object obj)
        {
            ToCustomerView(_selectedSite.Customer);
        }

        private void ToCustomerView(Customer customer)
        {
            MainViewModel model = ((MainViewModel)Parent.Parent);

            Page page = new CustomerSiteEquipmentPage();
            page.DataContext = new CustomerViewModel(model, customer);
            model.CustomerSiteEquipmentPage = page;
        }

        protected void OnAddSite(object obj)
        {
            MainViewModel mainViewModel = ((MainViewModel)Parent.Parent);
            var viewModel = new AddEditViewModel(mainViewModel, new Site());
            dialogService.ShowDialog(this, viewModel);
        }

        #endregion
    }
}
