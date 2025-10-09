using MediatR;
using StockApi.Application.Features.Users.DTOs;

namespace StockApi.Application.Features.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<List<UserDto>>
    {
        
    }
}