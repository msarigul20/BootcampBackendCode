using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    //mine code 
    public class FileHelper
    {
        public static string AddAsync(IFormFile file)
        {
            var guidPath = CreateNewPathWithGUI(file);
            string fullPath = Environment.CurrentDirectory + "\\wwwroot\\images\\"+guidPath;
            string folderPath = Environment.CurrentDirectory + "\\wwwroot\\images\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string shortFolderPath = "\\images\\";
            string imagePath = $@"{shortFolderPath}{guidPath}";
            string urlImagePath = imagePath.Replace("\\", "/");
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
                File.Move(SourcePath, fullPath);
            }
            catch (Exception exeption)
            {
                return exeption.Message;
            }
            return urlImagePath;
        }

        public static string UpdateAsync(string sourcePath, IFormFile file)
        {
            var guidPath = CreateNewPathWithGUI(file);
            string fullPath = Environment.CurrentDirectory + "\\wwwroot\\images\\"+guidPath;
            string folderPath = Environment.CurrentDirectory + "\\wwwroot";
            string urlImageFolder = "/images/";
            try
            {
                if (sourcePath.Length > 0)
                {
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                }
                string deletedPath = sourcePath.Replace("/","\\");
                deletedPath = folderPath + deletedPath;
                File.Delete(deletedPath);
            }
            catch (Exception exception)
            {

                return exception.Message;
            }
            return urlImageFolder + guidPath;
        }
        public static IResult DeleteAsync(string path)
        {
            string fullPath = Environment.CurrentDirectory + "\\wwwroot";
            path = path.Replace("/", "\\");
            string deletedPath = fullPath + path;

            try
            {
                File.Delete(deletedPath);
            }
            catch (Exception e)
            {
                return new ErrorResult("Photo did not delete because "+ e.Message);
            }
            return new SuccessResult();
        }

        // not working for now  If could not find Images folder in project base, 
        //      creates new folder that is Images with checking "!Directory.Exists(tempPath)".  
        public static string CreateNewPathWithGUI(IFormFile file)
        {

            System.IO.FileInfo FileInfo = new System.IO.FileInfo(file.FileName);
            string FileExtention = FileInfo.Extension;

            var CreatedUniqueFileName = Guid.NewGuid().ToString("N")
                + "_" + DateTime.Now.Day + "_"
                + "_" + DateTime.Now.Month + "_"
                + "_" + DateTime.Now.Year + "_"
                + FileExtention.ToString();
            return CreatedUniqueFileName;
        }
    }
}
