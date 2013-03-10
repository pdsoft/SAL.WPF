using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using SAL.WPF.View;
using System.Windows.Input;
using SAL.WPF.Command;

namespace SAL.WPF.ViewModel
{
    public class SiteViewModel : ViewModelBase
    {
        #region Dependency Property

        public Page SiteEquipmentPage
        {
            get { return (Page)GetValue(SiteEquipmentPagePageProperty); }
            set { SetValue(SiteEquipmentPagePageProperty, value); }
        }

        public static readonly DependencyProperty SiteEquipmentPagePageProperty =
            DependencyProperty.Register("SiteEquipmentPage", typeof(Page), typeof(SiteViewModel), new UIPropertyMetadata(null));

        public Page SiteVisitPage
        {
            get { return (Page)GetValue(SiteVisitPageProperty); }
            set { SetValue(SiteVisitPageProperty, value); }
        }

        public static readonly DependencyProperty SiteVisitPageProperty =
            DependencyProperty.Register("SiteVisitPage", typeof(Page), typeof(SiteViewModel), new UIPropertyMetadata(null));

        public Page ContactPage
        {
            get { return (Page)GetValue(ContactPageProperty); }
            set { SetValue(ContactPageProperty, value); }
        }

        public static readonly DependencyProperty ContactPageProperty =
            DependencyProperty.Register("ContactPage", typeof(Page), typeof(SiteViewModel), new UIPropertyMetadata(null));

        #endregion

        // by Fred, 2-5-2013
        #region Property

        public TabItem SelectedItem { get; set; }
        
        #endregion

        // by Fred, 2-5-2013
        #region Command Property

        //private ICommand _selectionChangedCommand;
        //public ICommand SelectionChangedCommand
        //{
        //    get
        //    {
        //        if (_selectionChangedCommand == null)
        //        {
        //            _selectionChangedCommand = new RelayCommand(OnSelectionChanged);
        //        }

        //        return _selectionChangedCommand;
        //    }
        //}

        #endregion

        #region Contructor

        public SiteViewModel(MainViewModel parent)
        {
            this.Parent = parent;           // by Fred, 2-6-2013

            SetSiteEquipmentPage();
            SetSiteVisitPage();
            SetContactPage();
        }

        #endregion

        // by Fred, 2-5-2013
        #region Method

        private void SetSiteEquipmentPage()
        {
            Page siteEquipmentPage = new SiteEquipmentPage();
            siteEquipmentPage.DataContext = new SiteEquipmentViewModel(this);
            this.SiteEquipmentPage = siteEquipmentPage;
        }

        private void SetSiteVisitPage()
        {
            Page siteVisitPage = new SiteVisitPage();
            siteVisitPage.DataContext = new SiteVisitViewModel();
            this.SiteVisitPage = siteVisitPage;
        }

        private void SetContactPage()
        {
            Page contactPage = new ContactPage();
            contactPage.DataContext = new ContactViewModel(this);
            this.ContactPage = contactPage;
        }

        #endregion

        // by Fred, 2-5-2013
        #region Command Method

        // command function, called by the xxxCommand.Execute.cs
        //private void OnSelectionChanged(object obj)
        //{
        //    switch(SelectedItem.Header.ToString())
        //    {
        //        case "Visit":
        //            SetSiteVisitPage();
        //            break;
        //        case "Contact":
        //            SetContactPage();
        //            break;
        //        case "Equipment":
        //        default:
        //            SetSiteEquipmentPage();
        //            break;
        //    }
        //}

        #endregion
    }
}
