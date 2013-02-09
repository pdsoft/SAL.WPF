using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using SAL.WPF.Model;

namespace SAL.WPF.ViewModel
{
    public class LeftViewModel : ViewModelBase
    {
        #region Dependency Property

        public List<CustomerCheckBox> CustomerCheckBoxtList
        {
            get { return (List<CustomerCheckBox>)GetValue(CustomerCheckBoxtListProperty); }
            set { SetValue(CustomerCheckBoxtListProperty, value); }
        }

        public static readonly DependencyProperty CustomerCheckBoxtListProperty =
            DependencyProperty.Register("CustomerCheckBoxtList", typeof(List<CustomerCheckBox>), typeof(LeftViewModel), new UIPropertyMetadata(null));

        #endregion

        #region Constructor

        public LeftViewModel()
        {
            LoadCustomerCheckBoxtList();
        }

        #endregion

        #region Method

        private void LoadCustomerCheckBoxtList()
        {
            List<CustomerCheckBox> list = new List<CustomerCheckBox>();

            list.Add(new CustomerCheckBox(1, "100 Birchmont, Scarborough"));
            list.Add(new CustomerCheckBox(2, "222 Banf Ave, King"));
            list.Add(new CustomerCheckBox(3, "10 Yonge Street, Toronto"));

            CustomerCheckBoxtList = list;
        }

        #endregion
    }
}
