using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAL.EFLib;
using SAL.WPF.View.CustomerSiteEquipment.SiteTab;
using System.Collections.ObjectModel;
using SAL.WPF.List;
using SAL.EFLib.Repository;
using SAL.WPF.Command;

namespace SAL.WPF.ViewModel.CustomerSiteEquipment.SiteTab
{
    public class sTabAddEditEquipmentViewModel : ViewModelBase
    {
        #region Field

        private Site _selectedSite;
        private Equipment _editEquipment;
        private CommandViewModel _saveCommand;
        private CommandViewModel _cancelCommand;

        #endregion
        
        #region Property

        public Equipment EditEquipment
        {
            get { return _editEquipment; }
            set { _editEquipment = value; }
        }

        public ObservableCollection<EquipmentType> EquipmentTypeList { get; set; }
        public ObservableCollection<Location> LocationList { get; set; }

        #endregion

        // by Fred, 2-5-2013
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

        public CommandViewModel CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                {
                    _cancelCommand = new CommandViewModel(new RelayCommand(OnCancel), "Cancel");
                }
                return _cancelCommand;
            }
        }

        #endregion

        #region Constructor

        public sTabAddEditEquipmentViewModel(ViewModelBase parent)      // pass in parent, by Fred, 2-5-2013
        {
            Parent = parent;
            DisplayName = "Add Equipment";
            _selectedSite = ((SiteViewModel)Parent.Parent).SelectedSite;

            LoadEquipmentTypeList();
            LoadLocationList();
        }

        public sTabAddEditEquipmentViewModel(ViewModelBase parent, Equipment editEquipment)
            : this(parent)      // pass in parent, by Fred, 2-5-2013
        {
            _editEquipment = editEquipment;
        }

        #endregion

        // by Fred, 2-5-2013
        #region Command Method

        // command function, called by the xxxCommand.Execute.cs
        private void OnSave(object o)
        {
            var unitOfWork = new UnitOfWork();

            unitOfWork.EquipmentRepository.Update(o as Equipment);
            unitOfWork.Save();

            BackToSiteTabEquipment();
        }

        private void OnCancel(object o)
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
