using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using StockApi.Application.Features.Users.DTOs;

namespace StockApi.Application.Features.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserDto>
    {
        
    }
}