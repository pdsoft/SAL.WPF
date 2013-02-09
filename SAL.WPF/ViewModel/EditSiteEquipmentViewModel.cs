using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAL.Model;
using System.Windows.Input;
using VendingManager.Command;
using SAL.WPF.View;

namespace SAL.WPF.ViewModel
{
    // by Fred, 2-5-2013
    public class EditSiteEquipmentViewModel : ViewModelBase
    {
        #region Field

        private SiteViewModel _parent;
        private Equipment _editEquipment;

        #endregion
        

        #region Property

        public Equipment EditEquipment
        {
            get { return _editEquipment; }
            set { _editEquipment = value; }
        }

        #endregion

        // by Fred, 2-5-2013
        #region Command

        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(OnSave, CanSave);
                }

                return _saveCommand;
            }
        }

        private ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                {
                    _cancelCommand = new RelayCommand(OnCancel, CanCancel);
                }

                return _cancelCommand;
            }
        }

        #endregion

        #region Constructor

        public EditSiteEquipmentViewModel(SiteViewModel parent)      // pass in parent, by Fred, 2-5-2013
        {
            _parent = parent;
            this.DisplayName = "Add Equipment";
        }

        public EditSiteEquipmentViewModel(SiteViewModel parent, Equipment editEquipment)      // pass in parent, by Fred, 2-5-2013
        {
            _parent = parent;
            this.DisplayName = "Edit Equipment";
            _editEquipment = editEquipment;
        }

        #endregion

        // by Fred, 2-5-2013
        #region Command Method

        // command function, called by the xxxCommand.Execute.cs
        private void OnSave(object o)
        {
            BackToSiteEquipment();
        }

        private bool CanSave(object o)
        {
            return true; ;
        }

        private void OnCancel(object o)
        {
            BackToSiteEquipment();
        }

        private bool CanCancel(object o)
        {
            return true; ;
        }

        #endregion

        #region Method

        private void BackToSiteEquipment()
        {
            var siteEquipmentPage = new SiteEquipmentPage();
            siteEquipmentPage.DataContext = new SiteEquipmentViewModel(_parent);
            _parent.SiteEquipmentPage = siteEquipmentPage;
        }

        #endregion
    }
}
