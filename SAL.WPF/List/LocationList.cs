using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using SAL.EFLib;
using SAL.EFLib.Repository;

namespace SAL.WPF.List
{
    public class LocationList
    {
        #region Property

        private ObservableCollection<Location> _list;

        #endregion

        #region Method

        public ObservableCollection<Location> GetBySiteIDComboBox(int siteID)
        {
            var locations = new UnitOfWork().LocationRepository.Get(o => o.SiteID == siteID);

            _list = new ObservableCollection<Location>(locations);

            Location all = new Location();
            all.LocationName = "All Loactions";
            all.row_id = -1;
            _list.Insert(0, all);

            return _list;
        }

        #endregion
    }
}
