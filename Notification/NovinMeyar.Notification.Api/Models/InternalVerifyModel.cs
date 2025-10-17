using System.Collections.Generic;

namespace NovinMeyar.Notification.Api.Models
{
    public class Parameter
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class InternalVerifyModel
    {
        public string Mobile { get; set; }
        public string TemplateId { get; set; }
        public List<Parameter> Parameters { get; set; }
    }

    public class CustomMessageModel
    {
        public string LineNumber => "30004505505050";
        public string MessageText { get; set; }
        public List<string> Mobiles { get; set; }
    }
}
