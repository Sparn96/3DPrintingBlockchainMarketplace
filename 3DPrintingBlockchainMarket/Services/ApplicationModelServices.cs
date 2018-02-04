using _3DPrintingBlockchainMarket.Data;
using _3DPrintingBlockchainMarket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DPrintingBlockchainMarket.Services
{
    /// <summary>
    /// Create the Database service for the Object model type using the base implementaiton
    /// </summary>
    public interface IObjectModelService : IBasicService<ObjectModel>
    {
        List<ObjectModel> Search(params string[] tags);
    }
    public interface ILicenseService : IBasicService<ModelLicense>
    {

    }
    public interface IAuthTokenService : IBasicService<AuthorizationToken>
    {

    }
    public interface IConsumableLicense : IBasicService<ConsumableLicense>
    {
        bool ConsumeUse(Guid token_user);
    }

    public class ConsumableLicenseService : BasicServiceImplementation<ConsumableLicense>, IConsumableLicense
    {
        public ConsumableLicenseService(ApplicationDbContext ctx, UserManager<ApplicationUser> um) : base(ctx, um)
        {

        }

        public bool ConsumeUse(Guid token_user)
        {
            try
            {
                var con = _context.ConsumableLicense.FirstOrDefault(f => f.IdConsumableLicense == token_user);
                
                if (con.NumberOfUses == 0)
                {
                    con.IsDeleted = true;
                    con.DateDeleted = con.DateDeleted ?? DateTime.UtcNow;
                    _context.Update(con);
                    _context.SaveChanges();
                    return false;
                }
                else
                {
                    con.NumberOfUses--;
                    _context.Update(con);
                    _context.SaveChanges();
                    return true;
                }
                
            }
            catch
            {
                return false;
            }
        }
    }
    public class AuthTokenService : BasicServiceImplementation<AuthorizationToken>, IAuthTokenService
    {
        public AuthTokenService(ApplicationDbContext ctx, UserManager<ApplicationUser> um) : base(ctx, um)
        {

        }
    }
    public class LicenseService : BasicServiceImplementation<ModelLicense> , ILicenseService
    {
        public LicenseService(ApplicationDbContext ctx, UserManager<ApplicationUser> um) : base(ctx, um)
        {

        }
    }
    public class ObjectModelService : BasicServiceImplementation<ObjectModel> ,IObjectModelService
    {
        public ObjectModelService(ApplicationDbContext ctx, UserManager<ApplicationUser> um) : base(ctx, um)
        {

        }

        public List<ObjectModel> Search(params string[] tags)
        {
            List<ObjectModel> res = new List<ObjectModel>();
            foreach (var u in tags)
            {
                res.AddRange(_context.ObjectModel.Include(e => e.PricingUnitOfMeaure).Include(e => e.ModelLicense).Where(e => e.ObjectTags.Contains(u)));
                if (res.Count > 20) break;
            }
            return res;
        }
    }
}
