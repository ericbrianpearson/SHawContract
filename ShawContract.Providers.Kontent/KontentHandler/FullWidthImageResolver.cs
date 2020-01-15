using Kentico.Kontent.Delivery.InlineContentItems;
using ShawContract.Providers.Kontent.Models;
using System.Linq;

namespace ShawContract.Providers.Kontent.KontentHandler
{
    public class FullWidthImageResolver : IInlineContentItemsResolver<FullWidthImage>
    {
        const string template = @"<section class=""container mb-3 mb-md-5 article-full-width-image d-flex justify-content-center"">
            <img src = ""{0}"" alt=""{1}"" class=""img-fluid"">
        </section>";
        public FullWidthImageResolver()
        {

        }
        public string Resolve(FullWidthImage data)
        {
            return string.Format(template, data.Image.First().ImageUrl, data.Image.FirstOrDefault().AltText);
        }
    }
}
