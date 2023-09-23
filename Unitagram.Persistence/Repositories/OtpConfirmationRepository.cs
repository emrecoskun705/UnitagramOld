using Microsoft.EntityFrameworkCore;
using Unitagram.Application.Contracts.Persistence;
using Unitagram.Domain;
using Unitagram.Persistence.DatabaseContext;

namespace Unitagram.Persistence.Repositories;

public class OtpConfirmationRepository : GenericRepository<OtpConfirmation>, IOtpConfirmationRepository
{
    public OtpConfirmationRepository(UnitagramDatabaseContext context) : base(context)
    {
        
    }

    public async Task<OtpConfirmation?> GetByUserIdAndName(Guid userId, string name)
    {
        var otpConfirmation = await _context.OtpConfirmation
            .Where(o => o.UserId == userId && o.Name == name)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        
        return otpConfirmation;
    }
}