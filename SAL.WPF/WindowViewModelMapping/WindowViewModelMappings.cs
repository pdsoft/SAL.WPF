using System;
using System.Collections.Generic;
using SAL.WPF.View.CustomerSiteEquipment;
using SAL.WPF.ViewModel.CustomerSiteEquipment;

namespace SAL.WPF.WindowViewModelMapping
{
	/// <summary>
	/// Class describing the Window-ViewModel mappings used by the dialog service.
	/// </summary>
	public class WindowViewModelMappings : IWindowViewModelMappings
	{
		private IDictionary<Type, Type> mappings;

		/// <summary>
		/// Initializes a new instance of the <see cref="WindowViewModelMappings"/> class.
		/// </summary>
		public WindowViewModelMappings()
		{
			mappings = new Dictionary<Type, Type>
			{
                { typeof(CustomerLeftViewModel), typeof(cseLeftPage) },
                { typeof(SiteLeftViewModel), typeof(cseLeftPage) },
                { typeof(CustomerRightViewModel), typeof(cseRightPage) },
                { typeof(SiteRightViewModel), typeof(cseRightPage) },
				{ typeof(AddEditViewModel), typeof(AddEditWindow) }		
			};
		}

		/// <summary>
		/// Gets the window type based on registered ViewModel type.
		/// </summary>
		/// <param name="viewModelType">The type of the ViewModel.</param>
		/// <returns>The window type based on registered ViewModel type.</returns>
		public Type GetWindowTypeFromViewModelType(Type viewModelType)
		{
			return mappings[viewModelType];
		}
	}
}