using HVLC.RentACar.Data.Abstract;
using HVLC.RentACar.Entities.Concrete;
using HVLC.RentACar.Entities.Dtos;
using HVLC.RentACar.Entities.Mapping;
using HVLC.RentACar.Service.Abstract;
using Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var cars = (from c in _unitOfWork.Cars.GetAll()
                       join cs in _unitOfWork.CarServicess.GetAll()
                       on c.CarServiceId equals cs.Id
                       select new CarDto
                       {
                           Id = c.Id,
                           KM = c.KM,
                           Brand = c.Brand,
                           Model = c.Model,
                           FuelType = c.FuelType,
                           CarServiceId = c.CarServiceId,
                           CarService = cs.ToDto(),
                       }).ToList();

            if (cars.Count > 0)
            {
                return new DataResult<List<CarDto>>(200, cars, null);
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
                _unitOfWork.Cars.Add(carAddDto.ToEntity());

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
                return new DataResult<CarDto>(200, _unitOfWork.Cars.Get(c => c.Id == carGetDto.Id).ToDto(), null);
            }
            catch (Exception ex)
            {

                return new DataResult<CarDto>(500, null, new List<string>() { "Teknik bir hata oluştu" }, ex);
            }
        }
    }
}
