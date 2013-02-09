using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using SAL.Model;
using System.Windows;
using System.Windows.Input;
using VendingManager.Command;
using SAL.WPF.View;

namespace SAL.WPF.ViewModel
{
    // by Fred, 2-5-20113
    public class ContactViewModel : ViewModelBase
    {
        private SiteViewModel _parent;

        #region Dependency Property

        public ObservableCollection<Contact> ContactList
        {
            get { return (ObservableCollection<Contact>)GetValue(ContactListProperty); }
            set { SetValue(ContactListProperty, value); }
        }

        public static readonly DependencyProperty ContactListProperty =
            DependencyProperty.Register("ContactList", typeof(ObservableCollection<Contact>), typeof(ContactViewModel), new UIPropertyMetadata(null));

        #endregion

        // by Fred, 2-5-2013
        #region Command Property

        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(OnAdd, CanAdd);
                }

                return _addCommand;
            }
        }   

        #endregion

        #region Constructor

        public ContactViewModel(SiteViewModel parent)      // pass in parent, by Fred, 2-5-2013
        {
            _parent = parent;

            // get data
            CustomerModel customer = SampleData.GetCustomerData();
            ContactList = new ObservableCollection<Contact>(customer.Contacts);
        }

        #endregion

        // by Fred, 2-5-2013
        #region Command Method

        // command function, called by the xxxCommand.Execute.cs
        private void OnAdd(object o)
        {
            var addContactPage = new EditContactPage();
            addContactPage.DataContext = new EditContactViewModel(_parent);
            _parent.ContactPage = addContactPage;
        }

        private bool CanAdd(object o)
        {
            return true; ;
        }

        #endregion
    }
}
