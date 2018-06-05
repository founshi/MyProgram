using Repository;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFunctionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Task.Factory.StartNew(new Func<object, int>(it =>
                {
                    int val = (int)it;
                    Console.WriteLine(val.ToString());
                    return val;
                }), i);

                
            }




         
            Console.WriteLine("按任意键结束程序......");
                

            //Mailer _Mailer = new Mailer()
            //{
            //    CC = "cao_cao@feiliks.com",
            //     Content="这是一份测试邮件",
            //      Attachments=null,
            //       DisplayName="Erric",
            //    From = "erric_shih@feiliks.com",
            //     IsBodyHtml=false,
            //      Password="founshi@2012",
            //       Port=25, Priority= System.Net.Mail.MailPriority.Normal,
            //        SmtpServer="mail.feiliks.com",
            //         Subject="这是一份测试邮件",
            //    To = "cao_cao@feiliks.com,zhiji_gu@feiliks.com"
            //};
            //try
            //{
            //    _Mailer.SendMail();
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine(ex.Message);
            //}
            //Console.WriteLine("邮件发送完成");
            Console.ReadKey();

        }
    }
}
