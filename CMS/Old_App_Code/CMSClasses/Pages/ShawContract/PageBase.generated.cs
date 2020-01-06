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

[assembly: RegisterDocumentType(PageBase.CLASS_NAME, typeof(PageBase))]

namespace CMS.DocumentEngine.Types.ShawContract
{
	/// <summary>
	/// Represents a content item of type PageBase.
	/// </summary>
	public partial class PageBase : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "ShawContract.PageBase";


		/// <summary>
		/// The instance of the class that provides extended API for working with PageBase fields.
		/// </summary>
		private readonly PageBaseFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// PageBaseID.
		/// </summary>
		[DatabaseIDField]
		public int PageBaseID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("PageBaseID"), 0);
			}
			set
			{
				SetValue("PageBaseID", value);
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
		/// Title.
		/// </summary>
		[DatabaseField]
		public string Title
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Title"), @"");
			}
			set
			{
				SetValue("Title", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with PageBase fields.
		/// </summary>
		[RegisterProperty]
		public PageBaseFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with PageBase fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class PageBaseFields : AbstractHierarchicalObject<PageBaseFields>
		{
			/// <summary>
			/// The content item of type PageBase that is a target of the extended API.
			/// </summary>
			private readonly PageBase mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="PageBaseFields" /> class with the specified content item of type PageBase.
			/// </summary>
			/// <param name="instance">The content item of type PageBase that is a target of the extended API.</param>
			public PageBaseFields(PageBase instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// PageBaseID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.PageBaseID;
				}
				set
				{
					mInstance.PageBaseID = value;
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
			/// Title.
			/// </summary>
			public string Title
			{
				get
				{
					return mInstance.Title;
				}
				set
				{
					mInstance.Title = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="PageBase" /> class.
		/// </summary>
		public PageBase() : base(CLASS_NAME)
		{
			mFields = new PageBaseFields(this);
		}

		#endregion
	}
}