using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAL.WPF.Helper;
using System.Windows;
using SAL.WPF.Command;
using SAL.WPF.Service;

namespace SAL.WPF.ViewModel.CustomerSiteEquipment
{
    public abstract class LeftViewModelBase : ViewModelBase
    {
        #region Field

        private CommandViewModel _selectedCommand;
        private CommandViewModel _returnCommand;

        #endregion

        #region Dependency Property

        public List<CustomRadioButton> RadioButtonList
        {
            get { return (List<CustomRadioButton>)GetValue(RadioButtonListProperty); }
            set { SetValue(RadioButtonListProperty, value); }
        }

        #endregion

        #region Command

        public CommandViewModel SelectedCommand
        {
            get
            {
                if (_selectedCommand == null)
                {
                    _selectedCommand = new CommandViewModel(new RelayCommand(OnSelected));
                }

                return _selectedCommand;
            }
        }

        public CommandViewModel ReturnCommand
        {
            get
            {
                if (_returnCommand == null)
                {
                    _returnCommand = new CommandViewModel(new RelayCommand(OnReturn));
                }

                return _returnCommand;
            }
        }

        #endregion

        #region Property

        public string Title { get; set; }
        public string Label1 { get; set; }
        public string Label2 { get; set; }
        public Visibility ReturnVisibility { get; set; }

        #endregion

        #region Constructor

        public LeftViewModelBase() : base()
        {
        }

        #endregion

        #region Method

        protected virtual void OnSelected(object obj)
        {
        }

        protected virtual void OnReturn(object obj)
        {
        }
                
        #endregion
    }
}
