using AutoMapper;
using MediatR;
using StockApi.Application.Common.Mappings;
using StockApi.Application.Features.Users.DTOs;
using StockApi.Application.Interfaces.Security;
using StockApi.Domain.Interfaces;

namespace StockApi.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }
        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
                throw new Exception("User not found");

            user.MapFromUpdateCommand(request);

            //băm lại nếu có password mới
            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                user.Password = _passwordHasher.HashPassword(request.Password);
            }
            await _userRepository.UpdateAsync(user.Id, user);

            return _mapper.Map<UserDto>(user);
        }
    }
}