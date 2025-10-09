using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockApi.Application.Features.Users.Commands.CreateUser;
using StockApi.Application.Features.Users.Commands.UpdateUser;
using StockApi.Application.Interfaces.Security;
using StockApi.Domain.Entities;

namespace StockApi.Application.Common.Mappings
{
    public static class UserMapper
    {
        
        public static void MapFromCreateCommand(this User user, CreateUserCommand request)
        {
            user.Username = request.Username;
            user.FullName = request.FullName;
            user.Password = request.Password;
            user.Email = request.Email;
        }
        
        public static void MapFromUpdateCommand(this User user, UpdateUserCommand request)
        {
            if (!string.IsNullOrWhiteSpace(request.FullName))
                user.FullName = request.FullName;

            if (!string.IsNullOrWhiteSpace(request.Email))
                user.Email = request.Email;

            // Chỉ băm và cập nhật nếu có password mới
            if (!string.IsNullOrWhiteSpace(request.Password))
                user.Password = request.Password;
        }
    }
}