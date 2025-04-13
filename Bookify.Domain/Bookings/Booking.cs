﻿using Bookify.Domain.Abstraction;
using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings.Events;
using Bookify.Domain.Shared;

namespace Bookify.Domain.Bookings;

public sealed class Booking : Entity
{
    private Booking(
        Guid id,
        Guid apartmentId,
        Guid userId,
        DateRange duration,
        Money priceForPeriod,
        Money cleaningFee,
        Money amenitiesUpcharge,
        Money totalPrice,
        BookingStatus status,
        DateTime createdOnUtc
        ) : base(id)
    {
        ApartmentId = apartmentId;
        UserId = userId;
        DateRange = duration;
        PriceForPeriod = priceForPeriod;
        CleaningFee = cleaningFee;
        AmenitiesUpcharge = amenitiesUpcharge;
        TotalPrice = totalPrice;
        Status = status;
        CreatedOnUtc = createdOnUtc;
    }
    public Guid ApartmentId { get; private set; }
    public Guid UserId { get; private set; }
    public DateRange DateRange { get; private set; }
    public Money PriceForPeriod { get; private set; }
    public Money CleaningFee { get; private set; }
    public Money AmenitiesUpcharge { get; private set; }
    public Money TotalPrice { get; private set; }
    public BookingStatus Status { get; private set; }
    public DateTime? CreatedOnUtc { get; private set; }
    public DateTime? ConfirmedOnUtc { get; private set; }
    public DateTime? RejectedOnUtc { get; private set; }
    public DateTime? CompletedOnUtc { get; private set; }
    public DateTime? CancelledOnUtc { get; private set; }

    public static Booking Reserve(
        Apartment apartment,
        Guid userId,
        DateRange duration,
        DateTime utcNow,
        PricingService pricingService
        )
    {
        var pricingDetails = pricingService.CalculatePrice(apartment, duration);
        var booking = new Booking(
            Guid.NewGuid(),
            apartment.Id,
            userId,
            duration,
            pricingDetails.PriceForPeriod,
            pricingDetails.CleaningFee,
            pricingDetails.AmenitiesUpcharge,
            pricingDetails.TotalPrice,
            BookingStatus.Reserved,
            utcNow
            );
        booking.RaiseDomainEvent(new BookingReservedDomainEvent(booking.Id));

        apartment.LastBookedOnUtc = utcNow;

        return booking; 
    }

}
