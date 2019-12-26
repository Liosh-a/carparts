using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CarParts.Domain.Services.Implementation
{
    public class CreateEmailString
    {
        public static void SendAccountConfirm(IConfiguration configuration,
            IHostingEnvironment env, string url,string useremail)
        {
            try
            {
                string adminEmail = configuration.GetValue<string>("AdminEmail");
                string name = configuration.GetValue<string>("AdminName");
                string text = "Ви успішно зарееструвалися на нашому сайті. Будь ласка перейдіть за посиланням для активації вашого аккаунта.";
                string title = "Реестрація";
                string fileDestDir = env.ContentRootPath;
                fileDestDir = Path.Combine(fileDestDir, "EmailForm");
                string fileName = Path.Combine(fileDestDir, "AccountConfirm.html");
                string body = string.Empty;
                using (StreamReader reader = new StreamReader(fileName))
                {
                    var str = string.Empty;
                    do
                    {
                        str = reader.ReadLine();
                        body += str + " ";
                    }
                    while (str != null);
                    //body = reader.ReadToEnd();
                }
                body = body.Replace("{UserName}", name);
                body = body.Replace("{Title}", "Сайт koparts.dp.ua");
                body = body.Replace("{Url}", "hello");
                body = body.Replace("{Description}", text);
                string command = $"echo 'zator' | " +
                    $"mail " +
                    $"-a \"Content-type: text/html;\" " +
                    $"-s \"{title} - https://koparts.dp.ua/\" " +
                    $"{useremail}  -aFrom:root@koparts.dp.ua";
                Console.WriteLine($"Send email to User {command}");
                File.WriteAllLines("message.txt", new string[] { command });
                var output = command.Bash();
            }
            catch (Exception ex)
            {
                Console.WriteLine("---problem message send Ф---" + ex.Message);
            }
        }
    }
}
