using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace RBI.BUS
{
    class sendEmail
    {
        NetworkCredential login;
        SmtpClient client;
        MailMessage msg;

       public void senEmail()
        {
            login = new NetworkCredential("anhvu01011994", "01011994");
            client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.Credentials = login;
            msg = new MailMessage { From = new MailAddress("anhvu01011994@gmail.com", "VuNA", Encoding.UTF8) };
            msg.To.Add(new MailAddress("kimanh.bn2795@gmail.com"));
            msg.Subject = "RBI Completed Calculator";
            String body = "Dữ liệu của bạn đã được tính toán xong. File kết quả ở địa chỉ sau: ";

            msg.Body = body + "https://www.dropbox.com/preview/Lab_Associates%20Team%20Folder/RBI/Output/RiskSummary.xls";
            System.Net.Mail.Attachment attach = new Attachment(@"C:\Users\VuNA\Dropbox\Lab_Associates Team Folder\RBI\Output\RiskSummary.xls");
            msg.Attachments.Add(attach);

            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;
            msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.Send(msg);
        }
    }
}
