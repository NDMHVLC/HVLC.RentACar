using HVLC.RentACar.Data.Abstract;
using HVLC.RentACar.Entities.Concrete;
using HVLC.RentACar.Entities.Dtos;
using HVLC.RentACar.Entities.Mapping;
using HVLC.RentACar.Service.Abstract;
using Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLC.RentACar.Service.Concrete
{
    public class CustomerManager : ICustomerService
    {

        private readonly IUnitOfWork _unitOfWork;

        public CustomerManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result Add(CustomerAddDto customerAddDto)
        {
            try
            {
                _unitOfWork.Customers.Add(customerAddDto.ToEntity());
                _unitOfWork.Save();

                return new Result(200, new List<string>() { "Kullanıcı başarıyla eklenmiştir" });
            }
            catch (Exception ex)
            {
                return new Result(500, new List<string>() { "Kullanıcı eklenirken teknik bir hata oluştu" }, ex);
            }
           
        }

        public Result Delete(CustomerDeleteDto customerDeleteDto)
        {
            try
            {
                Customer currentCustomer = _unitOfWork.Customers.Get(c=>c.Id== customerDeleteDto.Id);
                _unitOfWork.Customers.HardDelete(currentCustomer);
                _unitOfWork.Save();

                return new Result(200, new List<string>() { "Kullanıcı Başarıyla Silindi" });
            }
            catch (Exception ex)
            {
                return new Result(500, new List<string>() { "Kullanıcı silinirken teknik bir hata oluştu" }, ex);
            }
        }

        public DataResult<CustomerDto> Get(CustomerGetDto customerGetDto)
        {
            try
            {
                return new DataResult<CustomerDto>(200, _unitOfWork.Customers.Get(c => c.Id == customerGetDto.Id).ToDto(), null);
            }
            catch (Exception ex)
            {
                return new DataResult<CustomerDto>(500, null, new List<string>() { "Teknik bir hata oluştu" }, ex);
            }
        }

        public DataResult<List<CustomerDto>> GetAll()
        {
            var customers = (from c in _unitOfWork.Customers.GetAll()
                             join r in _unitOfWork.Reservations.GetAll()
                             on c.ReservationId equals r.Id
                             select new CustomerDto
                             {
                                 Id = c.Id,
                                 TCNo = c.TcNo,
                                 Name = c.Name,
                                 Surname = c.Surname,
                                 EMail = c.EMail,
                                 Password = c.Password,
                                 PhoneNumber = c.PhoneNumber,
                                 Address = c.Address,
                                 ReservationId = c.ReservationId,
                                 Reservation = r.ToDto()
                             }).ToList();

            if (customers.Count > 0)
            {
                return new DataResult<List<CustomerDto>>(200,customers,null);
            }
            else
            {
                return new DataResult<List<CustomerDto>>(200,null,new List<string>() { "Veritabanında Kayıt Bulunamadı"},null);
            }
        }

        public Result Update(CustomerUpdateDto customerUpdateDto)
        {
            try
            {
                Customer currentCustomer = _unitOfWork.Customers.Get(c => c.Id == customerUpdateDto.Id);
                currentCustomer.TcNo=customerUpdateDto.TcNo;
                currentCustomer.Name=customerUpdateDto.Name;
                currentCustomer.Surname=customerUpdateDto.Surname;
                currentCustomer.EMail=customerUpdateDto.EMail;
                currentCustomer.Password=customerUpdateDto.Password;
                currentCustomer.PhoneNumber=customerUpdateDto.PhoneNumber;
                currentCustomer.Address=customerUpdateDto.Address;
                currentCustomer.ReservationId=customerUpdateDto.ReservationId;
                currentCustomer.ModifedBy = 1;
                currentCustomer.ModifedDate=DateTime.Now;

                _unitOfWork.Customers.Update(currentCustomer);
                _unitOfWork.Save();

                return new Result(200, new List<string>() { "Kullanıcı başarıyla güncellendi" });
            }
            catch (Exception ex)
            {
                return new Result(200,new List<string>() { "Kullanıcı güncellenirken teknik bir hata oluştu"},ex);
            }
        }
    }
}
