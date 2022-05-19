using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        public IHostingEnvironment hostingEnvironment;
        public CUSERSVISHALONEDRIVEDOCUMENTSINTRANPROJECTDBMDFContext dbContext;
        public ProfileController(IHostingEnvironment hostingEnv, CUSERSVISHALONEDRIVEDOCUMENTSINTRANPROJECTDBMDFContext db)
        {
            hostingEnvironment = hostingEnv;
            dbContext = db;
        }
        [HttpPost]
        /*public ActionResult<string> UploadImages()
        {
            try 
            {
                var files = HttpContext.Request.Form.Files;
                if(files!=null && files.Count>0)
                {
                   foreach(var file in files)
                    {
                        FileInfo fi = new FileInfo(file.FileName);
                        var newfilename = "Image_" + DateTime.Now.TimeOfDay.Milliseconds + fi.Extension;
                        var path = Path.Combine("",hostingEnvironment.ContentRootPath+"\\Images\\"+newfilename);
                        using (var stream=new FileStream(path,FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        Imageupload imageupload = new Imageupload();
                        imageupload.imagepath = path;
                        imageupload.InsertedOn = DateTime.Now;
                        dbContext.Imageupload.Add(imageupload);
                        dbContext.SaveChanges();
                    }
                    return "Saved Successfully";
                }
                else
                {
                    return "Select a file";
                }
            }
            catch(Exception e1)
            {
                return e1.Message;
            }
        }*/
        [HttpGet]
        public ActionResult<List<Imageupload>> GetImageUpload()
        {
            var result = dbContext.Imageupload.ToList();
            return result;
        }
    }
}
