using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Web.Mvc;

namespace ShawContract
{
    public class ApplicationConfig
    {
        public static void RegisterFeatures(IApplicationBuilder builder)
        {
            // Enable required Kentico features

            builder.UsePreview();
            builder.UsePageBuilder(new PageBuilderOptions()
            {
                DefaultSectionIdentifier = "ShawContract.Sections.DefaultSection",
                RegisterDefaultSection = true
            });
        }
    }
}