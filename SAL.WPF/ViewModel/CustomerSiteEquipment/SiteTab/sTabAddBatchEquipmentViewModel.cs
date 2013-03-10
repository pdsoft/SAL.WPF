using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAL.WPF.View.CustomerSiteEquipment.SiteTab;
using SAL.EFLib;
using System.Collections.ObjectModel;
using SAL.WPF.List;
using SAL.WPF.Command;

namespace SAL.WPF.ViewModel.CustomerSiteEquipment.SiteTab
{
    public class sTabAddBatchEquipmentViewModel : ViewModelBase
    {
        #region Field

        private Site _selectedSite;
        private CommandViewModel _saveCommand;
        private CommandViewModel _closeCommand;

        #endregion

        #region Command

        public CommandViewModel SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new CommandViewModel(new RelayCommand(param => OnSave()), "Save");
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
                    _closeCommand = new CommandViewModel(new RelayCommand(param => OnClose()), "Close");
                }
                return _closeCommand;
            }
        }

        #endregion

        #region Property

        public ObservableCollection<EquipmentType> EquipmentTypeList { get; set; }
        public ObservableCollection<Location> LocationList { get; set; }

        public Equipment Equipment1 { get; set; }
        public Equipment Equipment2 { get; set; }
        public Equipment Equipment3 { get; set; }
        public Equipment Equipment4 { get; set; }

        #endregion

        #region Constructor

        public sTabAddBatchEquipmentViewModel(ViewModelBase parent)
        {
            Parent = parent;
            _selectedSite = ((SiteViewModel)Parent.Parent).SelectedSite;

            LoadEquipmentTypeList();
            LoadLocationList();
        }

        #endregion

        #region Command Method

        private void OnSave()
        {
            BackToSiteTabEquipment();
        }

        private void OnClose()
        {
            BackToSiteTabEquipment();
        }

        #endregion

        #region Method

        private void BackToSiteTabEquipment()
        {
            var page = new sTabEquipmentPage();
            page.DataContext = new sTabEquipmentViewModel(Parent);
            ((SiteRightViewModel)Parent).Tab1Page = page;
        }

        private void LoadEquipmentTypeList()
        {
            EquipmentTypeList = new EquipmentTypeList().GetAllComboBox();
        }

        private void LoadLocationList()
        {
            LocationList = new LocationList().GetBySiteIDComboBox(_selectedSite.ROW_ID);
        }

        #endregion
    }
}
