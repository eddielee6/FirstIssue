using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace FirstIssue.WebApp.AppCode.ExtensionMethods
{
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Gets text resource from assembly
        /// MUST BE A public resource or will throw a null reference exception
        /// </summary>        
        public static string GetFileResourceAsString(this Assembly assembly, string resourceName)
        {
            var stream = assembly.GetManifestResourceStream(resourceName);
            string result = "";
            using (var streamReader = new StreamReader(stream))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        /// <summary>
        /// Gets bitmap resource from assembly
        /// MUST BE A public resource or will throw a null reference exception
        /// </summary>        
        public static Bitmap GetBitmapResource(this Assembly assembly, string resourceName)
        {
            var imgStream = assembly.GetManifestResourceStream(resourceName);
            return (Bitmap)Bitmap.FromStream(imgStream);        
        }
    }
}