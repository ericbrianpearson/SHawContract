using CMS.DocumentEngine;
using System;

namespace ShawContract.Providers.Kentico.PageHandler
{
    public interface IPageContentHandler
    {
        DocumentQuery<T> GetPage<T>(Guid nodeGuid) where T : TreeNode, new();

        DocumentQuery<T> GetPages<T>() where T : TreeNode, new();

        DocumentQuery<T> GetPage<T>(string pageAlias) where T : TreeNode, new();
    }
}