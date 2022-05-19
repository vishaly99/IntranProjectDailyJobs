using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models;
using Project.Repository;


namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostRepository postRepository;
        public PostController(IPostRepository _postRepository)
        {
            postRepository = _postRepository;
        }
        
        [HttpGet]
        [Route("GetCompanies")]
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                var companies = await postRepository.GetCompanies();
                if (companies == null)
                {
                    return NotFound();
                }

                return Ok(companies);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("GetAdminData")]
        public async Task<IActionResult> GetAdminData(Company val)
        {
            try
            {
                var companies = await postRepository.GetAdminData(val);
                if (companies == null)
                {
                    return NotFound();
                }

                return Ok(companies);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("GetCompanyPoints")]
        public async Task<IActionResult> GetCompanyPoints(Company val)
        {
            try
            {
                var companies = await postRepository.GetCompanyPoints(val);
                if (companies == null)
                {
                    return NotFound();
                }

                return Ok(companies);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("GetCompanyResumeCount")]
        public async Task<IActionResult> GetCompanyResumeCount(Company val)
        {
            try
            {
                var companies = await postRepository.GetCompanyResumeCount(val);
                if (companies == null)
                {
                    return NotFound();
                }

                return Ok(companies);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("GetCompanyApproveCount")]
        public async Task<IActionResult> GetCompanyApproveCount(Company val)
        {
            try
            {
                var companies = await postRepository.GetCompanyApproveCount(val);
                if (companies == null)
                {
                    return NotFound();
                }

                return Ok(companies);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("GetCompanyPendingCount")]
        public async Task<IActionResult> GetCompanyPendingCount(Company val)
        {
            try
            {
                var companies = await postRepository.GetCompanyPendingCount(val);
                if (companies == null)
                {
                    return NotFound();
                }

                return Ok(companies);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("GetCompaniesCount")]
        public async Task<IActionResult> GetCompaniesCount()
        {
            try
            {
                var count = await postRepository.GetCompaniesCount();
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
        [Route("AddCompany")]
        public async Task<IActionResult> AddCompany([FromBody] Company model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var posts = await postRepository.AddCompany(model);
                    if(posts==null)
                    {
                        return NotFound();
                    }
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
        [Route("UpdateProfile")]
        public async Task<IActionResult> UpdateProfile([FromBody] Company company)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var posts = await postRepository.UpdateProfile(company);
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
        [Route("UpdateCompany")]
        public async Task<IActionResult> UpdateCompany([FromBody] Company company)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var posts = await postRepository.UpdateCompany(company);
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
        [Route("log")]
        public async Task<IActionResult> LOGIN([FromBody] Login data1)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var posts = await postRepository.LOGIN(data1);
                    if (posts == null)
                    {

                        return Ok(1);
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
        [Route("UpdateCompanyDetails")]
        public async Task<IActionResult> UpdateCompanyDetails([FromBody] Company company)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var posts = await postRepository.UpdateCompanyDetails(company);
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
        [Route("GetCompanyById")]
        public async Task<IActionResult> GetCompanyById([FromBody] Company company)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var posts = await postRepository.GetCompanyById(company);
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
        [Route("CompanyById")]
        public async Task<IActionResult> CompanyById([FromBody] Company  company)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var posts = await postRepository.CompanyById(company);
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
        [HttpGet]
        [Route("GetApproveCompany")]
        public async Task<IActionResult> GetApproveCompany()
        {
            try
            {
                var companydata = await postRepository.GetApproveCompany();
                if (companydata == null)
                {
                    return NotFound();
                }

                return Ok(companydata);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("GetRejectedCompany")]
        public async Task<IActionResult> GetRejectedCompany()
        {
            try
            {
                var companydata = await postRepository.GetRejectedCompany();
                if (companydata == null)
                {
                    return NotFound();
                }

                return Ok(companydata);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("UpdateApproveCompany")]
        public async Task<IActionResult> UpdateApproveCompany([FromBody] Company model)
        {
            try
            {
                var companydata = await postRepository.UpdateApproveCompany(model);
                if (companydata == null)
                {
                    return NotFound();
                }

                return Ok(companydata);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("UpdateRejectCompany")]
        public async Task<IActionResult> UpdateRejectCompany([FromBody] Company model)
        {
            try
            {
                var companydata = await postRepository.UpdateRejectCompany(model);
                if (companydata == null)
                {
                    return NotFound();
                }

                return Ok(companydata);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("DeductCompanyPoints")]
        public async Task<IActionResult> DeductCompanyPoints(Company company)
        {
            try
            {
                var companydata = await postRepository.DeductCompanyPoints(company);
                if (companydata == null)
                {
                    return NotFound();
                }

                return Ok(companydata);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

    }
}
