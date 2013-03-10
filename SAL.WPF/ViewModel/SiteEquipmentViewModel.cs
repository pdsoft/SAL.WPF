using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using SAL.Model;
using System.Collections.ObjectModel;
using SAL.WPF.Command;
using System.Windows.Input;
using SAL.WPF.View;

namespace SAL.WPF.ViewModel
{
    public class SiteEquipmentViewModel : ViewModelBase
    {
        #region Field

        private SiteViewModel _parent;
        private ICommand _addOneCommand;
        private ICommand _addBatchCommand;
        private ICommand _equipmentCommand;     // by Fred, 2-6-2013
        private ICommand _editCommand;

        #endregion
        
        #region Dependency Property

        public ObservableCollection<Equipment> SiteEquipmentList
        {
            get { return (ObservableCollection<Equipment>)GetValue(SiteEquipmentListProperty); }
            set { SetValue(SiteEquipmentListProperty, value); }
        }

        public static readonly DependencyProperty SiteEquipmentListProperty =
            DependencyProperty.Register("SiteEquipmentList", typeof(ObservableCollection<Equipment>), typeof(SiteEquipmentViewModel), new UIPropertyMetadata(null));

        #endregion

        // by Fred, 2-5-2013
        #region Command Property
       
        public ICommand AddOneCommand
        {
            get
            {
                if (_addOneCommand == null)
                {
                    _addOneCommand = new RelayCommand(OnAddOne);
                }

                return _addOneCommand;
            }
        }
      
        public ICommand AddBatchCommand
        {
            get
            {
                if (_addBatchCommand == null)
                {
                    _addBatchCommand = new RelayCommand(OnAddBatch);
                }

                return _addBatchCommand;
            }
        }

        // by Fred, 2-6-2013
        public ICommand EquipmentCommand
        {
            get
            {
                if (_equipmentCommand == null)
                {
                    _equipmentCommand = new RelayCommand(OnEquipment);
                }

                return _equipmentCommand;
            }
        }

        public ICommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                {
                    _editCommand = new RelayCommand(OnEdit);
                }

                return _editCommand;
            }
        }   

        #endregion

        #region Constructor

        public SiteEquipmentViewModel(SiteViewModel parent)      // pass in parent, by Fred, 2-5-2013
        {
            _parent = parent;

            // get data
            SiteModel site = SampleData.GetSiteData();
            SiteEquipmentList = new ObservableCollection<Equipment>(site.Equipments);
        }

        #endregion

        // by Fred, 2-5-2013
        #region Command Method

        // command function, called by the xxxCommand.Execute.cs
        private void OnAddOne(object obj)
        {
            //var addSiteEquipmentPage = new EditSiteEquipmentPage();
            //addSiteEquipmentPage.DataContext = new EditSiteEquipmentViewModel(_parent);
            //_parent.SiteEquipmentPage = addSiteEquipmentPage;
        }

        private void OnAddBatch(object obj)
        {
            //var addSiteBatchEquipmentPage = new AddBatchSiteEquipmentPage();
            //addSiteBatchEquipmentPage.DataContext = new AddBatchSiteEquipmentViewModel(_parent);
            //_parent.SiteEquipmentPage = addSiteBatchEquipmentPage;
        }

        // by Fred, 2-6-20113
        private void OnEquipment(object obj)
        {
            var equipmentPage = new EquipmentPage();
            equipmentPage.DataContext = new EquipmentViewModel_Old();
            //_parent.Parent.RightPanel = equipmentPage;
        }

        private void OnEdit(object obj)
        {
            //var editSiteEquipmentPage = new EditSiteEquipmentPage();
            //editSiteEquipmentPage.DataContext = new EditSiteEquipmentViewModel(_parent, obj as Equipment);
            //_parent.SiteEquipmentPage = editSiteEquipmentPage;
        }

        #endregion
    }
}
