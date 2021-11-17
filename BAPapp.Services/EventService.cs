using BAPapp.Data;
using BAPapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;

namespace BAPapp.Services
{
    public class EventService
    {
        private readonly Guid _userId;

        public EventService(Guid userId)
        { 
               _userId = userId;
        }

        public bool CreateEvent(EventCreate model)
        {
            var entity =
                new Event()
                {
                    OwnerId = _userId,
                    EventId = model.EventId,
                    EventDate = model.EventDate,
                    EventTitle = model.EventTitle,
                    VenueId = model.VenueId,
                    CrewerId = model.CrewerId,
                    Position = model.Position,
                    Director = model.Director,
                    Producer = model.Producer,
                    IsPaid = model.IsPaid,
                    IsTaxed = model.IsTaxed,
                    IsDirectDeposit = model.IsDirectDeposit,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Events.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<EventListItem> GetEvents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                        ctx
                            .Events
                            .Where(e=> e.OwnerId == _userId)
                            .Select(
                                e =>
                                    new EventListItem
                                    {
                                        EventId = e.EventId,
                                        EventDate = e.EventDate,
                                        EventTitle = e.EventTitle,
                                    });
                return query.ToArray();
            }
        }
        public EventDetail GetEventByDate(DateTime eventDate)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .Events
                            .Single(e => e.EventDate == eventDate && e.OwnerId== _userId);
                return
                    new EventDetail
                    {
                        EventId = entity.EventId,
                        EventDate = entity.EventDate,
                        EventTitle = entity.EventTitle,
                        VenueId = entity.VenueId,
                        CrewerId = entity.CrewerId,
                        Position = entity.Position,
                        Director = entity.Director,
                        Producer = entity.Producer,
                        IsPaid = entity.IsPaid,
                        IsTaxed = entity.IsTaxed,
                        IsDirectDeposit = entity.IsDirectDeposit,
                    };        
            }
        
        }
        public bool UpdateEvent(EventEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .Events
                            .Single(e => e.EventDate == model.EventDate && e.OwnerId==_userId);

                entity.EventId = model.EventId;
                entity.EventDate = model.EventDate;
                entity.EventTitle = model.EventTitle;
                entity.VenueId = model.VenueId;
                entity.CrewerId = model.CrewerId;
                entity.Position = model.Position;
                entity.Director = model.Director;
                entity.Producer = model.Producer;
                entity.IsPaid = model.IsPaid;
                entity.IsTaxed = model.IsTaxed;
                entity.IsDirectDeposit = model.IsDirectDeposit;

                return ctx.SaveChanges() == 1;
            }

        }
        public bool DeleteEvent(string eventId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .Events
                            .Single(e => e.EventId==eventId);
                ctx.Events.Remove(entity);

                return ctx.SaveChanges() == 1;
            
            }
        
        }

    }
}
