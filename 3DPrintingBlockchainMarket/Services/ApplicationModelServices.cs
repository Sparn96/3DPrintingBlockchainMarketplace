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
