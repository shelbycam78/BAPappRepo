using BAPapp.Data;
using BAPapp.Models;
using BAPapp.Models.Crewer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Services
{
    public class CrewerService
    {
        private readonly Guid _userId;
        public CrewerService(Guid userId)
        {
            _userId = userId;
        }
        //create
        public bool CreateCrewer(CrewerCreate model)
        {
            Crewer entity = new Crewer
            {
                CrewerId = model.CrewerId,
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Crewers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
            
        }
        //get all
        public IEnumerable<CrewerListItem> GetCrewers()
        {
            using(var ctx = new ApplicationDbContext())
            { var query =
                    ctx
                        .Crewers
                        .Where(c => c.OwnerId == _userId)
                        .Select(
                            c =>
                                new CrewerListItem
                                {

                                    CrewerId = c.CrewerId,
                                    Name = c.Name,
                                    Email = c.Email,
                                    Phone = c.Phone,

                                });
                return query.ToArray();
            }
        }

        //get by event
        public CrewerDetail GetCrewerByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .Crewers
                            .Single(c => c.Name == name && c.OwnerId == _userId);
                return
                       new CrewerDetail
                         {
                             CrewerId = entity.CrewerId,
                             Name = entity.Name,
                             Email = entity.Email,
                             Phone = entity.Phone,

                         };
            }
        }
        public bool UpdateCrewer(CrewerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .Crewers
                            .Single(c => c.Name == model.Name && c.OwnerId == _userId);

                entity.CrewerId = model.CrewerId;
                entity.Name = model.Name;
                entity.Email = model.Email;
                entity.Phone = model.Phone;

                return ctx.SaveChanges() == 1;
            }

        }
        public bool DeleteCrewer(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .Crewers
                            .Single(c => c.Name == name);
                ctx.Crewers.Remove(entity);

                return ctx.SaveChanges() == 1;

            }

        }


    }
}
