using HVLC.RentACar.Entities.Dtos;
using Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HVLC.RentACar.Service.Abstract
{
    public interface ICarService
    {        
        Result Add(CarAddDto carAddDto);
        Result Update(CarUpdateDto carUpdateDto);
        Result Delete(CarDeleteDto carDeleteDto);
        DataResult<List<CarDto>> GetAll();
        DataResult<CarDto> Get(CarGetDto carGetDto);

        //DataResult<List<CarDto>> Get(Expression<Func<CarDto, bool>> predicate);
        //List<T> GetAll(Expression<Func<T, bool>> predicate);
        //void Add(T entity);
        //void Update(T entity);
        //void Delete(T entity);
        //void HardDelete(T entity);
        //int Count();
        //int Count(Expression<Func<T, bool>> predicate);
        //bool Any(Expression<Func<T, bool>> predicate);
    }
}
