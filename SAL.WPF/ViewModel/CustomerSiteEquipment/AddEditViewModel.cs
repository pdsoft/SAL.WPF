using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using SAL.EFLib;
using SAL.WPF.View.CustomerSiteEquipment;
using SAL.WPF.Service;

namespace SAL.WPF.ViewModel.CustomerSiteEquipment
{
    public class AddEditViewModel : ViewModelBase
    {
        #region Field

        MainViewModel _mainViewModel;
        bool _isCustomer;
        bool _isSite;
        Customer _customer;
        Site _site;

        #endregion

        #region Dependency Property

        public Page AddEditPage
        {
            get { return (Page)GetValue(AddEditPageProperty); }
            set { SetValue(AddEditPageProperty, value); }
        }

        #endregion

        #region Constructor

        public AddEditViewModel(ViewModelBase mainViewModel, object obj) : base()
        {
            _mainViewModel = mainViewModel as MainViewModel;

            if (IsCustomer(obj))
            {
                _isCustomer = true;
                _customer = obj as Customer;
                GetAddEditCustomerPage();
            }
            else if (IsSite(obj))
            {
                _isSite = true;
                _site = obj as Site;
                GetAddEditSitePage();
            }
        }

        #endregion

        #region Method

        private bool IsCustomer(object obj)
        {
            return obj.GetType().BaseType.Equals(typeof(Customer)) || obj.GetType().Equals(typeof(Customer));
        }

        private bool IsSite(object obj)
        {
            return obj.GetType().BaseType.Equals(typeof(Site)) || obj.GetType().Equals(typeof(Site));
        }

        private void GetAddEditCustomerPage()
        {
            Page page = new AddEditCustomerPage();
            page.DataContext = new AddEditCustomerViewModel(this, _customer);
            this.AddEditPage = page;
        }

        private void GetAddEditSitePage()
        {
            Page page = new AddEditSitePage();
            page.DataContext = new AddEditSiteViewModel(this, _site);
            this.AddEditPage = page;
        }

        private void RefreshCustomerPage()
        {
            Page page = new CustomerSiteEquipmentPage();
            page.DataContext = new CustomerViewModel(_mainViewModel, _customer);
            _mainViewModel.CustomerSiteEquipmentPage = page;
        }

        private void RefreshSitePage()
        {
            Page page = new CustomerSiteEquipmentPage();
            page.DataContext = new SiteViewModel(_mainViewModel, _site);
            _mainViewModel.CustomerSiteEquipmentPage = page;
        }

        public void CloseWindow(object obj)
        {
            if (obj == null)        // update
            {
                if (_isCustomer)
                {
                    RefreshCustomerPage();
                }
                else if (_isSite)
                {
                    RefreshSitePage();
                }
            }

            dialogService.CloseWindow(this);
        }  

        #endregion
    }
}
