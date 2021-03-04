using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        public static string AddAsync(IFormFile file)
        {
            var path = CreateNewPathWithGUI(file);
            try
            {
                var SourcePath = Path.GetTempFileName();
                if (file.Length > 0)
                {
                    using (var stream = new FileStream(SourcePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    } 
                } 
                File.Move(SourcePath, path);              
            }
            catch (Exception exeption)
            {
                return exeption.Message;
            }
            return path;
        }

        public static string UpdateAsync(string sourcePath, IFormFile file)
        {
            var path = CreateNewPathWithGUI(file);
            try
            {
                if (sourcePath.Length > 0)
                {
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                        
                }

                File.Delete(sourcePath);
            }
            catch (Exception exception)
            {

                return exception.Message;
            }
            return path;
        }
        public static IResult DeleteAsync(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception)
            {
                return new ErrorResult("Photo did not delete.");
            }
            return new SuccessResult();
        }

        //  If could not find Images folder in project base, 
        //      creates new folder that is Images with checking "!Directory.Exists(tempPath)".  
        public static string CreateNewPathWithGUI (IFormFile file)
        {
            System.IO.FileInfo FileInfo = new System.IO.FileInfo(file.FileName);
            string FileExtention = FileInfo.Extension;

            var CreatedUniqueFileName = Guid.NewGuid().ToString("N")
                + "_" + DateTime.Now.Day + "_"
                + "_" + DateTime.Now.Month + "_"
                + "_" + DateTime.Now.Year + "_"
                + FileExtention;
            
            string tempPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images");
                        
            if (!Directory.Exists(tempPath))
            {
                Directory.CreateDirectory(tempPath);
            }
             
            string path = $@"{tempPath}\{CreatedUniqueFileName}";

            return path;
        }
    }
}
