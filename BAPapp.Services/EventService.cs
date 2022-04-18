using BAPapp.Data;
using BAPapp.Models.Event;
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
                  
                    EventDate = model.EventDate,
                    EventTitle = model.EventTitle,
                    //VenueId = model.VenueId,
                    //ClientId = model.ClientId,
                    IsPaid = model.IsPaid,
                   
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
                                        
                                        EventDate = e.EventDate,
                                        EventTitle = e.EventTitle,
                                        IsPaid = e.IsPaid,
                                        //VenueId = e.VenueId,
                                        //ClientId = e.ClientId,
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
                        
                        EventDate = entity.EventDate,
                        EventTitle = entity.EventTitle,
                        IsPaid = entity.IsPaid,
                        //VenueId = entity.VenueId,
                        //ClientId = entity.ClientId,
                       
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

                
                entity.EventDate = model.EventDate;
                entity.EventTitle = model.EventTitle;
                entity.IsPaid = model.IsPaid;
                //entity.VenueId = model.VenueId;
                //entity.ClientId = model.ClientId;

                return ctx.SaveChanges() == 1;
            }

        }
        public bool DeleteEvent(int eventId)
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
