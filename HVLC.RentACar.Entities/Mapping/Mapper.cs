using HVLC.RentACar.Entities.Concrete;
using HVLC.RentACar.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HVLC.RentACar.Entities.Mapping
{
    public static class Mapper
    {
        #region Car
        public static Car ToEntity(this CarAddDto carAddDto)
        {
            return new Car
            {
                Brand = carAddDto.Brand,
                Model = carAddDto.Model,
                FuelType = carAddDto.FuelType,
                KM = carAddDto.KM,
                CarServiceId = carAddDto.CarServiceId,
            };
        }

        public static CarDto ToDto(this Car car)
        {
            return new CarDto
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                FuelType = car.FuelType,
                KM = car.KM,
                CarServiceId = car.CarServiceId
            };
        }

        public static IEnumerable<CarDto> ToDto(this IEnumerable<Car> car)
        {
            return car.Select(c => c.ToDto());
        }
        #endregion

        #region CarService
        public static CarService ToEntity(this CarServiceAddDto carServiceAddDto)
        {
            return new CarService
            {
                EntryDate = carServiceAddDto.EntryDate,
                ReleaseDate = carServiceAddDto.ReleaseDate,
                Comment = carServiceAddDto.Comment,
            };
        }
        public static CarServiceDto ToDto(this CarService carService)
        {
            return new CarServiceDto
            {
                Id = carService.Id,
                EntryDate = carService.EntryDate,
                ReleaseDate = carService.ReleaseDate,
                Comment = carService.Comment,
            };
        }

        public static IEnumerable<CarServiceDto> ToDto(this IEnumerable<CarService> carServices)
        {
            return carServices.Select(c => c.ToDto());
        }

        #endregion

        #region Reservation
        public static Reservation ToEntity(this ReservationAddDto reservationAddDto)
        {
            return new Reservation
            {
                RentalDate = reservationAddDto.RentalDate,
                DeliveryDate = reservationAddDto.DeliveryDate,
                StartingKm = reservationAddDto.StartingKm,
                FinishKm = reservationAddDto.FinishKm,
                Comment = reservationAddDto.Comment,
                CarId = reservationAddDto.CarId
            };
        }
        public static ReservationDto ToDto(this Reservation reservation)
        {
            return new ReservationDto
            {
                Id = reservation.Id,
                RentalDate = reservation.RentalDate,
                DeliveryDate = reservation.DeliveryDate,
                StartingKm = reservation.StartingKm,
                FinishKm = reservation.FinishKm,
                Comment = reservation.Comment,
                CarId = reservation.CarId
            };
        }

        public static IEnumerable<ReservationDto> ToDto(this IEnumerable<Reservation> reservations)
        {
            return reservations.Select(c => c.ToDto());
        }

        #endregion


        #region Customer

        public static Customer ToEntity(this CustomerAddDto customerAddDto)
        {
            return new Customer
            {
                TcNo = customerAddDto.TcNo,
                Name = customerAddDto.Name,
                Surname = customerAddDto.Surname,
                EMail = customerAddDto.EMail,
                Password = customerAddDto.Password,
                PhoneNumber = customerAddDto.PhoneNumber,
                Address = customerAddDto.Address,
                ReservationId = customerAddDto.ReservationId,
            };
        }

        public static CustomerDto ToDto(this Customer customer)
        {
            return new CustomerDto
            {
                Id = customer.Id,
                TCNo = customer.TcNo,
                Name = customer.Name,
                Surname = customer.Surname,
                EMail = customer.EMail,
                Password = customer.Password,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
                ReservationId = customer.ReservationId,
            };
        }
        public static IEnumerable<CustomerDto> ToDto(this IEnumerable<Customer> customers)
        {
            return customers.Select(c => c.ToDto());
        }

        #endregion
    }
}
