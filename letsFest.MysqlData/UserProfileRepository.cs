using LetsFest.Data;
using LetsFest.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace LetsFest.Mysql
{
    public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(DbContext context) : base(context)
        {
        }
        public FestContext festContext
        {
            get { return Context as FestContext; }
        }
        public async Task<IList<UserProfile>> SearchForUserAsync(string searchTerm)
        {
            string loweredTerm = $"%{searchTerm.ToLower()}%";
            var results = festContext.UserProfile
                .Where(p => p.inUse == true
                && (!String.IsNullOrEmpty(p.GivenName) && EF.Functions.Like(p.GivenName.ToLower(), loweredTerm)
                    || !String.IsNullOrEmpty(p.Surname) && EF.Functions.Like(p.Surname.ToLower(), loweredTerm)));
            return await results.ToListAsync();
        }
    }
}
