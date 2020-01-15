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
                string Email = configuration.GetValue<string>("AdminEmail");
                string name = configuration.GetValue<string>("AdminName");
                string title;
                string fileDestDir = env.ContentRootPath;
                fileDestDir = Path.Combine(fileDestDir, "EmailForm");
                string body = string.Empty;
                string fileName;
                if (useremail.Split("@")[1] == "ukr.net") {
                    fileName = Path.Combine(fileDestDir, "AccountConfirmUkrNet.html");
                    title = "Registration";
                }
                else
                {
                    fileName = Path.Combine(fileDestDir, "AccountConfirmGmail.html");
                    title = "Реестрація";
                }

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
                
                body = body.Replace("{UserName}","Vasya" );
                body = body.Replace("{Title}", "koparts.dp.ua");
                body = body.Replace("{Url}", url);
                body = body.Replace("{Description}", "text");
                string command = $"echo '{body}' | " +
                    $"mail " +
                    $"-a \"Content-type: text/html;\" " +
                    $"-s \"{title} - https://koparts.dp.ua/\" " +
                    $"{useremail}  -aFrom:noreply@koparts.dp.ua";
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
