using _3DPrintingBlockchainMarket.Data;
using _3DPrintingBlockchainMarket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace _3DPrintingBlockchainMarket.Services
{
    public class DataRow
    {
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateInactivted { get; set; }
        public DateTime? DateDeleted { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastModified { get; set; }
    }
    public class UserEditableDataRow : DataRow
    {
        public ApplicationUser CreatedBy { get; set; }
        public string CreatedById { get; set; }
        public ApplicationUser LastModifiedBy { get; set; }
        public string LastModifiedById { get; set; }
    }

    public interface IBasicService<T> // Use Global claims principal for the System?
    {
        T Add<T>(T add, ClaimsPrincipal User, bool save_on_complete = true) where T : UserEditableDataRow;
        T Add<T>(T add, bool save_on_complete = true) where T : DataRow;

        T Update<T>(T add, ClaimsPrincipal User, bool save_on_complete = true) where T : UserEditableDataRow;
        T Update<T>(T add, bool save_on_complete = true) where T : DataRow;

        T FlagForDelete<T>(T add, ClaimsPrincipal User, bool save_on_complete = true) where T : UserEditableDataRow;
        T FlagForDelete<T>(T add, bool save_on_complete = true) where T : DataRow;

        T ToggleActiveState<T>(T add, ClaimsPrincipal User, bool save_on_complete = true) where T : UserEditableDataRow;
        T ToggleActiveState<T>(T add, bool save_on_complete = true) where T : DataRow;

        int SaveChanges();
        void UndoDatabaseChanges();
        void UndoObjectChanges(object entity);

    }

    public class BasicServiceImplementation<T> : IBasicService<T>
    {
        protected UserManager<ApplicationUser> _UserManager;
        protected ApplicationDbContext _context;
        public BasicServiceImplementation(ApplicationDbContext ctx, UserManager<ApplicationUser> um)
        {
            _context = ctx;
            _UserManager = um;
        }

        public T Add<T>(T add, ClaimsPrincipal User, bool save_on_complete = true) where T : UserEditableDataRow
        {
            string userId = _UserManager.GetUserId(User);
            if (String.IsNullOrEmpty(userId)) throw new ApplicationException("Null user cannot save new entities.");
            add.CreatedById = userId;
            add.LastModifiedById = userId;
            DateTime date = DateTime.UtcNow;
            add.DateCreated = date;
            add.DateLastModified = date;
            var ent = _context.Add(add);
            if (save_on_complete) SaveChanges();
            return ent.Entity;
        }

        public T Add<T>(T add, bool save_on_complete = true) where T : DataRow
        {
            DateTime date = DateTime.UtcNow;
            add.DateCreated = date;
            add.DateLastModified = date;
            var ent = _context.Add(add);
            if (save_on_complete) SaveChanges();
            return ent.Entity;
        }

        public T FlagForDelete<T>(T delete, ClaimsPrincipal User, bool save_on_complete = true) where T : UserEditableDataRow
        {
            string userId = _UserManager.GetUserId(User);
            if (String.IsNullOrEmpty(userId)) throw new ApplicationException("Null user cannot save new entities.");
            delete.LastModifiedById = userId;
            DateTime date = DateTime.UtcNow;
            delete.DateLastModified = date;
            delete.IsDeleted = true;
            delete.DateDeleted = date;
            var ent = _context.Update(delete);
            if (save_on_complete) SaveChanges();
            return ent.Entity;
        }

        public T FlagForDelete<T>(T delete, bool save_on_complete = true) where T : DataRow
        {
            DateTime date = DateTime.UtcNow;
            delete.DateLastModified = date;
            delete.IsDeleted = true;
            delete.DateDeleted = date;
            var ent = _context.Update(delete);
            if (save_on_complete) SaveChanges();
            return ent.Entity;
        }

        /// <summary>
        /// Will onyl save the rows of the specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public int SaveChanges()
        {
            var original = _context.ChangeTracker.Entries()
                .Where(x => !typeof(T).IsAssignableFrom(x.Entity.GetType()) && x.State != EntityState.Unchanged)
                .GroupBy(x => x.State)
                .ToList();

            foreach (var entry in _context.ChangeTracker.Entries().Where(x => !typeof(T).IsAssignableFrom(x.Entity.GetType())))
            {
                entry.State = EntityState.Unchanged;
            }

            var rows = _context.SaveChanges();

            foreach (var state in original)
            {
                foreach (var entry in state)
                {
                    entry.State = state.Key;
                }
            }

            return rows;
        }

        /// <summary>
        /// Will toggle the active state of a record
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="active"></param>
        /// <param name="User"></param>
        /// <param name="save_on_complete"></param>
        /// <returns></returns>
        public T ToggleActiveState<T>(T active, ClaimsPrincipal User, bool save_on_complete = true) where T : UserEditableDataRow
        {
            string userId = _UserManager.GetUserId(User);
            if (String.IsNullOrEmpty(userId)) throw new ApplicationException("Null user cannot save new entities.");
            active.LastModifiedById = userId;
            DateTime? date = DateTime.UtcNow;
            active.DateLastModified = date.Value;

            active.IsActive = !active.IsActive;
            active.DateInactivted = (active.IsActive) ? null : date;
            var ent = _context.Update(active);
            if (save_on_complete) SaveChanges();
            return ent.Entity;
        }
        /// <summary>
        /// Will toggle the active state of a record
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="active"></param>
        /// <param name="save_on_complete"></param>
        /// <returns></returns>
        public T ToggleActiveState<T>(T active, bool save_on_complete = true) where T : DataRow
        {
            DateTime? date = DateTime.UtcNow;
            active.DateLastModified = date.Value;

            active.IsActive = !active.IsActive;
            active.DateInactivted = (active.IsActive) ? null : date;
            var ent = _context.Update(active);
            if (save_on_complete) SaveChanges();
            return ent.Entity;
        }
        /// <summary>
        /// Undo all database changes
        /// </summary>
        public void UndoDatabaseChanges()
        {
            //Not sure if this works as intended...
            foreach (var entity in _context.ChangeTracker.Entries().Where(f => f.GetType() == typeof(T)))
            {
                switch(entity.State)
                {
                    case Microsoft.EntityFrameworkCore.EntityState.Added:
                        {
                            entity.State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                            return;
                        }
                    case Microsoft.EntityFrameworkCore.EntityState.Deleted:
                        {
                            entity.State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                            return;
                        }
                    case Microsoft.EntityFrameworkCore.EntityState.Modified:
                        {
                            entity.State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                            return;
                        }
                    default: return;
                }
            }
        }

        public void UndoObjectChanges(object entity)
        {
            var obj = _context.Entry(entity);
            if (typeof(T) != obj.GetType()) throw new InvalidOperationException($"Cannot undo changes of foreign type {obj.GetType().ToString()}"); // Dont change objects of a diffent type
            switch (obj.State)
            {
                case Microsoft.EntityFrameworkCore.EntityState.Added:
                    {
                        obj.State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                        return;
                    }
                case Microsoft.EntityFrameworkCore.EntityState.Deleted:
                    {
                        obj.State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                        return;
                    }
                case Microsoft.EntityFrameworkCore.EntityState.Modified:
                    {
                        obj.State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                        return;
                    }
                default: return;
            }
        }
        /// <summary>
        /// Update the Record. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="update"></param>
        /// <param name="User"></param>
        /// <param name="save_on_complete"></param>
        /// <returns></returns>
        public T Update<T>(T update, ClaimsPrincipal User, bool save_on_complete = true) where T : UserEditableDataRow
        {
            string userId = _UserManager.GetUserId(User);
            if (String.IsNullOrEmpty(userId)) throw new ApplicationException("Null user cannot save new entities.");
            update.LastModifiedById = userId;
            DateTime date = DateTime.UtcNow;
            update.DateLastModified = date;
            var ent = _context.Update(update);
            if (save_on_complete) SaveChanges();
            return ent.Entity;
        }

        public T Update<T>(T update, bool save_on_complete = true) where T : DataRow
        {
            DateTime date = DateTime.UtcNow;
            update.DateLastModified = date;
            var ent = _context.Update(update);
            if (save_on_complete) SaveChanges();
            return ent.Entity;
        }

    }
}
