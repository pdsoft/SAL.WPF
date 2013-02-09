using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using SAL.Model;
using System.Windows;

namespace SAL.WPF.ViewModel
{
    // by Fred, 2-5-2013
    public class SiteVisitViewModel : ViewModelBase
    {
        #region Dependency Property

        public ObservableCollection<Visit> SiteVisitList
        {
            get { return (ObservableCollection<Visit>)GetValue(SiteVisitListProperty); }
            set { SetValue(SiteVisitListProperty, value); }
        }

        public static readonly DependencyProperty SiteVisitListProperty =
            DependencyProperty.Register("SiteVisitList", typeof(ObservableCollection<Visit>), typeof(SiteVisitViewModel), new UIPropertyMetadata(null));

        #endregion

        #region Constructor

        public SiteVisitViewModel()
        {
            // get data
            SiteModel site = SampleData.GetSiteData();
            SiteVisitList = new ObservableCollection<Visit>(site.Visits);
        }

        #endregion
    }
}
