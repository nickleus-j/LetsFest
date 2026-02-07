using LetsFest.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsFest.Data
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {
        Task<IList<UserProfile>> SearchForUserAsync(string searchTerm);
    }
}
