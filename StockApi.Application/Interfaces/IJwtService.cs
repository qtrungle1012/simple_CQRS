using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockApi.Application.Features.Auth.DTOs;
using StockApi.Domain.Entities;

namespace StockApi.Application.Interfaces
{
    public interface IJwtService
    {
        TokenResponse GenerateToken(User user);
    }
}