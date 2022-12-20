using HVLC.RentACar.Data.Abstract;
using HVLC.RentACar.Entities.Concrete;
using HVLC.RentACar.Entities.Dtos;
using HVLC.RentACar.Service.Abstract;
using Shared.Result;
using System;
using System.Collections.Generic;

namespace HVLC.RentACar.Service.Concrete
{
    public class CarManager : ICarService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DataResult<List<CarDto>> GetAll()
        {
            var cars = _unitOfWork.Cars.GetAll();
            if (cars.Count > 0)
            {
                List<CarDto> carDtos = new();
                foreach (var item in cars)
                {
                    carDtos.Add(new CarDto
                    {
                        Id = item.Id,
                        KM = item.KM,
                        Brand = item.Brand,
                        Model = item.Model,
                        FuelType = item.FuelType,
                        CarServiceId = item.CarServiceId,
                    });
                }
                return new DataResult<List<CarDto>>(200, carDtos, null);
            }
            else
            {
                return new DataResult<List<CarDto>>(200, null, new List<string>() { "Veritabanında kayıt bulunamadı" }, null);
            }
        }

        public Result Add(CarAddDto carAddDto)
        {
            try
            {
                _unitOfWork.Cars.Add(new Car
                {
                    KM = carAddDto.KM,
                    Brand = carAddDto.Brand,
                    Model = carAddDto.Model,
                    FuelType = carAddDto.FuelType,
                    CarServiceId = carAddDto.CarServiceId,
                });

                _unitOfWork.Save();

                return new Result(200, new List<string>() { "Araba başarıyla eklenmiştir" });
            }
            catch (Exception ex)
            {

                return new Result(500, new List<string>() { "Araba eklenirken teknik bir hata oluştu." }, ex);
            }

        }

        public Result Update(CarUpdateDto carUpdateDto)
        {
            try
            {
                Car currentCar = _unitOfWork.Cars.Get(c => c.Id == carUpdateDto.Id);
                currentCar.KM = carUpdateDto.KM;
                currentCar.Brand = carUpdateDto.Brand;
                currentCar.Model = carUpdateDto.Model;
                currentCar.FuelType = carUpdateDto.FuelType;
                currentCar.CarServiceId = carUpdateDto.CarServiceId;
                currentCar.ModifedBy = 1;
                currentCar.ModifedDate = DateTime.Now;

                _unitOfWork.Cars.Update(currentCar);
                _unitOfWork.Save();

                return new Result(200, new List<string>() { "Araba başarıyla güncellenmiştir." });
            }
            catch (Exception ex)
            {

                return new Result(200, new List<string>() { "Araba güncellenirken teknik bir hata oluşmuştur." }, ex);
            }
        }

        public Result Delete(CarDeleteDto carDeleteDto)
        {
            try
            {
                Car currrentCar = _unitOfWork.Cars.Get(c => c.Id == carDeleteDto.Id);

                _unitOfWork.Cars.HardDelete(currrentCar);
                _unitOfWork.Save();

                return new Result(200, new List<string>() { "Araba başarıyla silinmiştir." });
            }
            catch (Exception ex)
            {

                return new Result(500, new List<string>() { "Araba silinirken teknik bir hata oluşmuştur." }, ex);
            }
        }

        public DataResult<CarDto> Get(CarGetDto carGetDto)
        {
            try
            {
                Car currentCar = _unitOfWork.Cars.Get(c => c.Id == carGetDto.Id);

                CarDto carDto = new()
                {
                    Id = currentCar.Id,
                    KM = currentCar.KM,
                    Brand = currentCar.Brand,
                    Model = currentCar.Model,
                    FuelType = currentCar.FuelType,
                    CarServiceId = currentCar.CarServiceId
                };

                return new DataResult<CarDto>(200, carDto, null);
            }
            catch (Exception ex)
            {

                return new DataResult<CarDto>(500, null, new List<string>() { "Teknik bir hata oluştu" }, ex);
            }
        }
    }
}
