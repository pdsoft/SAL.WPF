using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using SAL.WPF.View;
using SAL.WPF.Command;
using System.Windows.Input;
using SAL.WPF.ViewModel.CustomerSiteEquipment;
using SAL.WPF.View.CustomerSiteEquipment;

namespace SAL.WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private CommandViewModel _selectionChangedCommand;

        #region Dependency Property

        public Page CustomerSiteEquipmentPage
        {
            get { return (Page)GetValue(CustomerSiteEquipmentPageProperty); }
            set { SetValue(CustomerSiteEquipmentPageProperty, value); }
        }

        public static readonly DependencyProperty CustomerSiteEquipmentPageProperty =
            DependencyProperty.Register("CustomerSiteEquipmentPage", typeof(Page), typeof(MainViewModel), new UIPropertyMetadata(null));

        #endregion

        #region Property

        public TabItem SelectedItem { get; set; }

        #endregion

        #region Command Property

        public CommandViewModel SelectionChangedCommand
        {
            get
            {
                if (_selectionChangedCommand == null)
                {
                    _selectionChangedCommand = new CommandViewModel(new RelayCommand(OnSelectionChanged));
                }
                return _selectionChangedCommand;
            }
        }

        #endregion

        #region Constructor

        public MainViewModel()
        {
            DisplayName = "SAL";

            SetCustomerSiteEquipmentPage();
        }

        #endregion

        #region Method

        private void SetCustomerSiteEquipmentPage()
        {
            Page page = new CustomerSiteEquipmentPage();
            page.DataContext = new CustomerViewModel(this);
            this.CustomerSiteEquipmentPage = page;
        }

        #endregion

        #region Command Method

        // command function, called by the xxxCommand.Execute.cs
        private void OnSelectionChanged(object obj)
        {
            switch (SelectedItem.Header.ToString())
            {
                case "CustomerSiteEquipment":
                default:
                    SetCustomerSiteEquipmentPage();
                    break;
            }
        }

        #endregion
    }
}
