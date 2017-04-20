using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OperationsWithFiles.Controllers
{
    public class FileController : ApiController
    {
        // GET: api/File
        public IEnumerable<string> Get()
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\Testing");
            var files = directory.GetFiles().Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden)).Select(f => f.Name).ToArray();
            return files;
        }

        // GET: api/File/5
        public string Get(string name)
        {
            string path = Path.Combine(@"C:\Testing", name);
            StreamReader sr = File.OpenText(path);
            string textline = sr.ReadLine();
            sr.Close();
            return textline;
            // bad practice //
            //HttpResponseMessage response = new HttpResponseMessage();
            //response.Content = new StringContent(textline);
            //return response;
        }

        // POST: api/File
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/File/5
        public void Put(string name, [FromBody]string value)
        {
        }

        // DELETE: api/File/5
        public void Delete(string name)
        {
            string fileName = Path.Combine(@"C:\Testing", name);

            string[] files = Directory.GetFiles(@"C:\Testing");

            foreach (string file in files)
            {
                if (file.ToUpper().Contains(fileName.ToUpper()))
                {
                    File.Delete(file);
                }
            }
        }
    }
}
