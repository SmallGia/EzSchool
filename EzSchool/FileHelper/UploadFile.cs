using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace EzSchool.FileHelper
{
    public class UploadFile
    {
        public static bool UploadPhoto(HttpPostedFileBase file, string folder, string name)
        {
            if (file == null || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(folder))
            {
                return false;
            }
            try
            {
                string path = Path.Combine(HttpContext.Current.Server.MapPath(folder), name);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                file.SaveAs(path);
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.ToArray();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}