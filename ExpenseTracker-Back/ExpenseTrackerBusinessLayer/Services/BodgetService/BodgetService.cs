using ExpenseTrackerDataAccessLayer.Entities;
using ExpenseTrackerDataAccessLayer.Repositories.BodgetRepo;
using SharedDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerBusinessLayer.Services.BodgetService
{
    public class BodgetService : IBodgetService
    {
        private readonly IBodgetRepository _bodegtRepository;

        public BodgetService(IBodgetRepository bodegtRepository)
        {
            _bodegtRepository = bodegtRepository;
        }
        public async Task<Bodget> AddBodget(BodgetDto bodgetDto)
        {
            var bodget = new Bodget {Balance = bodgetDto.balance, Date = DateTime.UtcNow };
            return await _bodegtRepository.AddBodget(bodget);
        }

        public async Task<Bodget> UpdateBodget(Guid id, BodgetDto bodgetDto)
        {
            return await _bodegtRepository.UpdateBodget(id, bodgetDto);
        }
    }
}
