using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAL.WPF.Model
{
    public class CustomerCheckBox
    {
        private int _id;
        private string _name;
        private bool _isCheck;

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

        public bool IsCheck
        {
            get { return _isCheck; }
            set { _isCheck = value; }
        }

        #endregion

        #region Constructor

        public CustomerCheckBox(int id, string name)
        {
            _id = id;
            _name = name;
            _isCheck = false;
        }

        #endregion
    }
}
