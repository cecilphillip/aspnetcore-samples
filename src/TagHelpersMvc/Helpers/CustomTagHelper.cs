using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using Microsoft.AspNet.Razor.TagHelpers;
using System;
using TagHelpersMvc.Models;

namespace TagHelpersMvc.Helpers
{
	//TODO: TagHelper From Database
	//TODO: TagHellper Custom Element
	//TODO: Contact card
	//[ContentBehavior(ContentBehavior.Modify)]
	public class CustomTagHelper : TagHelper
	{
		[Activate]
		protected internal ViewContext ViewContext { get; set; }

		[Activate]
		protected internal IHtmlGenerator Generator { get; set; }

		[HtmlAttributeName("custom-model")]
		public ModelExpression For { get; set; }
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "div";
			var content = output.Content;
			var inner = output.GenerateContent();
			var endTag = output.GenerateEndTag();
			var forString = For.Metadata;

			var anti = Generator.GenerateAntiForgery(ViewContext);


		}
	}
}