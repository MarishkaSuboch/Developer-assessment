using AutoMapper;
using DataExporter.Dtos;
using DataExporter.Model;
using Microsoft.EntityFrameworkCore;


namespace DataExporter.Services
{
    public class PolicyService: IPolicyService
    {
        private ExporterDbContext _dbContext;
        private readonly IMapper _mapper;
        public PolicyService(ExporterDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }

        /// <summary>
        /// Creates a new policy from the DTO.
        /// </summary>
        /// <param name="createPolicyDto"></param>
        /// <returns>Returns a ReadPolicyDto representing the new policy, if succeded. Returns null, otherwise.</returns>
        public async Task<ReadPolicyDto?> CreatePolicyAsync(CreatePolicyDto createPolicyDto)
        {
            var result = await _dbContext.Policies.AddAsync(_mapper.Map<Policy>(createPolicyDto));
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return _mapper.Map<ReadPolicyDto>(result.Entity);
        }

        /// <summary>
        /// Retrives all policies.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a list of ReadPoliciesDto.</returns>
        public async Task<IList<ReadPolicyDto>> ReadPoliciesAsync()
        {
            var res = await _dbContext.Policies.Select(p => _mapper.Map<ReadPolicyDto>(p)).ToArrayAsync();
            return res;
        }

        /// <summary>
        /// Retrieves a policy by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a ReadPolicyDto.</returns>
        public async Task<ReadPolicyDto?> ReadPolicyAsync(int id)
        {
            var policy = await _dbContext.Policies.FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<ReadPolicyDto>(policy);
        }
    }
}
