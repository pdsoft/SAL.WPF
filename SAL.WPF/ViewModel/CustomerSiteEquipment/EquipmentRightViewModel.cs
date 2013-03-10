using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using SAL.EFLib;
using System.Windows;

namespace SAL.WPF.ViewModel.CustomerSiteEquipment
{
    public class EquipmentRightViewModel : RightViewModelBase
    {
        #region Constructor

        public EquipmentRightViewModel(ViewModelBase parent)
        {
            Parent = parent;

            Label11 = "Asset ID:";
            Label21 = "Fed Form:";
            Label12 = "Equipment Type:";
            Label22 = "Rated Voltage:";
            Label13 = "Location:";
            Label23 = "Problem?:";

            Equipment equipment = ((EquipmentViewModel)Parent).SelectedEquipment;

            TextBox11 = equipment.Asset_ID;
            //TextBox21 = equipment.f;
            TextBox12 = equipment.EquipmentTypeID.ToString();
            //TextBox22 = equipment;
            TextBox13 = equipment.LocationID.ToString();
            //TextBox23 = equipment;

            SetTab1Page();
            SetTab2Page();
            SetTab3Page();
            SetTab4Page();
            SetTab5Page();
            SetTab6Page();
            SetTab7Page();
            SetTab8Page();
        }

        #endregion

        #region Method

        private void SetTab1Page()
        {
            TabHeader1 = "Nameplate/Attribute Reading";

            //Page page = new sTabNameplatePage();
            //page.DataContext = new sTabNameplateViewModel(this);
            //this.Tab1Page = page;
        }

        private void SetTab2Page()
        {
            TabHeader2 = "Problem Log";
        }

        private void SetTab3Page()
        {
            TabHeader3 = "Work Log";
        }

        private void SetTab4Page()
        {
            TabHeader4 = "Work Form";
        }

        private void SetTab5Page()
        {
            TabHeader5 = "Panel Schedule";
        }

        private void SetTab6Page()
        {
            TabHeader6 = "Attachment";
        }

        private void SetTab7Page()
        {
            TabHeader7 = "Customer Input";
        }

        private void SetTab8Page()
        {
            TabHeader8 = "Safety Instruction";
        }
        
        #endregion
    }
}
