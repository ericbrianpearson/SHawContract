using Kentico.Kontent.Delivery.InlineContentItems;
using ShawContract.Providers.Kontent.Models;
using System.Linq;

namespace ShawContract.Providers.Kontent.KontentHandler
{
    public class ImagePlusParagraphResolverLinkResolver : IInlineContentItemsResolver<LayoutImagePlusParagraph>
    {
        string template = @"<section class=""container mb-3 mb-md-5 article-{0}-image"">
                        <div class=""row align-items-center"">
                            <div class=""col-12 col-lg-5"">
                                <img src=""{1}"" alt=""{2}"" class=""img-fluid""/>
                            </div>
                            <div class=""col-12 col-lg-7"">
                                    {3}
                            </div>
                        </div>
                    </section>";
        public ImagePlusParagraphResolverLinkResolver()
        {

        }
        public string Resolve(LayoutImagePlusParagraph data)
        {
            var image = data.Image.FirstOrDefault();
            var location = data.ImageLocation.FirstOrDefault();
            return string.Format(template,
                location.Codename,
                image.ImageUrl,
                image.AltText,
                data.Paragraph
                );
        }
    }
}
