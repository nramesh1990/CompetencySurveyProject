﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace CompetencySurveyProject.Infrastucture.Repository
{
    public class NotifyUser
    {
        private static string SendMail(string toMailAddr, string emailSubject, string emailBody)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();
                message.From = new MailAddress("cmsvcqa@gmail.com");
                message.To.Add(new MailAddress(toMailAddr));
                message.Subject = emailSubject;
                message.IsBodyHtml = false;
                message.Body = emailBody;
                smtpClient.Port = 587;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("cmsvcqa@gmail.com", "A1rWatch");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Send(message);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string SendUserActicationEmail(string userName, string toMailAddr, string userId, string OTP)
        {
            string emailSubject = "User Account Added";
            string emailBody = "Dear " + userName + ", \n\n Welcome to competency assessment.\n" +
                "Please use the below credentials to access the application \n" + 
                "User ID: " + userId + " \n OTP: " + OTP + " \n" +
                "\n Shortly we will send you the assessment scheduling.";
            return SendMail(toMailAddr, emailSubject, emailBody);
        }

        public static string SendOTPToUser(string toMailAddr, string OTP)
        {
            string emailSubject = "Password Reset OTP";
            string emailBody = "Please use the below OTP to reset your password \n " +
                "OTP: " + OTP;
            return SendMail(toMailAddr, emailSubject, emailBody);
        }
    }
}