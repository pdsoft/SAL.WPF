using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using SAL.Model;
using System.Windows;
using VendingManager.Command;

namespace SAL.WPF.ViewModel
{
    // by Fred, 2-7-2013
    public class EquipmentCustomerInputViewModel : ViewModelBase
    {
        #region Field

        private CommandViewModel _addCommand;
        private CommandViewModel _editCommand;
        private CommandViewModel _deleteCommand;

        #endregion

        #region Dependency Property

        public ObservableCollection<CustomerInput> CustomerInputList
        {
            get { return (ObservableCollection<CustomerInput>)GetValue(CustomerInputListListProperty); }
            set { SetValue(CustomerInputListListProperty, value); }
        }

        public static readonly DependencyProperty CustomerInputListListProperty =
            DependencyProperty.Register("CustomerInputList", typeof(ObservableCollection<CustomerInput>), typeof(EquipmentCustomerInputViewModel), new UIPropertyMetadata(null));

        #endregion

        #region Command

        public CommandViewModel AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new CommandViewModel("Add Customer Input", new RelayCommand(param => OnAdd()));
                }
                return _addCommand;
            }
        }

        public CommandViewModel EditCommand
        {
            get
            {
                if (_editCommand == null)
                {
                    _editCommand = new CommandViewModel("Edit", new RelayCommand(param => OnEdit()));
                }
                return _editCommand;
            }
        }

        public CommandViewModel DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new CommandViewModel("Delete", new RelayCommand(param => OnDelete()));
                }
                return _deleteCommand;
            }
        }

        #endregion

        #region Constructor

        public EquipmentCustomerInputViewModel()
        {
            // get data
            EquipmentModel equipment = SampleData.GetEquipmentData();
            this.CustomerInputList = new ObservableCollection<CustomerInput>(equipment.CustomerInputs);
        }

        #endregion

        #region Command Method

        private void OnAdd()
        {

        }
        private void OnEdit()
        {
        }

        private void OnDelete()
        {
        }

        #endregion
    }
}
