using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAL.EFLib;
using System.Windows.Controls;
using SAL.WPF.View.CustomerSiteEquipment;
using SAL.EFLib.Repository;
using SAL.WPF.Command;

namespace SAL.WPF.ViewModel.CustomerSiteEquipment
{
    public class AddEditCustomerViewModel : ViewModelBase
    {
        #region Field

        private Customer _customer;
        private CommandViewModel _saveCommand;
        private CommandViewModel _closeCommand;

        #endregion

        #region Dependency Property

        public Page MainAddressPage
        {
            get { return (Page)GetValue(MainAddressPageProperty); }
            set { SetValue(MainAddressPageProperty, value); }
        }

        public Page BillingAddressPage
        {
            get { return (Page)GetValue(BillingAddressPageProperty); }
            set { SetValue(BillingAddressPageProperty, value); }
        }

        #endregion

        #region Property

        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public string Title { get; set; }
        public string Company { get; set; }
        public int? BusinessType { get; set; }
        public int? ParentCompany { get; set; }
        public int? Status { get; set; }
        public int? PrimaryContact { get; set; }
        public string GeneralComment { get; set; }

        #endregion

        #region Command

        public CommandViewModel SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new CommandViewModel(new RelayCommand(OnSave), "Save");
                }

                return _saveCommand;
            }
        }

        public CommandViewModel CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new CommandViewModel(new RelayCommand(OnClose), "Close");
                }

                return _closeCommand;
            }
        }

        #endregion

        #region Constructor

        public AddEditCustomerViewModel(ViewModelBase parent, Customer customer)
        {
            Parent = parent;
            _customer = customer;

            DisplayName = "Customer Data Form";

            Title = string.Format("Customer - {0}", _customer.row_id);
            Company = _customer.BusinessName;
            ParentCompany = _customer.Parent_ID;
            PrimaryContact = _customer.PrimaryContactID;

            GetMainAddressPage();
            GetBillingAddressPage();
        }

        #endregion

        #region Method

        private void GetMainAddressPage()
        {
            Page page = new AddressPage();
            page.DataContext = new AddressViewModel();
            this.MainAddressPage = page;
        }

        private void GetBillingAddressPage()
        {
            Page page = new AddressPage();
            page.DataContext = new AddressViewModel();
            this.BillingAddressPage = page;
        }

        private void OnSave(object obj)
        {
            var unitOfWork = new UnitOfWork();
            unitOfWork.CustomerRepository.Update(_customer);
            unitOfWork.Save();

            OnClose(null);
        }

        private void OnClose(object obj)
        {
            ((AddEditViewModel)Parent).CloseWindow(obj);
        }

        #endregion
    }
}
