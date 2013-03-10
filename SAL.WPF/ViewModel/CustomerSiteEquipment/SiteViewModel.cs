using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAL.EFLib;
using System.Windows.Controls;
using System.Windows;
using SAL.WPF.View.CustomerSiteEquipment;
using SAL.EFLib.Repository;

namespace SAL.WPF.ViewModel.CustomerSiteEquipment
{
    public class SiteViewModel : ViewModelBase
    {
        #region Field

        private Site _selectedSite;

        #endregion

        #region Dependency Property

        public Page LeftPanel
        {
            get { return (Page)GetValue(LeftPanelProperty); }
            set { SetValue(LeftPanelProperty, value); }
        }

        public Page RightPanel
        {
            get { return (Page)GetValue(RightPanelProperty); }
            set { SetValue(RightPanelProperty, value); }
        }

        #endregion

        #region Property

        public Site SelectedSite
        {
            get 
            {
                UnitOfWork.Reload(_selectedSite);
                return _selectedSite; 
            }
            set
            {
                _selectedSite = value;
                SetRightPanel();
            }
        }

        #endregion

        #region Constructor

        public SiteViewModel(ViewModelBase parent, Site selectedSite) //: base()
        {
            Parent = parent;
 
            SelectedSite = selectedSite;
            SetLeftPanel();
        }

        #endregion

        #region Method

        private void SetLeftPanel()
        {
            Page page = new cseLeftPage();
            page.DataContext = new SiteLeftViewModel(this);
            this.LeftPanel = page;
        }

        private void SetRightPanel()
        {
            Page page = new cseRightPage();
            page.DataContext = new SiteRightViewModel(this);
            this.RightPanel = page;
        }

        #endregion
    }
}
