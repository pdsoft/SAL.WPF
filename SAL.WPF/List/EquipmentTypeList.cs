using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAL.EFLib;
using System.Collections.ObjectModel;
using SAL.EFLib.Repository;

namespace SAL.WPF.List
{
    public class EquipmentTypeList : ObservableCollection<EquipmentType>
    {
        private ObservableCollection<EquipmentType> _list;

        public ObservableCollection<EquipmentType> GetAllComboBox()
        {
            var equipmentTypes = new UnitOfWork().EquipmentTypeRepository.Get();

            _list = new ObservableCollection<EquipmentType>(equipmentTypes);

            EquipmentType all = new EquipmentType();
            all.TemplateName = "All EquipmentType";
            all.row_id = -1;
            _list.Insert(0, all);

            return _list;
        }
    }
}
