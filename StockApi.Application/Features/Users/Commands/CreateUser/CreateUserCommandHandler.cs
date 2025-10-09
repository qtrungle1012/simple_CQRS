using AutoMapper;
using MediatR;
using StockApi.Application.Common.Mappings;
using StockApi.Application.Features.Users.DTOs;
using StockApi.Application.Interfaces.Security;
using StockApi.Domain.Entities;
using StockApi.Domain.Interfaces;

namespace StockApi.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User();
            user.MapFromCreateCommand(request);
            user.Password = _passwordHasher.HashPassword(user.Password); // băm mkhau
            await _userRepository.CreateAsync(user);
             var userDto = _mapper.Map<UserDto>(user);
            return userDto; 
        }
    }
}