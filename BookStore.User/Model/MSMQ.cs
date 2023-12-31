﻿using Experimental.System.Messaging;
using System.Net.Mail;
using System.Net;

namespace BookStore.User.Model
{
    public class MSMQ
    {
        MessageQueue messageQ = new MessageQueue();

        public void SendData2Queue(string Token)
        {
            messageQ.Path = @".\private$\BookStoreApp";
            if (!MessageQueue.Exists(messageQ.Path))
            {
                MessageQueue.Create(messageQ.Path);
            }

            messageQ.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            messageQ.ReceiveCompleted += MessageQ_ReceiveCompleted;

            messageQ.Send(Token);
            messageQ.BeginReceive();
            messageQ.Close();

        }




        private void MessageQ_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                var msg = messageQ.EndReceive(e.AsyncResult);
                string body = msg.Body.ToString();
                string subject = "BookStore Forgot Password Link";

                var SMTP = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("karandepale111@gmail.com", "wncziksjtwqtgouo"),
                    EnableSsl = true
                };

                SMTP.Send("karandepale111@gmail.com", "karandepale111@gmail.com", subject, body);
                messageQ.BeginReceive();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }

}