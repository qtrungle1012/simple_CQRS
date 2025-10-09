using AutoMapper;
using MediatR;
using StockApi.Application.Features.Users.DTOs;
using StockApi.Domain.Interfaces;

namespace StockApi.Application.Features.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var listUser = await _userRepository.GetAllAsync();
            var listUserDto = _mapper.Map<List<UserDto>>(listUser);
            return listUserDto;
        }
    }
}