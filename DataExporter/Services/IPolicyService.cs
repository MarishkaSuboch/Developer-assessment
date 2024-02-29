using DataExporter.Dtos;

namespace DataExporter.Services
{
    public interface IPolicyService
    {
        Task<ReadPolicyDto?> CreatePolicyAsync(CreatePolicyDto createPolicyDto);
        Task<IList<ReadPolicyDto>> ReadPoliciesAsync();
        Task<ReadPolicyDto?> ReadPolicyAsync(int id);
    }
}
