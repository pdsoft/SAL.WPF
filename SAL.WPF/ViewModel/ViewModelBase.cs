using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using SAL.EFLib.Repository;
using System.Windows.Controls;
using SAL.WPF.ViewModel.CustomerSiteEquipment;
using System.Collections.Generic;
using SAL.WPF.Helper;
using SAL.WPF.Service;

namespace SAL.WPF.ViewModel
{
	/// <summary>
	/// Code from http://msdn.microsoft.com/en-us/magazine/dd419663.aspx
	/// 
	/// Base class for all ViewModel classes in the application.
	/// It provides support for property change notifications 
	/// and has a DisplayName property.  This class is abstract.
	/// </summary>
    public abstract class ViewModelBase : DependencyObject, INotifyPropertyChanged, IDisposable
	{
		#region Constructor

		protected ViewModelBase()
		{
            dialogService = ServiceLocator.Resolve<IDialogService>();
		}

		#endregion // Constructor

		#region DisplayName

		/// <summary>
		/// Returns the user-friendly name of this object.
		/// Child classes can set this property to a new value,
		/// or override it to determine the value on-demand.
		/// </summary>
		public virtual string DisplayName { get; protected set; }

		#endregion // DisplayName

		#region Debugging Aides

		/// <summary>
		/// Warns the developer if this object does not have
		/// a public property with the specified name. This 
		/// method does not exist in a Release build.
		/// </summary>
		[Conditional("DEBUG")]
		[DebuggerStepThrough]
		public void VerifyPropertyName(string propertyName)
		{
			// Verify that the property name matches a real,  
			// public, instance property on this object.
			if (TypeDescriptor.GetProperties(this)[propertyName] == null)
			{
				string msg = "Invalid property name: " + propertyName;

				if (this.ThrowOnInvalidPropertyName)
					throw new Exception(msg);
				else
					Debug.Fail(msg);
			}
		}

		/// <summary>
		/// Returns whether an exception is thrown, or if a Debug.Fail() is used
		/// when an invalid property name is passed to the VerifyPropertyName method.
		/// The default value is false, but subclasses used by unit tests might 
		/// override this property's getter to return true.
		/// </summary>
		protected virtual bool ThrowOnInvalidPropertyName { get; private set; }

		#endregion // Debugging Aides

		#region INotifyPropertyChanged Members

		/// <summary>
		/// Raised when a property on this object has a new value.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Raises this object's PropertyChanged event.
		/// </summary>
		/// <param name="propertyName">The property that has a new value.</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			this.VerifyPropertyName(propertyName);

			PropertyChangedEventHandler handler = this.PropertyChanged;
			if (handler != null)
			{
				var e = new PropertyChangedEventArgs(propertyName);
				handler(this, e);
			}
		}

		#endregion // INotifyPropertyChanged Members

		#region IDisposable Members

		/// <summary>
		/// Invoked when this object is being removed from the application
		/// and will be subject to garbage collection.
		/// </summary>
		public void Dispose()
		{
			this.OnDispose();
		}

		/// <summary>
		/// Child classes can override this method to perform 
		/// clean-up logic, such as removing event handlers.
		/// </summary>
		protected virtual void OnDispose()
		{
		}

#if DEBUG
		/// <summary>
		/// Useful for ensuring that ViewModel objects are properly garbage collected.
		/// </summary>
		~ViewModelBase()
		{
			string msg = string.Format("{0} ({1}) ({2}) Finalized", this.GetType().Name, this.DisplayName, this.GetHashCode());
			System.Diagnostics.Debug.WriteLine(msg);
		}
#endif

		#endregion // IDisposable Members

        // by Fred
        public ViewModelBase Parent { get; set; }


        #region Dependency Property

        public static readonly DependencyProperty LeftPanelProperty = 
            DependencyProperty.Register("LeftPanel", typeof(Page), typeof(CustomerViewModel), new UIPropertyMetadata(null));

        public static readonly DependencyProperty RightPanelProperty =
            DependencyProperty.Register("RightPanel", typeof(Page), typeof(CustomerViewModel), new UIPropertyMetadata(null));

        public static readonly DependencyProperty RadioButtonListProperty =
            DependencyProperty.Register("RadioButtonList", typeof(List<CustomRadioButton>), typeof(CustomerLeftViewModel), new UIPropertyMetadata(null));

        public static readonly DependencyProperty Tab1PageProperty =
            DependencyProperty.Register("Tab1Page", typeof(Page), typeof(CustomerRightViewModel), new UIPropertyMetadata(null));

        public static readonly DependencyProperty Tab2PageProperty =
            DependencyProperty.Register("Tab2Page", typeof(Page), typeof(CustomerRightViewModel), new UIPropertyMetadata(null));

        public static readonly DependencyProperty Tab3PageProperty =
            DependencyProperty.Register("Tab3Page", typeof(Page), typeof(CustomerRightViewModel), new UIPropertyMetadata(null));

        public static readonly DependencyProperty Tab4PageProperty =
            DependencyProperty.Register("Tab4Page", typeof(Page), typeof(CustomerRightViewModel), new UIPropertyMetadata(null));

        public static readonly DependencyProperty Tab5PageProperty =
            DependencyProperty.Register("Tab5Page", typeof(Page), typeof(CustomerRightViewModel), new UIPropertyMetadata(null));

        public static readonly DependencyProperty Tab6PageProperty =
            DependencyProperty.Register("Tab6Page", typeof(Page), typeof(CustomerRightViewModel), new UIPropertyMetadata(null));

        public static readonly DependencyProperty Tab7PageProperty =
            DependencyProperty.Register("Tab7Page", typeof(Page), typeof(CustomerRightViewModel), new UIPropertyMetadata(null));

        public static readonly DependencyProperty Tab8PageProperty =
            DependencyProperty.Register("Tab8Page", typeof(Page), typeof(CustomerRightViewModel), new UIPropertyMetadata(null));

        public static readonly DependencyProperty AddEditPageProperty =
            DependencyProperty.Register("AddEditPage", typeof(Page), typeof(AddEditViewModel), new UIPropertyMetadata(null));

        public static readonly DependencyProperty MainAddressPageProperty =
            DependencyProperty.Register("MainAddressPage", typeof(Page), typeof(AddEditCustomerViewModel), new UIPropertyMetadata(null));

        public static readonly DependencyProperty BillingAddressPageProperty =
            DependencyProperty.Register("BillingAddressPage", typeof(Page), typeof(AddEditCustomerViewModel), new UIPropertyMetadata(null));

        protected readonly IDialogService dialogService;

        public static void RegisterDependencyProperty() 
        {
            LeftPanelProperty.AddOwner(typeof(SiteViewModel));
            LeftPanelProperty.AddOwner(typeof(EquipmentViewModel));
            RightPanelProperty.AddOwner(typeof(SiteViewModel));
            RightPanelProperty.AddOwner(typeof(EquipmentViewModel));
            RadioButtonListProperty.AddOwner(typeof(SiteViewModel));
            RadioButtonListProperty.AddOwner(typeof(EquipmentViewModel));
            Tab1PageProperty.AddOwner(typeof(SiteViewModel));
            Tab1PageProperty.AddOwner(typeof(EquipmentViewModel));
            Tab2PageProperty.AddOwner(typeof(SiteViewModel));
            Tab2PageProperty.AddOwner(typeof(EquipmentViewModel));
            Tab3PageProperty.AddOwner(typeof(SiteViewModel));
            Tab3PageProperty.AddOwner(typeof(EquipmentViewModel));
            Tab4PageProperty.AddOwner(typeof(SiteViewModel));
            Tab4PageProperty.AddOwner(typeof(EquipmentViewModel));
            Tab5PageProperty.AddOwner(typeof(SiteViewModel));
            Tab5PageProperty.AddOwner(typeof(EquipmentViewModel));
            Tab6PageProperty.AddOwner(typeof(SiteViewModel));
            Tab6PageProperty.AddOwner(typeof(EquipmentViewModel));
            Tab7PageProperty.AddOwner(typeof(SiteViewModel));
            Tab7PageProperty.AddOwner(typeof(EquipmentViewModel));
            Tab8PageProperty.AddOwner(typeof(SiteViewModel));
            Tab8PageProperty.AddOwner(typeof(EquipmentViewModel));
        }
        #endregion
    }
}