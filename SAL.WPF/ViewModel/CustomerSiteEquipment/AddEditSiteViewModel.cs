using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAL.EFLib;
using System.Windows.Controls;
using SAL.WPF.Command;
using SAL.WPF.View.CustomerSiteEquipment;
using SAL.EFLib.Repository;
using SAL.WPF.View.CustomerSiteEquipment.CustomerTab;
using SAL.WPF.ViewModel.CustomerSiteEquipment.CustomerTab;

namespace SAL.WPF.ViewModel.CustomerSiteEquipment
{
    public class AddEditSiteViewModel : ViewModelBase
    {
        #region Field

        private Site _site;
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

        public Site Site
        {
            get { return _site; }
            set { _site = value; }
        }

        public string Title { get; set; }

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

        public AddEditSiteViewModel(ViewModelBase parent, Site site)
        {
            Parent = parent;
            _site = site;

            DisplayName = "Site Data Form";

            Title = string.Format("Site - {0}", _site.ROW_ID);

            GetMainAddressPage();
            GetBillingAddressPage();
        }

        #endregion

        #region Method

        private bool IsWindow
        {
            get
            {
                return Parent.GetType().Equals(typeof(AddEditViewModel));
            }
        }

        private bool IsPage
        {
            get
            {
                return Parent.GetType().Equals(typeof(CustomerRightViewModel));
            }
        }

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
            unitOfWork.SiteRepository.Update(_site);
            unitOfWork.Save();

            OnClose(null);
        }

        private void OnClose(object obj)
        {
            if (IsWindow)
            {
                ((AddEditViewModel)Parent).CloseWindow(obj);
            }
            else if (IsPage)
            {
                BackToCustomerTabSite();
            }
        }

        private void BackToCustomerTabSite()
        {
            var page = new cTabSitePage();
            page.DataContext = new cTabSiteViewModel(Parent);
            ((CustomerRightViewModel)Parent).Tab1Page = page;
        }

        #endregion
    }
}
