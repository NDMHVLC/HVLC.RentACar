using HVLC.RentACar.Data.Abstract;
using HVLC.RentACar.Entities.Concrete;
using HVLC.RentACar.Entities.Dtos;
using HVLC.RentACar.Service.Abstract;
using HVLC.RentACar.Entities.Mapping;
using Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLC.RentACar.Service.Concrete
{
    public class CarServiceManager : ICarServeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarServiceManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Result Add(CarServiceAddDto carServiceAddDto)
        {
            try
            {
                _unitOfWork.CarServicess.Add(carServiceAddDto.ToEntity());
                _unitOfWork.Save();

                return new Result(200, new List<string>() { "Araba bakımı başarılı bir şekilde eklenmiştir" });
            }
            catch (Exception ex)
            {

                return new Result(500, new List<string>() { "Araba bakımı eklenirken teknik bir hata oluştu." }, ex);
            }
        }

        public Result Delete(CarServiceDeleteDto carServiceDeleteDto)
        {
            try
            {
                CarService currentCarService = _unitOfWork.CarServicess.Get(cs => cs.Id == carServiceDeleteDto.Id);
                _unitOfWork.CarServicess.HardDelete(currentCarService);
                _unitOfWork.Save();

                return new Result(200, new List<string>() { "Araba bakım kaydı başarıyla silinmiştir." });
            }
            catch (Exception ex)
            {

                return new Result(500, new List<string>() { "Araba bakım kaydı silinirken teknik bir hata oluştu." }, ex);
            }
        }

        public DataResult<CarServiceDto> Get(CarServiceGetDto carServiceGetDto)
        {
            try
            {
                return new DataResult<CarServiceDto>(200, _unitOfWork.CarServicess.Get(cs=>cs.Id==carServiceGetDto.Id).ToDto(), null);
            }
            catch (Exception ex)
            {
                return new DataResult<CarServiceDto>(500, null, new List<string>() { "Teknik bir hata oluştu" }, ex);
            }
        }

        public DataResult<List<CarServiceDto>> GetAll()
        {
            var carServices = _unitOfWork.CarServicess.GetAll();
            if (carServices.Count > 0)
            {
                return new DataResult<List<CarServiceDto>>(200, carServices.ToDto().ToList(), null);
            }
            else
            {
                return new DataResult<List<CarServiceDto>>(200, null, new List<string>() { "Veritabanında kayıt bulunamadı" }, null);
            }
        }

        public Result Update(CarServiceUpdateDto carServiceUpdateDto)
        {
            try
            {
                CarService currentCarService = _unitOfWork.CarServicess.Get(cs => cs.Id == carServiceUpdateDto.Id);
                currentCarService.EntryDate = carServiceUpdateDto.EntryDate;
                currentCarService.ReleaseDate = carServiceUpdateDto.ReleaseDate;
                currentCarService.Comment = carServiceUpdateDto.Comment;
                currentCarService.ModifedBy = 1;
                currentCarService.ModifedDate = DateTime.Now;

                _unitOfWork.CarServicess.Update(currentCarService);
                _unitOfWork.Save();

                return new Result(200, new List<string>() { "Araba bakımı başarıyla güncallendi" });
            }
            catch (Exception ex)
            {

                return new Result(200, new List<string>() { "Araba bakımı güncellenirken teknik bir hata oluştu" }, ex);
            }
        }
    }
}
