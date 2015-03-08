namespace SimpleIdentity.Web.Infrastructure.HtmlHelpers
{
    using System.Web.Mvc;
    public static class Buttons
    {
        public static MvcHtmlString SubmitButton(this HtmlHelper helper, string value, object htmlAttributes = null)
        {
            var submitButton = new TagBuilder("input");
            submitButton.AddCssClass("btn btn-primary pull-right");
            submitButton.Attributes.Add("type", "submit");
            submitButton.Attributes.Add("value", value);
            submitButton.ApplyAttributes(htmlAttributes);

            var generatedGroup = FormGroup.GenerateButtonGroup(helper, new MvcHtmlString(submitButton.ToString()));
            return new MvcHtmlString(generatedGroup.ToString());
        }

        private static void ApplyAttributes(this TagBuilder tagBuilder, object htmlAttributes)
        {
            if (htmlAttributes != null)
            {
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                tagBuilder.MergeAttributes(attributes);
            }
        }
    }
}