using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models;
using Project.Repository;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.StaticFiles;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        IPostRepository postRepository;
        public IHostingEnvironment hostingEnvironment;
        public CUSERSVISHALONEDRIVEDOCUMENTSINTRANPROJECTDBMDFContext db;
        public ResumeController(IPostRepository _postRepository, IHostingEnvironment hostingEnv, CUSERSVISHALONEDRIVEDOCUMENTSINTRANPROJECTDBMDFContext _db)
        {
            postRepository = _postRepository;
            hostingEnvironment = hostingEnv;
            db = _db;
            
        }
        [HttpGet]
        [Route("GetResume")]
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                var resumedata = await postRepository.GetResume();
                if (resumedata == null)
                {
                    return NotFound();
                }

                return Ok(resumedata);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("GetAllResume")]
        public async Task<IActionResult> GetAllResume()
        {
            try
            {
                var resumedata = await postRepository.GetAllResume();
                if (resumedata == null)
                {
                    return NotFound();
                }

                return Ok(resumedata);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("GetCompanyResume")]
        public async Task<IActionResult> GetCompanyResume(Company company)
        {
            try
            {
                var resumedata = await postRepository.GetCompanyResume(company);
                if (resumedata == null)
                {
                    return NotFound();
                }

                return Ok(resumedata);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("GetResumeCount")]
        public async Task<IActionResult> GetResumeCount()
        {
            try
            {
                var count = await postRepository.GetResumeCount();
                if (count == null)
                {
                    return NotFound();
                }

                return Ok(count);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("GetApproveCount")]
        public async Task<IActionResult> GetApproveCount()
        {
            try
            {
                var count = await postRepository.GetApproveCount();
                if (count == null)
                {
                    return NotFound();
                }

                return Ok(count);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("GetPendingCount")]
        public async Task<IActionResult> GetPendingCount()
        {
            try
            {
                var count = await postRepository.GetPendingCount();
                if (count == null)
                {
                    return NotFound();
                }

                return Ok(count);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("Resumeupload")]
        public async Task<IActionResult> Resumeupload([FromForm] Resume data)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    DateTime now = DateTime.Now;
                    // string s2 = now.ToString("dd-MM-yyyy");
                    var files = HttpContext.Request.Form.Files;
                    if (files != null && files.Count > 0)
                    {
                        foreach (var file in files)
                        {
                            FileInfo fi = new FileInfo(file.FileName);
                            var newfilename = data.Candidatename + DateTime.Now.ToString("yyyyMMddHHmmssfff") + fi.Extension;
                            var path = Path.Combine("", hostingEnvironment.WebRootPath + @"D:\Sem7(Project)\Project\Project\Images" + $@"\{newfilename}");
                            
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }
                            //  DateTime input =// dd-MM-yyyy                               
                            data.CreatedAt = now;
                            data.Upload = path;
                            var po = await db.Resume.AddAsync(data);
                            await db.SaveChangesAsync();
                        }
                        return Ok(data);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return BadRequest();
                }

            }
            //Console.WriteLine(e);
            return BadRequest();
        }
        [HttpGet]
        [Route("GetApproveResume")]
        public async Task<IActionResult> GetApproveResume()
        {
            try
            {
                var resumedata = await postRepository.GetApproveResume();
                if (resumedata == null)
                {
                    return NotFound();
                }

                return Ok(resumedata);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("GetApprovedResume")]
        public async Task<IActionResult> GetApprovedResume()
        {
            try
            {
                var resumedata = await postRepository.GetApprovedResume();
                if (resumedata == null)
                {
                    return NotFound();
                }

                return Ok(resumedata);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("GetCompanyApproveResume")]
        public async Task<IActionResult> GetCompanyApproveResume(Company company)
        {
            try
            {
                var resumedata = await postRepository.GetCompanyApproveResume(company);
                if (resumedata == null)
                {
                    return NotFound();
                }

                return Ok(resumedata);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("GetRejectedResume")]
        public async Task<IActionResult> GetRejectedResume()
        {
            try
            {
                var resumedata = await postRepository.GetRejectedResume();
                if (resumedata == null)
                {
                    return NotFound();
                }

                return Ok(resumedata);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("GetResumeReport")]
        public async Task<IActionResult> GetResumeReport()
        {
            try
            {
                var resumedata = await postRepository.GetResumeReport();
                if (resumedata == null)
                {
                    return NotFound();
                }

                return Ok(resumedata);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("GetCompanyReport")]
        public async Task<IActionResult> GetCompanyReport(Company company)
        {
            try
            {
                var resumedata = await postRepository.GetCompanyReport(company);
                if (resumedata == null)
                {
                    return NotFound();
                }

                return Ok(resumedata);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }



        [HttpPost]
        [Route("UpdateRejectResume")]
        public async Task<IActionResult> UpdateRejectResume([FromBody] Resume model)
        {
            try
            {
                var resumedata = await postRepository.UpdateRejectResume(model);
                if (resumedata == null)
                {
                    return NotFound();
                }

                return Ok(resumedata);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("ResumeById")]
        public async Task<IActionResult> ResumeById([FromBody] Resume resume)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var posts = await postRepository.ResumeById(resume);
                    if (posts == null)
                    {
                        return NotFound();
                    }


                    // return RedirectToPage("Display");


                    return Ok(posts);
                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }
            return BadRequest();
        }

        [HttpPost]
        [Route("getpdf")]
        public async Task<IActionResult> getpdf([FromBody] Resume id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var posts = await postRepository.resume(id);
                    if (posts == null)
                    {

                        return NotFound();
                    }


                    var fileName = System.IO.Path.GetFileName(posts);
                    var content = await System.IO.File.ReadAllBytesAsync(posts);
                    new FileExtensionContentTypeProvider()
                        .TryGetContentType(fileName, out string contentType);
                    //byte[] dataB = File.ReadAllBytes(posts);
                    //byte[] dataB = System.Text.Encoding.Unicode.GetBytes(fileName);
                    //FileStream.Close();
                    //
                    //return File(dataB, contentType,content);
                    return new FileContentResult(content, contentType)
                    {
                        FileDownloadName = fileName
                    };
                }

                // return ;


                catch (Exception)
                {
                    return BadRequest();
                }

            }
            return BadRequest();
        }
        [HttpPost]
        [Route("UpdateApproveResume")]
        public async Task<IActionResult> UpdateApproveResume([FromBody] Resume model)
        {
            try
            {
                var resumedata = await postRepository.UpdateApproveResume(model);
                if (resumedata == null)
                {
                    return NotFound();
                }

                return Ok(resumedata);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

    }
}
