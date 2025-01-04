using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.ViewModels;
using MediatR;

namespace HotelReservationSystem.Features.RoomManagement.RoomTypes.Queries.GetAllRoom
{
    public class GetAllRoomTypeHandler : IRequestHandler<GetAllRoomTypeQuery, ResponseDTO>
    {
        private readonly IRepository<RoomType> _roomRepo;
        private ResponseDTO _responseDTO;

        public GetAllRoomTypeHandler(IRepository<RoomType> roomRepo)
        {
            _roomRepo = roomRepo;
            _responseDTO = new ResponseDTO();
        }

        public async Task<ResponseDTO> Handle(GetAllRoomTypeQuery request, CancellationToken cancellationToken)
        {
            var roomType = _roomRepo.GetAll()
                .Select(x => new GetAllRoomTypeDto
                {
                    RoomTypeName = x.Name,
                    Price = x.Price
                }).ToList();

            if (!roomType.Any())
            {
                _responseDTO.Message = "Not Found";
                return _responseDTO;
            }

            _responseDTO.Result = roomType;
            _responseDTO.Message = "Data Retieve Sucess ";
            return _responseDTO;
        }
    }
}
