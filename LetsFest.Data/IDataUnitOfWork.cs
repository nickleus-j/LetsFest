using System;
using System.Collections.Generic;
using System.Text;

namespace LetsFest.Data
{
    public interface IDataUnitOfWork
    {
        int Complete();
        IEventRoleRepository EventRoles { get; }
        IEventRepository EventRepository { get; }
    }
}
