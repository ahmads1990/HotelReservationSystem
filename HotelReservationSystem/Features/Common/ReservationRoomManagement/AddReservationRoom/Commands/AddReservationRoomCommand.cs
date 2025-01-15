using HotelReservationSystem.Common.Enums;
using HotelReservationSystem.Common.views;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Models.ReservationManagement;
using MediatR;

namespace HotelReservationSystem.Features.Common.ReservationRoomManagement.AddReservationRoom.Commands;

public record AddReservationRoomCommand(int roomID, int reservationID, DateTime checkInDate, DateTime? checkOutDate) : IRequest<RequestResult<int>>;

public class AddReservationRoomCommandHandler : IRequestHandler<AddReservationRoomCommand, RequestResult<int>>
{
    private readonly IRepository<ReservationRoom> _repository;

    public AddReservationRoomCommandHandler(IRepository<ReservationRoom> repository)
    {
        _repository = repository;
    }


    public async Task<RequestResult<int>> Handle(AddReservationRoomCommand request, CancellationToken cancellationToken)
    {
        var reservationRoom =  new ReservationRoom
            {
                RoomID = request.roomID,
                ReservationID = request.reservationID,
                CheckInDate = request.checkInDate,
                CheckOutDate = request.checkOutDate,
            };

           
            await _repository.AddAsync(reservationRoom);
            await _repository.SaveChangesAsync();
            
            return  RequestResult<int>.Success(reservationRoom.ID);
    }
}