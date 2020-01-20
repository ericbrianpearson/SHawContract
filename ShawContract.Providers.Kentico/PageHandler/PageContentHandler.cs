using CMS.DocumentEngine;
using ShawContract.Application.Contracts.Infrastructure;
using System;

namespace ShawContract.Providers.Kentico.PageHandler
{
    public class PageContentHandler : IPageContentHandler
    {
        private ISiteContextService SiteContextService { get; }

        private readonly string[] coreColumns = new string[]
        {
            "NodeGUID",
            "NodeId",
            "DocumentID"
        };

        public PageContentHandler(ISiteContextService siteContextService)
        {
            this.SiteContextService = siteContextService;
        }

        public DocumentQuery<T> GetPages<T>() where T : TreeNode, new()
        {
            var query = DocumentHelper.GetDocuments<T>();
            query = query.Columns(coreColumns)
                .OnSite(this.SiteContextService.SiteName)
                .Published()
                .PublishedVersion()
                .Culture(this.SiteContextService.CurrentSiteCulture);

            return query;
        }

        public DocumentQuery<T> GetPage<T>(Guid nodeGuid) where T : TreeNode, new()
        {
            return GetPages<T>()
                .TopN(1)
                .WhereEquals("NodeGUID", nodeGuid);
        }

        public DocumentQuery<T> GetPage<T>(string pageAlias) where T : TreeNode, new()
        {
            return DocumentHelper.GetDocuments<T>()
                .TopN(1)
                .WhereEquals("NodeAlias", pageAlias);
        }
    }
}