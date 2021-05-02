using Microsoft.AspNetCore.Http;
using Bookshelf.Business.Abstract;
using Bookshelf.ACore.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookshelf.ACore.Concrete;

namespace Bookshelf.Business.Concrete
{
    public class FileService : IFileService
    {

        IReturnException<object> IFileService.FileRemove(string filePath, bool directory)
        {
            IReturnException<object> returnException = new ReturnException<object>();

            try
            {
                string fileDirectory;
                fileDirectory = directory == true ? Directory.GetCurrentDirectory().Replace("\\", "/") + filePath.Replace("\\", "/") : filePath;

                if (File.Exists(fileDirectory))
                {
                    File.Delete(fileDirectory);
                    if (File.Exists(fileDirectory))
                    {
                        returnException.Status = false;
                        returnException.Message = "File.Delete işlemi uygulandı ama resim silinemedi !";
                        returnException.Data = fileDirectory;
                        return returnException;
                    }
                    else
                    {
                        returnException.Status = true;
                        returnException.Message = "Resim silindi !";
                        returnException.Data = fileDirectory;
                        return returnException;
                    }
                }else
                {
                    returnException.Status = true;
                    returnException.Message = "Silmek istediğiniz resim zaten yok !";
                    returnException.Data = fileDirectory;
                    return returnException;
                    
                }

            }
            catch (Exception e)
            {

                returnException.SetReturnException(Status:false,Exception:e,Message:"Teknik bir sıkıntı oluştu",Data:filePath);
                return returnException;
            }

        }

        IReturnException<object> IFileService.FileUpload(IFormFile file, string filePath, bool directory = false, string fileName = null)
        {
            IReturnException<object> returnException = new ReturnException<object>();
            try
            {
                string newFileName;
                string fileDirectory;

                if (file != null && file.Length > 0)
                {
                    string[] T = { "Ş", "ş", "ğ", "Ğ", "İ", "ı", "ç", "Ç", " ", "\\" };

                    if (fileName != null && fileName.Length > 0)
                    {
                        newFileName = fileName + Path.GetExtension(file.FileName);
                        foreach (var item in T)
                        {
                            newFileName = newFileName.Replace(item, "-");
                        }
                    }
                    else
                    {
                        newFileName = file.FileName;
                        foreach (var item in T)
                        {
                            newFileName = newFileName.Replace(item, "-");
                        }

                    }

                    Random random = new Random();
                    newFileName = $"{random.Next(1, 99999)}-{newFileName}";
                    fileDirectory = directory == true ? Directory.GetCurrentDirectory().Replace("\\", "/") + filePath.Replace("\\", "/") : filePath;
                    string newSevePath = Path.Combine(fileDirectory, newFileName).Replace("\\", "/");

                    using (var stream = new FileStream(newSevePath, FileMode.Create))
                    {

                        file.CopyTo(stream);
                    }

                    returnException.Status = true;
                    returnException.Message = newFileName + " Resim yüklendi ";
                    returnException.Data = newFileName;
                    return returnException;
                }
                else
                {
                    returnException.Status = true;
                    returnException.Message = "Resim gönderilmedi !";
                    returnException.Data = file;
                    return returnException;
                }

            }
            catch (Exception e)
            {
                returnException.SetReturnException(Status: false, Exception: e, Message: "Teknik bir sıkıntı oluştu", Data: file);
                return returnException;
            }
        }
    }
}
