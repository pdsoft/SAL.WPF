using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SAL.WPF.Helper
{
    public class CustomRadioButton
    {
        private int _id;
        private string _name;
        private bool _isSelected;

        #region Property

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; }
        }

        #endregion

        #region Constructor

        public CustomRadioButton(int id, string name, bool isSelected = false)
        {
            _id = id;
            _name = name;
            _isSelected = isSelected;
        }

        #endregion
    }
}
