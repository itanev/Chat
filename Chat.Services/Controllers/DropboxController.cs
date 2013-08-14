using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Chat.Models;
using Chat.Repository;

using Spring.Social.OAuth1;
using Spring.Social.Dropbox.Api;
using Spring.Social.Dropbox.Connect;
using Spring.IO;
using System.Diagnostics;
using System.IO;

namespace Chat.Services.Controllers
{
    public class DropboxController : ApiController
    {
        private Dropbox appAuth = new Dropbox { Value = "5hq4n8kjyopqzje", Secret = "22h4xl0x1g569af" };
        private Dropbox userAuth = new Dropbox { Value = "higmkxi48pfhv8jt", Secret = "0wouwudro53wmkz" };
        private IRepository<Dropbox> data;

        public DropboxController()
        {
            this.data = new DropBoxRepository(
                ConfigurationManager.AppSettings["MongoConnectionString"],
                ConfigurationManager.AppSettings["Database"]);
        }

        public void DropboxShareFile(byte[] byteArr)
        {
            DropboxServiceProvider dropboxServiceProvider =
                new DropboxServiceProvider(this.appAuth.Value, this.appAuth.Secret, AccessLevel.AppFolder);
            IDropbox dropbox = dropboxServiceProvider.GetApi(this.userAuth.Value, this.userAuth.Secret);

            //Entry uploadFileEntry = dropbox.UploadFileAsync(
            //    new FileResource("../../../test.txt"), "test.txt").Result;

            Entry uploadFileEntry = dropbox.UploadFileAsync(
                new ByteArrayResource(byteArr), "test.txt").Result;

            var sharedUrl = dropbox.GetMediaLinkAsync(uploadFileEntry.Path).Result;
            Process.Start(sharedUrl.Url + "?dl=1"); // we can download the file directly
        }

        [HttpPost]
        public void PostFile(string byteArrString)
        {
            var byteArr = GetBytes(byteArrString);
            DropboxShareFile(byteArr);
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}