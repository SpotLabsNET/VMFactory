using VMFactory.Api.Core.Log;

namespace VMFactory.Api.Core.Configuration
{
    class Defaults
    {

        // fill in the necessary defaults
        public const string DEFAULT_LOG_TITLE = "VM Factory Cloud Service";
        public const int DEFAULT_LOG_PRIORITY = 5;
        public const LogCategory DEFAULT_LOG_CATEGORY = LogCategory.Database;
        public const System.Diagnostics.TraceEventType DEFAULT_TRACEEVENT_TYPE = System.Diagnostics.TraceEventType.Information;

        public const string DEFAULT_PRODUCT_TRANSLATION_FORMAT = "{0}({1})";


        public const string DEFAULT_OutgoingEmailSmtpServer = "smtp.live.com";
        public const string DEFAULT_OutgoingEmailSmtpUser = "vmfactory@outlook.com";

        //TODO: Encrypt
        public const string DEFAULT_OutgoingEmailSmtpPassword = "@Pass@word1";
        public const string DEFAULT_OutgoingEmailFromAddress = "vmfactory@outlook.com";

    }
}
