﻿//--------------------------------------------------------------------------------------------------
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

[assembly: RegisterDocumentType(FinalizeSubmit.CLASS_NAME, typeof(FinalizeSubmit))]

namespace CMS.DocumentEngine.Types.ShawContract
{
    /// <summary>
    /// Represents a content item of type FinalizeSubmit.
    /// </summary>
    public partial class FinalizeSubmit : TreeNode
    {
        #region "Constants and variables"

        /// <summary>
        /// The name of the data class.
        /// </summary>
        public const string CLASS_NAME = "ShawContract.FinalizeSubmit";


        /// <summary>
        /// The instance of the class that provides extended API for working with FinalizeSubmit fields.
        /// </summary>
        private readonly FinalizeSubmitFields mFields;

        #endregion


        #region "Properties"

        /// <summary>
        /// FinalizeSubmitID.
        /// </summary>
        [DatabaseIDField]
        public int FinalizeSubmitID
        {
            get
            {
                return ValidationHelper.GetInteger(GetValue("FinalizeSubmitID"), 0);
            }
            set
            {
                SetValue("FinalizeSubmitID", value);
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
        /// Description.
        /// </summary>
        [DatabaseField]
        public string Description
        {
            get
            {
                return ValidationHelper.GetString(GetValue("Description"), @"");
            }
            set
            {
                SetValue("Description", value);
            }
        }


        /// <summary>
        /// Gets an object that provides extended API for working with FinalizeSubmit fields.
        /// </summary>
        [RegisterProperty]
        public FinalizeSubmitFields Fields
        {
            get
            {
                return mFields;
            }
        }


        /// <summary>
        /// Provides extended API for working with FinalizeSubmit fields.
        /// </summary>
        [RegisterAllProperties]
        public partial class FinalizeSubmitFields : AbstractHierarchicalObject<FinalizeSubmitFields>
        {
            /// <summary>
            /// The content item of type FinalizeSubmit that is a target of the extended API.
            /// </summary>
            private readonly FinalizeSubmit mInstance;


            /// <summary>
            /// Initializes a new instance of the <see cref="FinalizeSubmitFields" /> class with the specified content item of type FinalizeSubmit.
            /// </summary>
            /// <param name="instance">The content item of type FinalizeSubmit that is a target of the extended API.</param>
            public FinalizeSubmitFields(FinalizeSubmit instance)
            {
                mInstance = instance;
            }


            /// <summary>
            /// FinalizeSubmitID.
            /// </summary>
            public int ID
            {
                get
                {
                    return mInstance.FinalizeSubmitID;
                }
                set
                {
                    mInstance.FinalizeSubmitID = value;
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


            /// <summary>
            /// Description.
            /// </summary>
            public string Description
            {
                get
                {
                    return mInstance.Description;
                }
                set
                {
                    mInstance.Description = value;
                }
            }
        }

        #endregion


        #region "Constructors"

        /// <summary>
        /// Initializes a new instance of the <see cref="FinalizeSubmit" /> class.
        /// </summary>
        public FinalizeSubmit() : base(CLASS_NAME)
        {
            mFields = new FinalizeSubmitFields(this);
        }

        #endregion
    }
}