using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using SAL.WPF.View.CustomerSiteEquipment;
using SAL.EFLib;
using System.Windows;

namespace SAL.WPF.ViewModel.CustomerSiteEquipment
{
    public class EquipmentViewModel : ViewModelBase
    {
        #region Field

        private Equipment _selectedEquipment;

        #endregion

        #region Dependency Property

        public Page LeftPanel
        {
            get { return (Page)GetValue(LeftPanelProperty); }
            set { SetValue(LeftPanelProperty, value); }
        }

        //public static readonly DependencyProperty LeftPanelProperty =
        //    DependencyProperty.Register("LeftPanel", typeof(Page), typeof(SiteViewModel), new UIPropertyMetadata(null));

        public Page RightPanel
        {
            get { return (Page)GetValue(RightPanelProperty); }
            set { SetValue(RightPanelProperty, value); }
        }

        //public static readonly DependencyProperty RightPanelProperty =
        //   DependencyProperty.Register("RightPanel", typeof(Page), typeof(SiteViewModel), new UIPropertyMetadata(null));

        #endregion

        #region Property

        public Equipment SelectedEquipment
        {
            get { return _selectedEquipment; }
            set
            {
                _selectedEquipment = value;
                SetRightPanel();
            }
        }

        #endregion

        #region Constructor

        public EquipmentViewModel(ViewModelBase parent, Equipment selectedEquipment)// : base()
        {
            Parent = parent;
 
            SelectedEquipment = selectedEquipment;
            SetLeftPanel();
        }

        #endregion

        #region Method

        private void SetLeftPanel()
        {
            Page page = new cseLeftPage();
            page.DataContext = new EquipmentLeftViewModel(this);
            this.LeftPanel = page;
        }

        private void SetRightPanel()
        {
            Page page = new cseRightPage();
            page.DataContext = new EquipmentRightViewModel(this);
            this.RightPanel = page;
        }

        #endregion
    }
}
