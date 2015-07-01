using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace VillaBisutti.Delta.Core
{
    public class Email
    {
        public String Assunto
        {
            get;
            set;
        }
        public String CorpoEmail
        {
            get;
            set;
        }
        public String Remetente 
        {
            get
            {
                return Util.Get<string>("Remetente");
            }
        }

        public List<String> Destinatario
        {
            get;
            set;
        }
        public List<String> CCO
        {
            get;
            set;
        }
        public String EnderecoSMTP 
        {
            get 
            { 
                return Util.Get<string>("EnderecoSMTP"); 
            }
        }
        public int Porta 
        {
            get
            {
                return Util.Get<int>("Porta");
            }
        }
        public String Usuario 
        {
            get
            {
                return Util.Get<string>("Usuario");
            }
        }
        public String Senha 
        {
            get
            {
                return Util.Get<string>("Senha");
            }
        }
        public List<Attachment> Anexos { get; set; }
        public String NomedoRemetente
        {
            get;
            set;
        }

        public void SendMail()
        {
            MailMessage message = new MailMessage();
            SmtpClient client = new SmtpClient();
            foreach (Attachment item in Anexos)
            {
                message.Attachments.Add(item);
            }
            message.Body = CorpoEmail;
            message.From = new MailAddress(Remetente, NomedoRemetente, Encoding.UTF8);
            message.Subject = Assunto;
            if (Destinatario.Count > 0)
            {
                foreach (string item in Destinatario)
                {
                    MailAddress to = new MailAddress(item, String.IsNullOrEmpty(NomedoRemetente) ? null : NomedoRemetente);
                    message.To.Add(item);
                }
            }
            if (CCO.Count > 0)
            {
                foreach (string item in CCO)
                {
                    MailAddress bcc = new MailAddress(item, String.IsNullOrEmpty(NomedoRemetente) ? null : NomedoRemetente);
                    message.Bcc.Add(bcc);
                }
            }
            client.Credentials = new System.Net.NetworkCredential(Usuario, Senha);
            client.Host = EnderecoSMTP;
            client.Port = Porta;
            client.Send(message);
            //TODO: Implentar os exceptions de erro ao enviar e-mail
        }
    }
}
