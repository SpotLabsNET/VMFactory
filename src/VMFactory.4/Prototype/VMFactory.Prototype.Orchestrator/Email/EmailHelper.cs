using System;
using System.Collections.Generic;
using System.Text;
using VMFactory.Api.Core.Configuration;
using VMFactory.Api.Data.Models;

namespace VMFactory.Prototype.Orchestrator.Email
{
    public static class EmailHelper
    {


        /// <summary>
        /// Sends the confirmation email.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        /// <param name="files">The files.</param>
        /// <returns></returns>
        public static void SendConfirmationEmail(
            string displayName, 
            string destinationEmail, 
            ICollection<VMOutput> files)
        {

            StringBuilder emailFileList = new StringBuilder();
            foreach (VMOutput file in files)
            {
                emailFileList.Append(String.Format("<TR><TD><a href=\"{0}\">{1}</a></TD><TD>{2}</TD></TR>", file.DownloadUrl, file.FileName, file.CreatedOn));
            }

            VMFactory.Api.Core.Helper.Email.SendEmail(
                DefaultConfigurationStore.Current.OutgoingEmailSmtpServer,
                DefaultConfigurationStore.Current.OutgoingEmailFromAddress,
                destinationEmail,
                "VM Factory: VM Completed",
                VMRequestEmailTemplate.vMRequestEmailTemplatebody.Replace("{{ROWS}}", emailFileList.ToString()),
                new System.Net.NetworkCredential(DefaultConfigurationStore.Current.OutgoingEmailSmtpUser, DefaultConfigurationStore.Current.OutgoingEmailSmtpPassword),
                true
                );

        }




    }
}
