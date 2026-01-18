using System;
using System.Collections.Generic;
using System.Text;

namespace LetsFest.Data
{
    public interface IDataWorkUnit
    {
        int Complete();
        IEventRoleRepository EventRoles { get; }
    }
}
