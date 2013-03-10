using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAL.WPF.Helper;
using SAL.EFLib;
using SAL.WPF.View.CustomerSiteEquipment;
using System.Windows.Controls;
using SAL.EFLib.Repository;
using System.Windows;

namespace SAL.WPF.ViewModel.CustomerSiteEquipment
{
    public class EquipmentLeftViewModel : LeftViewModelBase
    {
        private Equipment _selectedEquipment;

        #region Constructor

        public EquipmentLeftViewModel(ViewModelBase parent)
        {
            Parent = parent;

            _selectedEquipment = ((EquipmentViewModel)Parent).SelectedEquipment;

            Title = "EQUIPMENT";
            Label1 = "Company: ";
            Label2 = "Site: ";

            LoadSiteRadioButtonList();

            ReturnVisibility = Visibility.Visible;
        }

        #endregion

        #region Method

        private void LoadSiteRadioButtonList()
        {
            List<CustomRadioButton> list = new List<CustomRadioButton>();

            var equipments = _selectedEquipment.Site.Equipments;

            foreach (var equipment in equipments)
            {
                if (equipment.row_id == _selectedEquipment.row_id)
                {
                    list.Add(new CustomRadioButton(equipment.row_id, equipment.Description, true));
                }
                else
                {
                    list.Add(new CustomRadioButton(equipment.row_id, equipment.Description));
                }
            }

            RadioButtonList = list;
        }

        protected override void OnSelected(object obj)
        {
            CustomRadioButton rdb = obj as CustomRadioButton;

            ((SiteViewModel)Parent).SelectedSite = new UnitOfWork().SiteRepository.GetByID(rdb.ID);
        }

        protected override void OnReturn(object obj)
        {
            ToSiteView(_selectedEquipment.Site);
        }

        private void ToSiteView(Site site)
        {
            MainViewModel model = ((MainViewModel)Parent.Parent);

            Page page = new CustomerSiteEquipmentPage();
            page.DataContext = new SiteViewModel(model, site);
            model.CustomerSiteEquipmentPage = page;
        }

        #endregion
    }
}
