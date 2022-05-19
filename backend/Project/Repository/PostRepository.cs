using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Project.Repository
{
    public class PostRepository:IPostRepository
    {
        CUSERSVISHALONEDRIVEDOCUMENTSINTRANPROJECTDBMDFContext db;
        public PostRepository(CUSERSVISHALONEDRIVEDOCUMENTSINTRANPROJECTDBMDFContext _db)
        {
            db = _db;
        }
        public async Task<List<Company>> GetCompanies()
        {
            if (db != null)
            {
                return await db.Company.ToListAsync();
                /*var result = await db.Company.ToListAsync();
                var CompanyCount = result.Count();
                return result;*/
            }
            return null;
        }
        public async Task<List<Company>> GetCompanyById(Company company)
        {
            try
            {
                if (db != null)
                {
                    return await db.Company.Where(x => x.Email == company.Email).ToListAsync();
                    /*var result = await db.Company.ToListAsync();
                    var CompanyCount = result.Count();
                    return result;*/
                }
                return null;
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
            return null;
        }
        public async Task<List<Company>> CompanyById(Company company)
        {
            try
            {
                if (db != null)
                {
                    return await db.Company.Where(x => x.Id == company.Id).ToListAsync();
                    /*var result = await db.Company.ToListAsync();
                    var CompanyCount = result.Count();
                    return result;*/
                }
                return null;
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
            return null;
        }
        public async Task<List<Resume>> ResumeById(Resume resume)
        {
            try
            {
                if (db != null)
                {
                    return await db.Resume.Where(x => x.ResumeId == resume.ResumeId).ToListAsync();
                    /*var result = await db.Company.ToListAsync();
                    var CompanyCount = result.Count();
                    return result;*/
                }
                return null;
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
            return null;
        }

        public async Task<List<Company>> GetAdminData(Company val)
        {
            try
            {
                if (db != null)
                {
                    return await db.Company.Where(x => x.Email == val.Email).ToListAsync();
                    /*var result = await db.Company.ToListAsync();
                    var CompanyCount = result.Count();
                    return result;*/
                }
                return null;
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
            return null;
        }
        public async Task<int> GetCompaniesCount()
        {
            if (db != null)
            {
                //return await db.Company.ToListAsync();
                var result = await db.Company.ToListAsync();
                var CompanyCount = result.Count();
                return CompanyCount;
            }
            return 0;
        }
        public async Task<int?> GetCompanyPoints(Company company)
        {
            if (db != null)
            {
               
                var points =await db.Company.Where(p => p.Email.Contains(company.Email)).ToListAsync();
                
                return points[0].Points;

            }
            return 0;
        }
        public async Task<int> GetCompanyResumeCount(Company company)
        {
            if (db != null)
            {
                //return await db.Company.ToListAsync();
                var result = await db.Resume.Where(x=>x.CompanyUsername.Contains(company.Email)).ToListAsync();
                var ResumeCount = result.Count();
                return ResumeCount;
            }
            return 0;
        }
        public async Task<int> GetCompanyApproveCount(Company company)
        {
            if (db != null)
            {
                //return await db.Company.ToListAsync();
                var result = await db.Resume.Where(x => x.CompanyUsername.Contains(company.Email) && x.Approved==1).ToListAsync();
                var ResumeCount = result.Count();
                return ResumeCount;
            }
            return 0;
        }
        public async Task<int> GetCompanyPendingCount(Company company)
        {
            if (db != null)
            {
                //return await db.Company.ToListAsync();
                var result = await db.Resume.Where(x => x.CompanyUsername.Contains(company.Email) && x.Approved == 0).ToListAsync();
                var ResumeCount = result.Count();
                return ResumeCount;
            }
            return 0;
        }
        public async Task<object> AddCompany(Company company)
        {
            int result = 0;
            try
            {


                if (db != null)

                {
                    DateTime now = DateTime.Now;
                    List<Company> data = new List<Company>();
                    if (data == null)
                    {
                        return "null";
                    }

                    //db.Company.Add(company);
                    company.CreatedAt = now;
                    company.Points = 0;
                    await db.Company.FromSql("EXEC[dbo].[insertcompany] @company_username={0},@company_name={1},@password={2},@state={3},@city={4},@address={5},@email={6},@contactno={7},@type={8},@status={9},@points={10},@website={11},@linkdin={12},@glassdoor={13},@role={14},@created_at={15},@is_test={16},@ins_by={17},@ins_dt={18},@upd_by={19},@upd_dt={20},@del_by={21},@det_dt={22}", company.CompanyUsername, company.CompanyName, company.Password, company.State, company.City, company.Address, company.Email, company.Contactno,company.Type, company.Status, company.Points,company.Website,company.Linkdin,company.Glassdoor,company.Role,company.CreatedAt, company.IsTest, company.InsBy, company.InsDt, company.UpdBy, company.UpdDt, company.DelBy, company.DetDt).ToListAsync();
                    //await db.Company.FromSql("EXEC[dbo].[insertlogin] @email={0},@password={1},@status={2}",company.Email,company.Password,company.Status).ToListAsync();
                    //var r = await db.Query('insert into login email,password,status ) values('company.Email,company.Password,company.Status )'');
                    // await db.SaveChangesAsync();
                    //await db.SaveChangesAsync();
                    return "success";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return result;


        }
        public async Task<int> UpdateCompany(Company data)
        {
            try 
            {
                if (db != null)
                {
                    
                    Login objlogin = new Login();
                    
                    var objData = db.Company.Where(x => x.Email == data.Email).AsEnumerable().FirstOrDefault();
                    var objloginData = db.Login.Where(x => x.Email ==data.Email).AsEnumerable().FirstOrDefault();
                    if (objData != null)
                    {
                        objData.Password = data.Password;

                        db.Company.Update(objData);

                        //Commit the transaction
                        await db.SaveChangesAsync();

                        if(objloginData != null)
                        {
                            objloginData.Password = data.Password;

                            db.Login.Update(objloginData);

                            //Commit the transaction
                            await db.SaveChangesAsync();
                            return objloginData.Id;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    
                    return 0;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }
        public async Task<int> UpdateCompanyDetails(Company data)
        {
            try
            {
                if (db != null)
                {

                    var objData = db.Company.Where(x => x.Id == data.Id).AsEnumerable().FirstOrDefault();
                    if (objData != null)
                    {
                        objData.CompanyName = data.CompanyName;
                        objData.Address = data.Address;
                        objData.Email = data.Email;
                        objData.Contactno = data.Contactno;
                        objData.Type = data.Type;
                        objData.State = data.State;
                        objData.City = data.City;
                        objData.Website = data.Website;
                        objData.Linkdin = data.Linkdin;
                        objData.Glassdoor = data.Glassdoor;
                        db.Company.Update(objData);

                        //Commit the transaction
                        await db.SaveChangesAsync();
                        return objData.Id;
       
                    }

                    return 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }
        public async Task<int> UpdateProfile(Company data)
        {
            try
            {
                if (db != null)
                {

                   

                    var objData = db.Company.Where(x => x.Email == data.Email).AsEnumerable().FirstOrDefault();
                    //var objloginData = db.Login.Where(x => x.Email == data.Email).AsEnumerable().FirstOrDefault();
                    if (objData != null)
                    {
                        objData.Contactno = data.Contactno;
                        objData.State = data.State;
                        objData.City = data.City;
                        objData.Address = data.Address;

                        db.Company.Update(objData);

                        //Commit the transaction
                        await db.SaveChangesAsync();
                        return objData.Id;
                        /*if (objloginData != null)
                        {
                            objloginData.Email = data.Email;

                            db.Login.Update(objloginData);

                            //Commit the transaction
                            await db.SaveChangesAsync();
                            return objloginData.Id;
                        }
                        else
                        {
                            return 0;
                        }*/
                    }

                    return 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }
        public async Task<List<Resume>> GetResume()
        {
            if (db != null)
            {
                return await db.Resume.ToListAsync();
            }
            return null;
        }
        public async Task<List<Resume>> GetAllResume()
        {
            if (db != null)
            {
                return await db.Resume.ToListAsync();
            }
            return null;
        }
        public async Task<List<Resume>> GetCompanyResume(Company company)
        {
            if (db != null)
            {
                return await db.Resume.Where(x=>x.CompanyUsername.Contains(company.Email)).ToListAsync();
            }
            return null;
        }
        public async Task<List<Resume>> GetApproveResume()
        {
            if (db != null)
            {
                return await db.Resume.Where(x => x.Approved == 0).ToListAsync();
            }
            return null;
        }
        public async Task<List<Resume>> GetApprovedResume()
        {
            if (db != null)
            {
                return await db.Resume.Where(x => x.Approved == 1).ToListAsync();
            }
            return null;
        }
        public async Task<List<Resume>> GetCompanyApproveResume(Company company)
        {
            if (db != null)
            {
                return await db.Resume.Where(x => x.Approved == 1 && x.CompanyUsername == company.Email).ToListAsync();
            }
            return null;
        }
        public async Task<List<Resume>> GetRejectedResume()
        {
            if (db != null)
            {
                return await db.Resume.Where(x => x.Approved == 2).ToListAsync();
            }
            return null;
        }
        public async Task<List<Company>> GetApproveCompany()
        {
            if (db != null)
            {
                return await db.Company.Where(x =>x.Status== 0).ToListAsync();
            }
            return null;
        }
        public async Task<List<Company>> GetRejectedCompany()
        {
            if (db != null)
            {
                return await db.Company.Where(x => x.Status == 2).ToListAsync();
            }
            return null;
        }
        public async Task<int> GetResumeCount()
        {
            if (db != null)
            {
                //return await db.Company.ToListAsync();
                var result = await db.Resume.ToListAsync();
                var ResumeCount = result.Count();
                return ResumeCount;
            }
            return 0;
        }
        public async Task<int> GetApproveCount()
        {
            if (db != null)
            {
                //return await db.Company.ToListAsync();
                var result = await db.Resume.ToListAsync();
                var approve = db.Resume.Where(x => x.Approved == 1).Count();
                var ApproveCount = result.Count();
                return approve;
            }
            return 0;
        }
        public async Task<int> GetPendingCount()
        {
            if (db != null)
            {
                //return await db.Company.ToListAsync();
                var result = await db.Resume.ToListAsync();
                var pending = db.Resume.Where(x => x.Approved == 0).Count();
                return pending;
            }
            return 0;
        }
        

      
        public async Task<object> LOGIN(Login data)
        {
            string result = null;

            if (db != null)
            {


                List<Login> lst = new List<Login>();
                if (data == null)
                {
                    return "null";
                }
                //var baseItem = db.Login.FromSqlRaw("EXEC[dbo].[usp_Login] @email={0},@pass={1}", data.Email, data.Password);
               lst = await db.Login.FromSql("EXEC[dbo].[usp_Login] @email={0},@pass={1}", data.Email, data.Password).ToListAsync();
                var count = lst.Count;
                if (count>0)
                {
                    var role = db.Login.Where(x => x.Email == data.Email).AsEnumerable().FirstOrDefault();
                    return role;
                    //return new JsonResult();
                }
                else
                {
                    return null;
                }
                //await db.SaveChangesAsync();

                //return db.output.FromSqlRaw(lst).ToListAsync();
                //return new JsonResult(lst);

            }

            return result;
        }
        public async Task<List<Resume>> GetResumeReport()
        {
            if (db != null)
            {
                return await db.Resume.ToListAsync();
            }
            return null;
        }
        
        public async Task<List<Resume>> GetCompanyReport(Company company)
        {
            if (db != null)
            {
                return await db.Resume.Where(x =>x.CompanyUsername.Equals(company.Email)).ToListAsync();
            }
            return null;
        }
        public async Task<string> resume(Resume data)
        {
     
            if (db != null)
            {
                try
                {

                    var objectdata = db.Resume.Where(x => x.Id == data.Id).AsEnumerable().FirstOrDefault();
                    return objectdata.Upload;


                }
                catch
                {
                    return null;
                }
            }

            return null;
        }
    

    public async Task<int> UpdateApproveCompany(Company Company)
        {
            try
            {
                if (db != null)
                {

                    var objData = db.Company.Where(x => x.Email == Company.Email).AsEnumerable().FirstOrDefault();
                    if (objData != null)
                    {
                        objData.Status = 1;
                        db.Company.Update(objData);
                        await db.SaveChangesAsync();
                        if (objData.Status==1)
                        {
                            Login lst = new Login();
                            lst.Email = objData.Email;
                            lst.Password = objData.Password;
                            lst.Role = objData.Role;
                            lst.Status = 0;
                            await db.Login.AddAsync(lst);
                            await db.SaveChangesAsync();
                            if(lst.Status==0)
                            {
                                DateTime now = DateTime.Now;
                                ApproveCompany approveCompany = new ApproveCompany();
                                approveCompany.CompanyId = objData.Id;
                                approveCompany.CompanyName = objData.CompanyName;
                                approveCompany.Password = objData.Password;
                                approveCompany.State = objData.State;
                                approveCompany.City = objData.City;
                                approveCompany.Address = objData.Address;
                                approveCompany.Email = objData.Email;
                                approveCompany.Contactno = objData.Contactno;
                                approveCompany.Type = objData.Type;
                                approveCompany.Status = objData.Status;
                                approveCompany.Points = objData.Points;
                                approveCompany.Website = objData.Website;
                                approveCompany.Linkdin = objData.Linkdin;
                                approveCompany.Glassdoor = objData.Glassdoor;
                                approveCompany.Role = objData.Role;
                                approveCompany.ApproveAt = now;
                                db.ApproveCompany.Add(approveCompany);
                                await db.SaveChangesAsync();
                            }
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    return 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }
        public async Task<int> UpdateApproveResume(Resume resume)
        {
            
            try
            {
                if (db != null)
                {

                    var objData = db.Resume.Where(x => x.ResumeId == resume.ResumeId).AsEnumerable().FirstOrDefault();
                    var objCompany = db.Company.Where(x => x.Email == objData.CompanyUsername).AsEnumerable().FirstOrDefault();
                    if (objData != null && objCompany != null)
                    {
                        objData.Approved = 1;
                        db.Resume.Update(objData);
                        await db.SaveChangesAsync();
                        if (objData.Approved == 1)
                        {
                            //int pointsdata = objCompany.Points;
                            objCompany.Points = objCompany.Points + 5;
                            db.Company.Update(objCompany);
                            await db.SaveChangesAsync();
                            if(objData.Approved==1)
                            {
                                DateTime now = DateTime.Now;
                                ApproveResume approveresume = new ApproveResume();
                                approveresume.Resumeid = objData.Id;
                                approveresume.Companyid = objData.CompanyUsername;
                                approveresume.Candidatename = objData.Candidatename;
                                approveresume.Gender = objData.Gender;
                                approveresume.Skill = objData.Skill;
                                approveresume.Contactno = objData.PhoneNumber;
                                approveresume.Email = objData.Email;
                                approveresume.Country = "India";
                                approveresume.State = objData.State;
                                approveresume.City = objData.City;
                                approveresume.Dateofbirth = objData.Dob;
                                approveresume.Highestqualification = objData.Highestqulification;
                                approveresume.Previouscompany = objData.Previouscompany;
                                approveresume.Approved = objData.Approved;
                                approveresume.ApproveAt = now;
                                db.ApproveResume.Add(approveresume);
                                await db.SaveChangesAsync();
                            }
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    return 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }
        public async Task<int> UpdateRejectCompany(Company Company)
        {
            try
            {
                if (db != null)
                {

                    var objData = db.Company.Where(x => x.Email == Company.Email).AsEnumerable().FirstOrDefault();
                    if (objData != null)
                    {
                        objData.Status = 2;
                        db.Company.Update(objData);
                        await db.SaveChangesAsync();
                        if(objData.Status==2)
                        { 
                        DateTime now = DateTime.Now;
                                RejectedCompany rejectedCompany = new RejectedCompany();
                                rejectedCompany.CompanyId = objData.Id;
                        rejectedCompany.CompanyName = objData.CompanyName;
                        rejectedCompany.Password = objData.Password;
                        rejectedCompany.State = objData.State;
                        rejectedCompany.City = objData.City;
                        rejectedCompany.Address = objData.Address;
                        rejectedCompany.Email = objData.Email;
                        rejectedCompany.Contactno = objData.Contactno;
                        rejectedCompany.Type = objData.Type;
                        rejectedCompany.Status = objData.Status;
                        rejectedCompany.Points = objData.Points;
                        rejectedCompany.Website = objData.Website;
                        rejectedCompany.Linkdin = objData.Linkdin;
                        rejectedCompany.Glassdoor = objData.Glassdoor;
                        rejectedCompany.Role = objData.Role;
                        rejectedCompany.RejectedAt = now;
                                db.RejectedCompany.Add(rejectedCompany);
                                await db.SaveChangesAsync();
                        }

                    }
                    return 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }


        public async Task<int> UpdateRejectResume(Resume resume)
        {
            try
            {
                if (db != null)
                {

                    var objData = db.Resume.Where(x => x.ResumeId == resume.ResumeId).AsEnumerable().FirstOrDefault();
                    if (objData != null)
                    {
                        objData.Approved = 2;
                        db.Resume.Update(objData);
                        await db.SaveChangesAsync();
                        if (objData.Approved == 2)
                        {
                            DateTime now = DateTime.Now;
                            RejectedResume rejectedResume = new RejectedResume();
                            rejectedResume.Resumeid = objData.Id;
                            rejectedResume.Companyid = objData.CompanyUsername;
                            rejectedResume.Candidatename = objData.Candidatename;
                            rejectedResume.Gender = objData.Gender;
                            rejectedResume.Skill = objData.Skill;
                            rejectedResume.Contactno = objData.PhoneNumber;
                            rejectedResume.Email = objData.Email;
                            rejectedResume.Country = "India";
                            rejectedResume.State = objData.State;
                            rejectedResume.City = objData.City;
                            rejectedResume.Dateofbirth = objData.Dob;
                            rejectedResume.Highestqualification = objData.Highestqulification;
                            rejectedResume.Previouscompany = objData.Previouscompany;
                            rejectedResume.Approved = objData.Approved;
                            rejectedResume.RejectedAt = now;
                            db.RejectedResume.Add(rejectedResume);
                            await db.SaveChangesAsync();
                        }

                    }
                    return 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }

        public async Task<int> DeductCompanyPoints(Company company)
        {
            try
            {
                if (db != null)
                {
                    var companydata=db.Company.Where(x=>x.Email.Equals(company.Email)).AsEnumerable().FirstOrDefault();
                    if (companydata.Points > 0)
                    {
                        if (companydata != null)
                        {
                            var count = companydata.Points - 5;
                            companydata.Points = count;
                            db.Company.Update(companydata);
                            await db.SaveChangesAsync();
                            return 1;
                        }
                    }

                    return 0;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
            return 0;
        }

    }
}
