using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.ViewModels
{
    public class FileModel
    {
        public IFormFile formFile { get; set; }
    }
}
