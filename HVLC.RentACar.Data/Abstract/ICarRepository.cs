using HVLC.RentACar.Entities.Concrete;
using Shared.Data.Abstract;
using Shared.Data.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLC.RentACar.Data.Abstract
{
    public interface ICarRepository : IRepository<Car>
    {

    }
}
