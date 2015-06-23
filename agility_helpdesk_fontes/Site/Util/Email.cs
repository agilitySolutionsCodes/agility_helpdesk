using System;
using System.IO;
using System.Net;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Net.Mail;
using System.Net.Mime;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace AgilityHelpDesk.Util
{
    public class EmailSite
    {
        #region Métodos

        public void SendEmail(string para, string assunto, string mensagem, string caminhoHtml, string nomeUsuario, string novaSenha, DateTime dataEmail)
        {
            string hostSmtp = ConfigurationManager.AppSettings["smtpHost"];
            int portaSmtp = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]);
            string mailFrom = ConfigurationManager.AppSettings["mailFrom"];
            string smtpUser = ConfigurationManager.AppSettings["smtpUser"];
            string smtpPass = ConfigurationManager.AppSettings["smtpPass"];

            MailAddress mailfrom = new MailAddress(mailFrom);
            MailAddress mailto = new MailAddress(para);
            MailMessage mailMessage = new MailMessage(mailfrom, mailto);

            SmtpClient smtp = new SmtpClient(hostSmtp);
            smtp.Port = portaSmtp;

            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["enableSsl"]);
            NetworkCredential credential = new NetworkCredential(smtpUser, smtpPass);
            smtp.Credentials = credential;

            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = assunto;
            mailMessage.Body = mensagem;

            smtp.Send(mailMessage);

            smtp.Dispose();
        }

        #endregion
    }
}