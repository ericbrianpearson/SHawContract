//--------------------------------------------------------------------------------------------------
// <auto-generated>
//
//     This code was generated by code generator tool.
//
//     To customize the code use your own partial class. For more info about how to use and customize
//     the generated code see the documentation at http://docs.kentico.com.
//
// </auto-generated>
//--------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using CMS;
using CMS.Base;
using CMS.Helpers;
using CMS.DataEngine;
using CMS.DocumentEngine.Types.ShawContract;
using CMS.DocumentEngine;

[assembly: RegisterDocumentType(MenuItem.CLASS_NAME, typeof(MenuItem))]

namespace CMS.DocumentEngine.Types.ShawContract
{
	/// <summary>
	/// Represents a content item of type MenuItem.
	/// </summary>
	public partial class MenuItem : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "ShawContract.MenuItem";


		/// <summary>
		/// The instance of the class that provides extended API for working with MenuItem fields.
		/// </summary>
		private readonly MenuItemFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// MenuItemID.
		/// </summary>
		[DatabaseIDField]
		public int MenuItemID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("MenuItemID"), 0);
			}
			set
			{
				SetValue("MenuItemID", value);
			}
		}


		/// <summary>
		/// Display Name.
		/// </summary>
		[DatabaseField]
		public string DisplayName
		{
			get
			{
				return ValidationHelper.GetString(GetValue("DisplayName"), @"");
			}
			set
			{
				SetValue("DisplayName", value);
			}
		}


		/// <summary>
		/// Will clicking on this item navigate to a page?.
		/// </summary>
		[DatabaseField]
		public bool IsClickable
		{
			get
			{
				return ValidationHelper.GetBoolean(GetValue("IsClickable"), true);
			}
			set
			{
				SetValue("IsClickable", value);
			}
		}


		/// <summary>
		/// Referenced Page.
		/// </summary>
		[DatabaseField]
		public string PageReference
		{
			get
			{
				return ValidationHelper.GetString(GetValue("PageReference"), @"");
			}
			set
			{
				SetValue("PageReference", value);
			}
		}


		/// <summary>
		/// Open in new tab?.
		/// </summary>
		[DatabaseField]
		public bool OpenInNewTab
		{
			get
			{
				return ValidationHelper.GetBoolean(GetValue("OpenInNewTab"), false);
			}
			set
			{
				SetValue("OpenInNewTab", value);
			}
		}


		/// <summary>
		/// Custom CSS Class.
		/// </summary>
		[DatabaseField]
		public string CustomCSSClass
		{
			get
			{
				return ValidationHelper.GetString(GetValue("CustomCSSClass"), @"");
			}
			set
			{
				SetValue("CustomCSSClass", value);
			}
		}


		/// <summary>
		/// Custom CSS Class.
		/// </summary>
		[DatabaseField]
		public string DropDownCSSClass
		{
			get
			{
				return ValidationHelper.GetString(GetValue("DropDownCSSClass"), @"");
			}
			set
			{
				SetValue("DropDownCSSClass", value);
			}
		}


		/// <summary>
		/// Additional Button Link.
		/// </summary>
		[DatabaseField]
		public string DropDownButtonLink
		{
			get
			{
				return ValidationHelper.GetString(GetValue("DropDownButtonLink"), @"");
			}
			set
			{
				SetValue("DropDownButtonLink", value);
			}
		}


		/// <summary>
		/// Additional Button Text.
		/// </summary>
		[DatabaseField]
		public string DropDownButtonText
		{
			get
			{
				return ValidationHelper.GetString(GetValue("DropDownButtonText"), @"");
			}
			set
			{
				SetValue("DropDownButtonText", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with MenuItem fields.
		/// </summary>
		[RegisterProperty]
		public MenuItemFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with MenuItem fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class MenuItemFields : AbstractHierarchicalObject<MenuItemFields>
		{
			/// <summary>
			/// The content item of type MenuItem that is a target of the extended API.
			/// </summary>
			private readonly MenuItem mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="MenuItemFields" /> class with the specified content item of type MenuItem.
			/// </summary>
			/// <param name="instance">The content item of type MenuItem that is a target of the extended API.</param>
			public MenuItemFields(MenuItem instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// MenuItemID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.MenuItemID;
				}
				set
				{
					mInstance.MenuItemID = value;
				}
			}


			/// <summary>
			/// Display Name.
			/// </summary>
			public string DisplayName
			{
				get
				{
					return mInstance.DisplayName;
				}
				set
				{
					mInstance.DisplayName = value;
				}
			}


			/// <summary>
			/// Will clicking on this item navigate to a page?.
			/// </summary>
			public bool IsClickable
			{
				get
				{
					return mInstance.IsClickable;
				}
				set
				{
					mInstance.IsClickable = value;
				}
			}


			/// <summary>
			/// Referenced Page.
			/// </summary>
			public string PageReference
			{
				get
				{
					return mInstance.PageReference;
				}
				set
				{
					mInstance.PageReference = value;
				}
			}


			/// <summary>
			/// Open in new tab?.
			/// </summary>
			public bool OpenInNewTab
			{
				get
				{
					return mInstance.OpenInNewTab;
				}
				set
				{
					mInstance.OpenInNewTab = value;
				}
			}


			/// <summary>
			/// Custom CSS Class.
			/// </summary>
			public string CustomCSSClass
			{
				get
				{
					return mInstance.CustomCSSClass;
				}
				set
				{
					mInstance.CustomCSSClass = value;
				}
			}


			/// <summary>
			/// Custom CSS Class.
			/// </summary>
			public string DropDownCSSClass
			{
				get
				{
					return mInstance.DropDownCSSClass;
				}
				set
				{
					mInstance.DropDownCSSClass = value;
				}
			}


			/// <summary>
			/// Additional Button Link.
			/// </summary>
			public string DropDownButtonLink
			{
				get
				{
					return mInstance.DropDownButtonLink;
				}
				set
				{
					mInstance.DropDownButtonLink = value;
				}
			}


			/// <summary>
			/// Additional Button Text.
			/// </summary>
			public string DropDownButtonText
			{
				get
				{
					return mInstance.DropDownButtonText;
				}
				set
				{
					mInstance.DropDownButtonText = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="MenuItem" /> class.
		/// </summary>
		public MenuItem() : base(CLASS_NAME)
		{
			mFields = new MenuItemFields(this);
		}

		#endregion
	}
}