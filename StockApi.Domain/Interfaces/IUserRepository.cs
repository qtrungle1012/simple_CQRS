using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockApi.Domain.Entities;

namespace StockApi.Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}