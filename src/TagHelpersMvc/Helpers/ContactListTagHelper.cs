using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using Microsoft.AspNet.Razor.TagHelpers;
using System.Linq;
using System.Collections.Generic;
using TagHelpersMvc.Models;

namespace TagHelpersMvc.Helpers
{    
    [ContentBehavior(ContentBehavior.Replace)]
    [TagName("contactlist")]
    public class ContactListTagHelper : TagHelper
    {
        [Activate]
        protected internal ViewContext ViewContext { get; set; }

        [HtmlAttributeName("model")]
        public IEnumerable<Contact> For { get; set; }

        #region Templates
        private string template_header = @"
            <div class=""panel panel-default"">
                <div class=""panel-heading"">
                    <span class=""title"">Contacts</span>
                    <ul class=""pull-right c-list"">
                        <li>
                            <a><i class=""glyphicon glyphicon-plus""></i></a>
                      </li>
                    </ul>
                </div>
                <div class=""panel-body"">
                    <ul class=""list-group"">  ";

        private string template_body = @"
            <li class=""list-group-item"">
                <div class=""col-xs-12 col-sm-9"">
                    <span>{0}</span><br />
                    <span>{1}</span><br />
                    <span>{2}</span>
                </div>
                <div class=""clearfix""></div>
            </li>";

        private string template_footer = @"</ul></div></div>";
        #endregion

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.SelfClosing = false;

            if (For == null || !For.Any()) return;
            output.Content = template_header;
            For.ToList().ForEach(c =>
            {
                output.Content += GenerateContainer(c);
            });

            output.Content += template_footer;
        }

        private string GenerateContainer(Contact model)
        {
            return string.Format(template_body, model.Name, model.PhoneNumber, model.DateOfBirth.ToString("MMM dd yyy"));
        }
    }
}