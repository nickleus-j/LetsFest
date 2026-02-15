using LetsFest.Data.Dto;
using LetsFest.Mysql;

namespace LetsFest.Web.DataService
{
    public class UserProfileService
    {
        private readonly FestContext _context;
        private EfUnitOfWork efWorkUnit;
        public UserProfileService(FestContext context)
        {
            _context = context;
            efWorkUnit = new EfUnitOfWork(_context);
        }
        public async Task<IList<UserProfileDto>> searchUsers(string searchTerm)
        {
            var dbProfiles=await efWorkUnit.UserProfileRepository.SearchForUserAsync(searchTerm);
            var result = AutoMapperConfig.Mapper.Map<IList<UserProfileDto>>(dbProfiles);
            return result;
        }
    }
}
