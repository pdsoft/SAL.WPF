using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using SAL.EFLib;
using SAL.WPF.ViewModel.CustomerSiteEquipment.SiteTab;
using SAL.WPF.View.CustomerSiteEquipment.SiteTab;

namespace SAL.WPF.ViewModel.CustomerSiteEquipment
{
    public class SiteRightViewModel : RightViewModelBase
    {
        #region Constructor

        public SiteRightViewModel(ViewModelBase parent)
            : base()     // call base class to initialize the dialogService
        {
            Parent = parent;

            Site site = ((SiteViewModel)Parent).SelectedSite;

            Label11 = "Company:";
            Label21 = "Primary Contact:";
            Label12 = "Site Address:";
            Label22 = "Phone/Fax/Email:";  

            TextBox11 = site.SiteName;
            TextBox21 = site.PrimaryContactID.ToString();
            TextBox12 = site.AddressID.ToString();
            TextBox22 = site.phone;

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

            Page page = new sTabEquipmentPage();
            page.DataContext = new sTabEquipmentViewModel(this);
            this.Tab1Page = page;
        }

        private void SetTab2Page()
        {
            TabHeader2 = "Agreement";

            //Page page = new sTabEquipmentPage();
            //page.DataContext = new sTabEquipmentViewModel(this);
            //this.Tab1Page = page;
        }

        private void SetTab3Page()
        {
            TabHeader3 = "Contact";

            //Page page = new sTabEquipmentPage();
            //page.DataContext = new sTabEquipmentViewModel(this);
            //this.Tab1Page = page;
        }

        private void SetTab4Page()
        {
            TabHeader4 = "Attachment";

            //Page page = new sTabEquipmentPage();
            //page.DataContext = new sTabEquipmentViewModel(this);
            //this.Tab1Page = page;
        }

        protected override void OnEdit(object obj)
        {
            Site site = ((SiteViewModel)Parent).SelectedSite;
            MainViewModel mainViewModel = ((MainViewModel)Parent.Parent);
            var viewModel = new AddEditViewModel(mainViewModel, site);
            dialogService.ShowDialog(this, viewModel);
        }

        #endregion
    }
}
