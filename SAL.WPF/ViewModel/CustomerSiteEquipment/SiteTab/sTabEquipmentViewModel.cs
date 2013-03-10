using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using SAL.EFLib;
using System.Windows;
using SAL.WPF.View.CustomerSiteEquipment;
using System.Windows.Controls;
using SAL.WPF.List;
using System.Windows.Data;
using System.ComponentModel;
using SAL.WPF.View.CustomerSiteEquipment.SiteTab;
using SAL.WPF.Command;

namespace SAL.WPF.ViewModel.CustomerSiteEquipment.SiteTab
{
    public class sTabEquipmentViewModel : ViewModelBase
    {
        #region Field

        private Site _selectedSite;
        private CommandViewModel _selectedCommand;
        private CommandViewModel _editCommand;
        private CommandViewModel _copyCommand;
        private CommandViewModel _addOneCommand;
        private CommandViewModel _addBatchCommand;

        #endregion

        #region Dependency Property

        public ObservableCollection<Equipment> EquipmentList
        {
            get { return (ObservableCollection<Equipment>)GetValue(EquipmentListProperty); }
            set { SetValue(EquipmentListProperty, value); }
        }

        public static readonly DependencyProperty EquipmentListProperty =
            DependencyProperty.Register("EquipmentList", typeof(ObservableCollection<Equipment>), typeof(sTabEquipmentViewModel), new UIPropertyMetadata(null));

        #endregion

        #region Command Property

        public CommandViewModel SelectedCommand
        {
            get
            {
                if (_selectedCommand == null)
                {
                    _selectedCommand = new CommandViewModel(new RelayCommand(OnSelected));
                }
                return _selectedCommand;
            }
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

        public CommandViewModel CopyCommand
        {
            get
            {
                if (_copyCommand == null)
                {
                    _copyCommand = new CommandViewModel(new RelayCommand(OnCopy), "Copy");
                }
                return _copyCommand;
            }
        }

        public CommandViewModel AddOneCommand
        {
            get
            {
                if (_addOneCommand == null)
                {
                    _addOneCommand = new CommandViewModel(new RelayCommand(OnAddOne), "Add One Equipment");
                }
                return _addOneCommand;
            }
        }

        public CommandViewModel AddBatchCommand
        {
            get
            {
                if (_addBatchCommand == null)
                {
                    _addBatchCommand = new CommandViewModel(new RelayCommand(OnAddBatch), "Add Batch Equipment");
                }
                return _addBatchCommand;
            }
        }

        #endregion

        #region Property

        public ObservableCollection<EquipmentType> EquipmentTypeList { get; set; }
        public ObservableCollection<Location> LocationList { get; set; }

        public ICollectionView EquipmentListView { get; set; }
        public ICollectionView EquipmentTypeListView { get; set; }
        public ICollectionView LocationListView { get; set; }

        #endregion

        #region Constructor

        public sTabEquipmentViewModel(ViewModelBase parent)
        {
            Parent = parent;

            _selectedSite = ((SiteViewModel)Parent.Parent).SelectedSite;

            // load filter list
            LoadEquipmentTypeList();
            LoadLocationList();

            // load list
            LoadEquipmentList();
        }

        #endregion

        #region Command Method

        private void OnSelected(object obj)
        {
            ToEquipmentView(obj as Equipment);
        }

        private void ToEquipmentView(Equipment equipment)
        {
            MainViewModel model = ((MainViewModel)Parent.Parent.Parent);

            Page page = new CustomerSiteEquipmentPage();
            page.DataContext = new EquipmentViewModel(model, equipment);
            model.CustomerSiteEquipmentPage = page;
        }

        private void OnEdit(object obj)
        {
            var editPage = new sTabAddEditEquipmentPage();
            editPage.DataContext = new sTabAddEditEquipmentViewModel(Parent, obj as Equipment);
            ((SiteRightViewModel)Parent).Tab1Page = editPage;
        }

        private void OnCopy(object obj)
        {
        }

        private void OnAddOne(object obj)
        {
            var addPage = new sTabAddEditEquipmentPage();
            addPage.DataContext = new sTabAddEditEquipmentViewModel(Parent);
            ((SiteRightViewModel)Parent).Tab1Page = addPage;
        }

        private void OnAddBatch(object obj)
        {
            var addBatchPage = new sTabAddBatchEquipmentPage();
            addBatchPage.DataContext = new sTabAddBatchEquipmentViewModel(Parent);
            ((SiteRightViewModel)Parent).Tab1Page = addBatchPage;
        }

        #endregion

        #region Method

        private void LoadEquipmentList()
        {
            EquipmentList = new ObservableCollection<Equipment>(_selectedSite.Equipments);

            EquipmentListView = CollectionViewSource.GetDefaultView(EquipmentList);
            EquipmentListView.CurrentChanged += new EventHandler(EquipmentListView_CurrentChanged);
            EquipmentListView.Filter += this.MasterFilter;
        }

        private void EquipmentListView_CurrentChanged(object sender, EventArgs e)
        {
            
        }

        private void LoadEquipmentTypeList()
        {
            EquipmentTypeList = new EquipmentTypeList().GetAllComboBox();
            EquipmentTypeListView = CollectionViewSource.GetDefaultView(this.EquipmentTypeList);
            EquipmentTypeListView.CurrentChanged += new EventHandler(EquipmentTypeListView_CurrentChanged);
        }

        private void EquipmentTypeListView_CurrentChanged(object sender, EventArgs e)
        {
            RefreshEquipmentList();
        }

        private void LoadLocationList()
        {
            LocationList = new LocationList().GetBySiteIDComboBox(_selectedSite.ROW_ID);
            LocationListView = CollectionViewSource.GetDefaultView(this.LocationList);
            LocationListView.CurrentChanged += new EventHandler(LocationListView_CurrentChanged);
        }

        private void LocationListView_CurrentChanged(object sender, EventArgs e)
        {
            RefreshEquipmentList();
        }

        private void RefreshEquipmentList()
        {
            if (EquipmentListView != null)
            {
                EquipmentListView.Refresh();
            }
        }

        #endregion

        #region Filter

        private bool MasterFilter(object value)
        {
            if (EquipmentTypeFilter(value) && LocationFilter(value) & ProblemFilter(value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool EquipmentTypeFilter(object value)
        {
            var equipment = (Equipment)value;
            var equipmentType = (EquipmentType)EquipmentTypeListView.CurrentItem;

            if (equipmentType.row_id == -1)       // currentCategory.ID == null -> , changed by Fred, 7-4-2011
            {
                return true;
            }
            else
            {
                return equipmentType.row_id == equipment.EquipmentTypeID;
            }
        }

        private bool LocationFilter(object value)
        {
            var equipment = (Equipment)value;
            var location = (Location)LocationListView.CurrentItem;

            if (location.row_id == -1)       // currentCategory.ID == null -> , changed by Fred, 7-4-2011
            {
                return true;
            }
            else
            {
                return location.row_id == equipment.LocationID;
            }
        }

        private bool ProblemFilter(object value)
        {
            return true;
        }

        #endregion
    }
}
