using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookshelf.ACore.Abstract;

namespace Bookshelf.Business.Abstract
{
    public interface IFileService
    {
        IReturnException<object> FileUpload(IFormFile file,string filePath, bool directory = false, string fileName = null);
        IReturnException<object> FileRemove(string filePath,bool directory = false);

    }
}
