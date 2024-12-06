using ExpenseTrackerDataAccessLayer.Entities;
using SharedDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerBusinessLayer.Services.BodgetService
{
    public interface IBodgetService
    {
        public Task<Bodget> AddBodget(BodgetDto bodgetDto);
        public Task<Bodget> UpdateBodget(Guid id, BodgetDto bodgetDto);
    }
}
