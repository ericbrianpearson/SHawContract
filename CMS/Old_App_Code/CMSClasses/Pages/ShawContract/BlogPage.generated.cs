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

[assembly: RegisterDocumentType(BlogPage.CLASS_NAME, typeof(BlogPage))]

namespace CMS.DocumentEngine.Types.ShawContract
{
	/// <summary>
	/// Represents a content item of type BlogPage.
	/// </summary>
	public partial class BlogPage : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "ShawContract.BlogPage";


		/// <summary>
		/// The instance of the class that provides extended API for working with BlogPage fields.
		/// </summary>
		private readonly BlogPageFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// BlogsID.
		/// </summary>
		[DatabaseIDField]
		public int BlogsID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("BlogsID"), 0);
			}
			set
			{
				SetValue("BlogsID", value);
			}
		}


		/// <summary>
		/// blog page title.
		/// </summary>
		[DatabaseField]
		public string PageTitle
		{
			get
			{
				return ValidationHelper.GetString(GetValue("PageTitle"), @"");
			}
			set
			{
				SetValue("PageTitle", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with BlogPage fields.
		/// </summary>
		[RegisterProperty]
		public BlogPageFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with BlogPage fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class BlogPageFields : AbstractHierarchicalObject<BlogPageFields>
		{
			/// <summary>
			/// The content item of type BlogPage that is a target of the extended API.
			/// </summary>
			private readonly BlogPage mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="BlogPageFields" /> class with the specified content item of type BlogPage.
			/// </summary>
			/// <param name="instance">The content item of type BlogPage that is a target of the extended API.</param>
			public BlogPageFields(BlogPage instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// BlogsID.
			/// </summary>
			public int BlogsID
			{
				get
				{
					return mInstance.BlogsID;
				}
				set
				{
					mInstance.BlogsID = value;
				}
			}


			/// <summary>
			/// blog page title.
			/// </summary>
			public string PageTitle
			{
				get
				{
					return mInstance.PageTitle;
				}
				set
				{
					mInstance.PageTitle = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="BlogPage" /> class.
		/// </summary>
		public BlogPage() : base(CLASS_NAME)
		{
			mFields = new BlogPageFields(this);
		}

		#endregion
	}
}