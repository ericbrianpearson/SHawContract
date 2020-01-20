﻿using Kentico.Kontent.Delivery;
using ShawContract.Providers.Kontent.Models;
using System;

namespace ShawContract.Providers.Kontent.KontentHandler
{
    public class CustomTypeProvider : ITypeProvider
    {
        public string GetCodename(Type contentType)
        {
            return contentType.Name;
        }

        public Type GetType(string contentType)
        {
            switch (contentType)
            {
                case "blog_entry":
                    return typeof(BlogEntry);

                case "layout__full_width_image":
                    return typeof(FullWidthImage);

                case "modular_content":
                    return typeof(WidenImage);

                case "layout__image_plus_paragraph":
                    return typeof(LayoutImagePlusParagraph);

                default:
                    return null;
            }
        }
    }
}
