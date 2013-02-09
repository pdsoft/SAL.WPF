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
    public class EquipmentProblemViewModel : ViewModelBase
    {
        #region Field

        private CommandViewModel _addCommand;
        private CommandViewModel _editCommand;
        private CommandViewModel _deleteCommand;

        #endregion

        #region Dependency Property

        public ObservableCollection<Problem> ProblemList
        {
            get { return (ObservableCollection<Problem>)GetValue(ProblemListProperty); }
            set { SetValue(ProblemListProperty, value); }
        }

        public static readonly DependencyProperty ProblemListProperty =
            DependencyProperty.Register("ProblemListProperty", typeof(ObservableCollection<Problem>), typeof(EquipmentProblemViewModel), new UIPropertyMetadata(null));

        #endregion

        #region Command

        public CommandViewModel AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new CommandViewModel("Add Problem", new RelayCommand(param => OnAdd()));
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

        public EquipmentProblemViewModel()
        {
            // get data
            EquipmentModel equipment = SampleData.GetEquipmentData();
            this.ProblemList = new ObservableCollection<Problem>(equipment.Problems);
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
