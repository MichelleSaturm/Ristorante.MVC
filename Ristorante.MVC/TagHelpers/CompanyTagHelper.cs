using Microsoft.AspNetCore.Razor.TagHelpers;
using Ristorante.MVC.Models;


namespace Ristorante.MVC.TagHelpers
{
    public class CompanyTagHelper : TagHelper
    {
        public Organization Organization { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("itemscope itemtype", "http://schema.org/Organization");
            output.Content.SetHtmlContent(
                $@"<span itemprop=""name"">{Organization.NomeRistorante}</span>
                <address itemprop=""address""><br />
                <span itemprop=""streetAddress"">{Organization.Indirizzo}</span><br />
                <span itemprop=""addressLocality"">{Organization.Citta}</span><br />
                <span itemprop=""addressRegion"">{Organization.NumeroTelefono}</span>");
            output.Attributes.SetAttribute("class", "row col-5");
        }

    }
}
