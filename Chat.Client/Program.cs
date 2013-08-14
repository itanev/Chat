using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Repository;
using Chat.Models;
using Chat.Services.Controllers;

namespace Chat.Client
{
    class Program
    {
        static void Main()
        {
            //UsersRepository userRep = new UsersRepository("mongodb://localhost");
            //userRep.Add(new User { UserName = "Pesho", Password = "pesho" });
            //userRep.Add(new User { UserName = "Gosho", Password = "gosho" });
            //userRep.Add(new User { UserName = "Nakov", Password = "nakov" });

            //var users = userRep.All();

            //foreach (var item in users)
            //{
            //    Console.WriteLine(item.UserName);
            //}


            //DropBoxRepository dropboxRepo = new DropBoxRepository("mongodb://localhost");
            //dropboxRepo.Add(new Dropbox { Value = "5hq4n8kjyopqzje", Secret = "22h4xl0x1g569af" });
            //dropboxRepo.Add(new Dropbox { Value = "mightymouse@cloudserv.com", Secret = "telerikacademy" });

            var dropboxController = new DropboxController();
            dropboxController.DropboxShareFile();
        }
    }
}