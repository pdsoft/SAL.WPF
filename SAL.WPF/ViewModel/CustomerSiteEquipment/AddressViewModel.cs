using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAL.WPF.ViewModel.CustomerSiteEquipment
{
    public class AddressViewModel : ViewModelBase
    {
        #region Property

        public bool IsCanada { get; set; }
        public bool IsUSA { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public int? City { get; set; }
        public int? Province { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }

        #endregion

        #region Constructor

        public AddressViewModel()
        {
            IsCanada = true;
        }


        #endregion
    }
}
