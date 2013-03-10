using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections.ObjectModel;
using SAL.WPF.Helper;
using SAL.EFLib;
using SAL.EFLib.Repository;
using SAL.WPF.Command;

namespace SAL.WPF.ViewModel.CustomerSiteEquipment
{
    public class CustomerLeftViewModel : LeftViewModelBase
    {
        #region Field

        private Customer _selectedCustomer;
        private CommandViewModel _addCommand;
        
        #endregion

        #region Constructor

        public CustomerLeftViewModel(CustomerViewModel parent)
            : base()     // call base class to initialize the dialogService
        {
            Parent = parent;

            _selectedCustomer = ((CustomerViewModel)Parent).SelectedCustomer;

            Title = "CUSTOMER";
            Label1 = "City: ";
            Label2 = "Company: ";

            LoadCustomerRadioButtonList();

            ReturnVisibility = Visibility.Hidden;
        }

        #endregion

        #region Command

        public CommandViewModel AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new CommandViewModel(new RelayCommand(OnAddCustomer), "Add Customer");
                }

                return _addCommand;
            }
        }

        #endregion

        #region Method

        private void LoadCustomerRadioButtonList()
        {
            List<CustomRadioButton> list = new List<CustomRadioButton>();

            var customers = new UnitOfWork().CustomerRepository.Get();

            foreach (var customer in customers)
            {
                if (customer.row_id == _selectedCustomer.row_id)
                {
                    list.Add(new CustomRadioButton(customer.row_id, customer.BusinessName, true));
                }
                else
                {
                    list.Add(new CustomRadioButton(customer.row_id, customer.BusinessName));
                }
            }

            RadioButtonList = list;
        }

        protected override void OnSelected(object obj)
        {
            CustomRadioButton rdb = obj as CustomRadioButton;

            ((CustomerViewModel)Parent).SelectedCustomer = new UnitOfWork().CustomerRepository.GetByID(rdb.ID);
        }

        protected void OnAddCustomer(object obj)
        {
            MainViewModel mainViewModel = ((MainViewModel)Parent.Parent);
            var viewModel = new AddEditViewModel(mainViewModel, new Customer());
            dialogService.ShowDialog(this, viewModel);
        }

        #endregion
    }
}
