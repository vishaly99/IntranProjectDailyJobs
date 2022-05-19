using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models;
namespace Project.Repository
{
    public interface IPostRepository
    {
        Task<object> LOGIN(Login data);
        Task<List<Company>> GetCompanies();
        Task<List<Company>> GetCompanyById(Company company);
        Task<List<Company>> CompanyById(Company company);
        Task<List<Resume>> ResumeById(Resume resume);
        Task<int> GetCompaniesCount();
        Task<int?> GetCompanyPoints(Company company);
        Task<int> GetCompanyResumeCount(Company company);
        Task<int> GetCompanyApproveCount(Company company);
        Task<int> GetCompanyPendingCount(Company company);
        Task<object> AddCompany(Company company);
        Task<int> UpdateProfile(Company data);
        Task<int> UpdateCompanyDetails(Company company);
        Task<int> UpdateCompany(Company company);
        Task<List<Resume>> GetResume();
        Task<List<Resume>> GetAllResume();
        Task<List<Resume>> GetCompanyResume(Company company);
        Task<List<Resume>> GetApproveResume();
        Task<List<Resume>> GetApprovedResume();
        Task<List<Resume>> GetCompanyApproveResume(Company company);
        
        Task<List<Resume>> GetRejectedResume();
        Task<List<Company>> GetApproveCompany();
        Task<List<Company>> GetRejectedCompany();
        Task<List<Resume>> GetResumeReport();
        Task<List<Resume>> GetCompanyReport(Company company);
        Task<int> GetResumeCount();
        Task<int> GetApproveCount();
        Task<int> GetPendingCount();
        Task<int> UpdateApproveCompany(Company company);
        Task<int> UpdateApproveResume(Resume resume);
        Task<int> UpdateRejectCompany(Company company);
        Task<int> UpdateRejectResume(Resume resume);
        Task<string> resume(Resume id);
        Task<List<Company>> GetAdminData(Company val);

        Task<int> DeductCompanyPoints(Company company);
    }
}
