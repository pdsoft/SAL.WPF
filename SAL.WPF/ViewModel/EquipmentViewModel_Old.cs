using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using SAL.WPF.View;

namespace SAL.WPF.ViewModel
{
    // by Fred, 2-6-2013
    public class EquipmentViewModel_Old : ViewModelBase
    {
        #region Dependency Property

        public Page NameplatePanel
        {
            get { return (Page)GetValue(NameplatePanelProperty); }
            set { SetValue(NameplatePanelProperty, value); }
        }

        public static readonly DependencyProperty NameplatePanelProperty =
            DependencyProperty.Register("NameplatePanel", typeof(Page), typeof(EquipmentViewModel_Old), new UIPropertyMetadata(null));

        public Page SpecificationPanel
        {
            get { return (Page)GetValue(SpecificationPanelProperty); }
            set { SetValue(SpecificationPanelProperty, value); }
        }

        public static readonly DependencyProperty SpecificationPanelProperty =
            DependencyProperty.Register("SpecificationPanel", typeof(Page), typeof(EquipmentViewModel_Old), new UIPropertyMetadata(null));

        public Page AttributePanel
        {
            get { return (Page)GetValue(AttributePanelProperty); }
            set { SetValue(AttributePanelProperty, value); }
        }

        public static readonly DependencyProperty AttributePanelProperty =
            DependencyProperty.Register("AttributePanel", typeof(Page), typeof(EquipmentViewModel_Old), new UIPropertyMetadata(null));
        
        public Page ProblemPanel
        {
            get { return (Page)GetValue(ProblemPanelProperty); }
            set { SetValue(ProblemPanelProperty, value); }
        }

        public static readonly DependencyProperty ProblemPanelProperty =
            DependencyProperty.Register("ProblemPanel", typeof(Page), typeof(EquipmentViewModel_Old), new UIPropertyMetadata(null));

        public Page AttachmentPanel
        {
            get { return (Page)GetValue(AttachmentPanelProperty); }
            set { SetValue(AttachmentPanelProperty, value); }
        }

        public static readonly DependencyProperty AttachmentPanelProperty =
            DependencyProperty.Register("AttachmentPanel", typeof(Page), typeof(EquipmentViewModel_Old), new UIPropertyMetadata(null));

        public Page CustomerInputPanel
        {
            get { return (Page)GetValue(CustomerInputPanelProperty); }
            set { SetValue(CustomerInputPanelProperty, value); }
        }

        public static readonly DependencyProperty CustomerInputPanelProperty =
            DependencyProperty.Register("CustomerInputPanel", typeof(Page), typeof(EquipmentViewModel_Old), new UIPropertyMetadata(null));

        #endregion

        #region Constructor

        public EquipmentViewModel_Old()
        {
            Page nameplatePage = new EquipmentNameplatePage();
            nameplatePage.DataContext = new EquipmentNameplateViewModel();
            this.NameplatePanel = nameplatePage;

            Page specificationPage = new EquipmentSpecificationPage();
            specificationPage.DataContext = new EquipmentSpecificationViewModel();
            this.SpecificationPanel = specificationPage;

            Page attributePage = new EquipmentAttributePage();
            attributePage.DataContext = new EquipmentAttributeViewModel();
            this.AttributePanel = attributePage;

            Page problemPage = new EquipmentProblemPage();
            problemPage.DataContext = new EquipmentProblemViewModel();
            this.ProblemPanel = problemPage;

            Page attachmentPage = new EquipmentAttachmentPage();
            attachmentPage.DataContext = new EquipmentAttachmentViewModel();
            this.AttachmentPanel = attachmentPage;

            Page customerInputPage = new EquipmentCustomerInputPage();
            customerInputPage.DataContext = new EquipmentCustomerInputViewModel();
            this.CustomerInputPanel = customerInputPage;
        }

        #endregion
    }
}
