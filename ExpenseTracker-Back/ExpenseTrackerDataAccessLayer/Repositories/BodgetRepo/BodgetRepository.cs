using ExpenseTrackerDataAccessLayer.Data;
using ExpenseTrackerDataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using SharedDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerDataAccessLayer.Repositories.BodgetRepo
{
    public class BodgetRepository : IBodgetRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BodgetRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Bodget> AddBodget(Bodget bodget)
        {
             await _dbContext.bodgets.AddAsync(bodget);
            _dbContext.SaveChanges();
            return bodget;
        }

        public async Task<Bodget> UpdateBodget(Guid id,BodgetDto bodgetDto)
        {
            var bodget = await _dbContext.bodgets.FirstOrDefaultAsync(b =>  b.Id == id);
            bodget.Balance = bodgetDto.balance;
            _dbContext.bodgets.Update(bodget);
            await _dbContext.SaveChangesAsync();
            return bodget;
        }
    }
}
