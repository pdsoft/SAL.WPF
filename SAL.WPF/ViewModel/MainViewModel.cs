using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using SAL.WPF.View;

namespace SAL.WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Dependency Property

        public Page LeftPanel
        {
            get { return (Page)GetValue(LeftPanelProperty); }
            set { SetValue(LeftPanelProperty, value); }
        }

        public static readonly DependencyProperty LeftPanelProperty =
            DependencyProperty.Register("LeftPanel", typeof(Page), typeof(MainViewModel), new UIPropertyMetadata(null));

        public Page RightPanel
        {
            get { return (Page)GetValue(RightPanelProperty); }
            set { SetValue(RightPanelProperty, value); }
        }

        public static readonly DependencyProperty RightPanelProperty =
            DependencyProperty.Register("RightPanel", typeof(Page), typeof(MainViewModel), new UIPropertyMetadata(null));

        #endregion

        #region Constructor

        public MainViewModel()
        {
            Page leftPage = new LeftPage();
            leftPage.DataContext = new LeftViewModel();
            this.LeftPanel = leftPage;

            Page rightPage = new SitePage();
            rightPage.DataContext = new SiteViewModel(this);
            this.RightPanel = rightPage;
        }

        #endregion
    }
}
