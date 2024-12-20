﻿using Reservation.Domain.Entities;

namespace Reservation.Application.DTOs.Request;

public class GuestRequest
{
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public int ReservationId { get; set; }

    public GuestRequest(string? name, string? lastname)
    {
        Name = name;
        LastName = lastname;
    }
    public static Guest ConvertToEntity(GuestRequest request)
    {
        return new Guest(request.Name, request.LastName);
    }
}
