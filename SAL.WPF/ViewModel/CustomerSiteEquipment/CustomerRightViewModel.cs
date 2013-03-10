using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using SAL.WPF.ViewModel.CustomerSiteEquipment.CustomerTab;
using SAL.EFLib;
using SAL.WPF.View.CustomerSiteEquipment.CustomerTab;

namespace SAL.WPF.ViewModel.CustomerSiteEquipment
{
    public class CustomerRightViewModel : RightViewModelBase
    {
        #region Constructor

        public CustomerRightViewModel(ViewModelBase parent)
            : base()     // call base class to initialize the dialogService
        {
            Parent = parent;

            Customer customer = ((CustomerViewModel)Parent).SelectedCustomer;
            
            Label11 = "Company:";
            Label21 = "Address:";
            Label12 = "Parent Company:";
            Label22 = "Primary Contact:";

            TextBox11 = customer.BusinessName;
            TextBox21 = customer.Address1;
            TextBox12 = customer.Parent_ID.ToString();
            TextBox22 = customer.PrimaryContactID.ToString();

            SetTab1Page();
            SetTab2Page();
            SetTab3Page();
            SetTab4Page();
        }

        #endregion

        #region Method

        private void SetTab1Page()
        {
            TabHeader1 = "Site";

            Page page = new cTabSitePage();
            page.DataContext = new cTabSiteViewModel(this);
            this.Tab1Page = page;
        }

        private void SetTab2Page()
        {
            TabHeader2 = "Agreement";

            //Page page = new cTabSitePage();
            //page.DataContext = new cTabSiteViewModel(this);
            //this.Tab1Page = page;
        }

        private void SetTab3Page()
        {
            TabHeader3 = "Contact";

            //Page page = new cTabSitePage();
            //page.DataContext = new cTabSiteViewModel(this);
            //this.Tab1Page = page;
        }

        private void SetTab4Page()
        {
            TabHeader4 = "Attachment";

            //Page page = new cTabSitePage();
            //page.DataContext = new cTabSiteViewModel(this);
            //this.Tab1Page = page;
        }

        protected override void OnEdit(object obj)
        {
            Customer customer = ((CustomerViewModel)Parent).SelectedCustomer;
            MainViewModel mainViewModel = ((MainViewModel)Parent.Parent);
            var viewModel = new AddEditViewModel(mainViewModel, customer);
            dialogService.ShowDialog(this, viewModel);
        }

        #endregion
    }
}
