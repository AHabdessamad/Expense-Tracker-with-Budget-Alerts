using ExpenseTrackerDataAccessLayer.Entities;
using SharedDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ExpenseTrackerDataAccessLayer.Repositories.BodgetRepo
{
    public interface IBodgetRepository
    {
        public Task<Bodget> AddBodget(Bodget bodget);
        public Task<Bodget> UpdateBodget(Guid id, BodgetDto bodegtDto);
    }
}
