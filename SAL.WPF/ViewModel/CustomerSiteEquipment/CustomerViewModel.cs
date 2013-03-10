using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using SAL.WPF.View;
using SAL.WPF.View.CustomerSiteEquipment;
using SAL.EFLib;
using SAL.EFLib.Repository;

namespace SAL.WPF.ViewModel.CustomerSiteEquipment
{
    public class CustomerViewModel : ViewModelBase
    {
        #region Field

        private Customer _selectedCustomer;

        #endregion

        #region Dependency Property

        public Page LeftPanel
        {
            get { return (Page)GetValue(LeftPanelProperty); }
            set { SetValue(LeftPanelProperty, value); }
        }

        //public static readonly DependencyProperty LeftPanelProperty =
        //    DependencyProperty.Register("LeftPanel", typeof(Page), typeof(CustomerViewModel), new UIPropertyMetadata(null));

        public Page RightPanel
        {
            get { return (Page)GetValue(RightPanelProperty); }
            set { SetValue(RightPanelProperty, value); }
        }

        //lic static readonly DependencyProperty RightPanelProperty =
        //    DependencyProperty.Register("RightPanel", typeof(Page), typeof(CustomerViewModel), new UIPropertyMetadata(null));

        #endregion

        #region Property

        public Customer SelectedCustomer 
        {
            get 
            {
                UnitOfWork.Reload(_selectedCustomer);
                return _selectedCustomer; 
            }
            set
            {
                _selectedCustomer = value;
                SetRightPanel();
            }
        }

        #endregion

        #region Constructor

        public CustomerViewModel(ViewModelBase parent, Customer selectedCustomer = null)// : base()
        {
            Parent = parent;

            // default to the first customer
            if (selectedCustomer == null)
            {
                SelectedCustomer = new UnitOfWork().CustomerRepository.Get().FirstOrDefault();
            }
            else
            {
                SelectedCustomer = selectedCustomer;
            }

            SetLeftPanel();
        }

        #endregion

        #region Method

        private void SetLeftPanel()
        {
            Page page = new cseLeftPage();
            page.DataContext = new CustomerLeftViewModel(this);
            this.LeftPanel = page;
        }

        private void SetRightPanel()
        {
            Page page = new cseRightPage();
            page.DataContext = new CustomerRightViewModel(this);
            this.RightPanel = page;
        }

        #endregion
    }
}
