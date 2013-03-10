using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using SAL.Model;
using SAL.WPF.Command;
using SAL.WPF.View;

namespace SAL.WPF.ViewModel
{
    // by Fred, 2-5-2013
    public class EditContactViewModel : ViewModelBase
    {
        private SiteViewModel _parent;
        private SiteContact _editSiteContact;

        #region Property

        public SiteContact EditSiteContact
        {
            get { return _editSiteContact; }
            set { _editSiteContact = value; }
        }

        #endregion

        // by Fred, 2-5-2013
        #region Command Property

        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(OnSave);
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
                    _cancelCommand = new RelayCommand(OnCancel);
                }

                return _cancelCommand;
            }
        }

        #endregion

        #region Constructor

        // add
        public EditContactViewModel(SiteViewModel parent)      // pass in parent, by Fred, 2-5-2013
        {
            _parent = parent;
        }

        // edit
        public EditContactViewModel(SiteViewModel parent, SiteContact editSiteContact)      // pass in parent, by Fred, 2-5-2013
        {
            _parent = parent;
            _editSiteContact = editSiteContact;
        }

        #endregion

        // by Fred, 2-5-2013
        #region Command Method

        // command function, called by the xxxCommand.Execute.cs
        private void OnSave(object o)
        {
            BackToSiteContact();
        }

        private void OnCancel(object o)
        {
            BackToSiteContact();
        }

        #endregion

        #region Method

        private void BackToSiteContact()
        {
            var siteContactPage = new ContactPage();
            siteContactPage.DataContext = new ContactViewModel(_parent);
            _parent.ContactPage = siteContactPage;
        }

        #endregion
    }
}
