using _3DPrintingBlockchainMarket.Data;
using _3DPrintingBlockchainMarket.Models;
using Microsoft.AspNetCore.Identity;
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

    }
    public class ObjectModelService : BasicServiceImplementation<ObjectModel> ,IObjectModelService
    {
        public ObjectModelService(ApplicationDbContext ctx, UserManager<ApplicationUser> um) : base(ctx, um)
        {

        }
    }
}
