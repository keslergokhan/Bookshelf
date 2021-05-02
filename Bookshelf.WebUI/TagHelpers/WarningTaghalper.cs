using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.WebUI.TagHelpers
{
    [HtmlTargetElement("warning")]
    public class WarningTaghalper : TagHelper
    {
        /*
            Kullanıcıya uyarı bilgidimi
        */

        private string _Status;

        [HtmlAttributeName("status")]
        public string Status {
            get { return _Status; }
            set {
                if (value == "1" || value == "True" || value == "true")
                    _Status = "success";
                else
                    _Status = "danger";
            } 
        }
       
        [HtmlAttributeName("message")]
        public string Message { get; set; }
        [HtmlAttributeName("title")]
        public string Title { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {


            if (!String.IsNullOrEmpty(Status) && !string.IsNullOrEmpty(Message))
            {
                output.Content.SetHtmlContent("" +
                    "<div class='alert alert-" + Status.ToString() + "' role='alert'>" +
                        " <h6 class='font-weight-bold'> <i class='fa fa-bullhorn'></i>" + Title.ToString()+"</h5>" +
                        Message.ToString() +
                    "</div>" +
                "");
            }
            

            base.Process(context, output);
        }

    }
}
