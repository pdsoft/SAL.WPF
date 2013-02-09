using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingManager.Command;
using SAL.WPF.View;

namespace SAL.WPF.ViewModel
{
    // by Fred, 2-6-2013
    public class AddBatchSiteEquipmentViewModel : ViewModelBase
    {
        #region Field

        private SiteViewModel _parent;
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
                    _saveCommand = new CommandViewModel("Save", new RelayCommand(param => OnSave()));
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
                    _closeCommand = new CommandViewModel("Close", new RelayCommand(param => OnClose()));
                }
                return _closeCommand;
            }
        }

        #endregion

        #region Constructor

        public AddBatchSiteEquipmentViewModel(SiteViewModel parent)
        {
            _parent = parent;
        }

        #endregion

        #region Command Method

        private void OnSave()
        {
            BackToSiteEquipment();
        }

        private void OnClose()
        {
            BackToSiteEquipment();
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
