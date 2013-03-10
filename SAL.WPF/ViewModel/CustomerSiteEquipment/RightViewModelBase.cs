using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using SAL.WPF.Service;
using SAL.WPF.Command;

namespace SAL.WPF.ViewModel.CustomerSiteEquipment
{
    public class RightViewModelBase : ViewModelBase
    {
        #region Field

        private string _label11;
        private string _label21;
        private string _label12;
        private string _label22;
        private string _label13;
        private string _label23;
        private string _tabHeader1;
        private string _tabHeader2;
        private string _tabHeader3;
        private string _tabHeader4;
        private string _tabHeader5;
        private string _tabHeader6;
        private string _tabHeader7;
        private string _tabHeader8;

        private Visibility _textBlock11Visibility = Visibility.Hidden;
        private Visibility _textBlock21Visibility = Visibility.Hidden;
        private Visibility _textBlock12Visibility = Visibility.Hidden;
        private Visibility _textBlock22Visibility = Visibility.Hidden;
        private Visibility _textBlock13Visibility = Visibility.Hidden;
        private Visibility _textBlock23Visibility = Visibility.Hidden;
        private Visibility _tabHeader1Visibility = Visibility.Hidden;
        private Visibility _tabHeader2Visibility = Visibility.Hidden;
        private Visibility _tabHeader3Visibility = Visibility.Hidden;
        private Visibility _tabHeader4Visibility = Visibility.Hidden;
        private Visibility _tabHeader5Visibility = Visibility.Hidden;
        private Visibility _tabHeader6Visibility = Visibility.Hidden;
        private Visibility _tabHeader7Visibility = Visibility.Hidden;
        private Visibility _tabHeader8Visibility = Visibility.Hidden;

        private CommandViewModel _editCommand;

        #endregion

        #region Property

        public string Label11 
        {
            get { return _label11; }
            set 
            {
                _label11 = value;
                _textBlock11Visibility = Visibility.Visible;
            } 
        }

        public string Label21
        {
            get { return _label21; }
            set
            {
                _label21 = value;
                _textBlock21Visibility = Visibility.Visible;
            }
        }

        public string Label12
        {
            get { return _label12; }
            set
            {
                _label12 = value;
                _textBlock12Visibility = Visibility.Visible;
            }
        }

        public string Label22
        {
            get { return _label22; }
            set
            {
                _label22 = value;
                _textBlock22Visibility = Visibility.Visible;
            }
        }

        public string Label13
        {
            get { return _label13; }
            set
            {
                _label13 = value;
                _textBlock13Visibility = Visibility.Visible;
            }
        }

        public string Label23
        {
            get { return _label23; }
            set
            {
                _label23 = value;
                _textBlock23Visibility = Visibility.Visible;
            }
        }

        public string TabHeader1
        {
            get { return _tabHeader1; }
            set
            {
                _tabHeader1 = value;
                _tabHeader1Visibility = Visibility.Visible;
            }
        }

        public string TabHeader2
        {
            get { return _tabHeader2; }
            set
            {
                _tabHeader2 = value;
                _tabHeader2Visibility = Visibility.Visible;
            }
        }

        public string TabHeader3
        {
            get { return _tabHeader3; }
            set
            {
                _tabHeader3 = value;
                _tabHeader3Visibility = Visibility.Visible;
            }
        }

        public string TabHeader4
        {
            get { return _tabHeader4; }
            set
            {
                _tabHeader4 = value;
                _tabHeader4Visibility = Visibility.Visible;
            }
        }

        public string TabHeader5
        {
            get { return _tabHeader5; }
            set
            {
                _tabHeader5 = value;
                _tabHeader5Visibility = Visibility.Visible;
            }
        }

        public string TabHeader6
        {
            get { return _tabHeader6; }
            set
            {
                _tabHeader6 = value;
                _tabHeader6Visibility = Visibility.Visible;
            }
        }

        public string TabHeader7
        {
            get { return _tabHeader7; }
            set
            {
                _tabHeader7 = value;
                _tabHeader7Visibility = Visibility.Visible;
            }
        }

        public string TabHeader8
        {
            get { return _tabHeader8; }
            set
            {
                _tabHeader8 = value;
                _tabHeader8Visibility = Visibility.Visible;
            }
        }

        public string TextBox11 { get; set; }
        public string TextBox21 { get; set; }
        public string TextBox12 { get; set; }
        public string TextBox22 { get; set; }
        public string TextBox13 { get; set; }
        public string TextBox23 { get; set; }

        public Visibility TextBlock11Visibility { get { return _textBlock11Visibility; } }
        public Visibility TextBlock21Visibility { get { return _textBlock21Visibility; } }
        public Visibility TextBlock12Visibility { get { return _textBlock12Visibility; } }
        public Visibility TextBlock22Visibility { get { return _textBlock22Visibility; } }
        public Visibility TextBlock13Visibility { get { return _textBlock13Visibility; } }
        public Visibility TextBlock23Visibility { get { return _textBlock23Visibility; } }
        public Visibility TabHeader1Visibility { get { return _tabHeader1Visibility; } }
        public Visibility TabHeader2Visibility { get { return _tabHeader2Visibility; } }
        public Visibility TabHeader3Visibility { get { return _tabHeader3Visibility; } }
        public Visibility TabHeader4Visibility { get { return _tabHeader4Visibility; } }
        public Visibility TabHeader5Visibility { get { return _tabHeader5Visibility; } }
        public Visibility TabHeader6Visibility { get { return _tabHeader6Visibility; } }
        public Visibility TabHeader7Visibility { get { return _tabHeader7Visibility; } }
        public Visibility TabHeader8Visibility { get { return _tabHeader8Visibility; } }

        public Page Tab1Page
        {
            get { return (Page)GetValue(Tab1PageProperty); }
            set { SetValue(Tab1PageProperty, value); }
        }

        public Page Tab2Page
        {
            get { return (Page)GetValue(Tab2PageProperty); }
            set { SetValue(Tab2PageProperty, value); }
        }

        public Page Tab3Page
        {
            get { return (Page)GetValue(Tab3PageProperty); }
            set { SetValue(Tab3PageProperty, value); }
        }

        public Page Tab4Page
        {
            get { return (Page)GetValue(Tab4PageProperty); }
            set { SetValue(Tab4PageProperty, value); }
        }

        public Page Tab5Page
        {
            get { return (Page)GetValue(Tab5PageProperty); }
            set { SetValue(Tab5PageProperty, value); }
        }

        public Page Tab6Page
        {
            get { return (Page)GetValue(Tab6PageProperty); }
            set { SetValue(Tab6PageProperty, value); }
        }

        public Page Tab7Page
        {
            get { return (Page)GetValue(Tab7PageProperty); }
            set { SetValue(Tab7PageProperty, value); }
        }

        public Page Tab8Page
        {
            get { return (Page)GetValue(Tab8PageProperty); }
            set { SetValue(Tab8PageProperty, value); }
        }

        public CommandViewModel EditCommand
        {
            get
            {
                if (_editCommand == null)
                {
                    _editCommand = new CommandViewModel(new RelayCommand(OnEdit), "Edit");
                }
                return _editCommand;
            }
        }

        #endregion

        #region Method

        protected virtual void OnEdit(object obj)
        { 
        }

        #endregion

        #region Constructor

        public RightViewModelBase() : base()
        {
        }

        #endregion
    }
}
