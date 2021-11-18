using BAPapp.Data;
using BAPapp.Models.Venue;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Services
{
    public class VenueService
    {
        private readonly Guid _userId;
        public VenueService(Guid userId)
        {
            _userId = userId;
        }
                //create
        public bool CreateVenue(VenueCreate model)
        {
            Venue entity = new Venue
            {
             
                VenueName = model.VenueName,
                VenueLocation = model.VenueLocation,
                PointOfContact = model.PointOfContact
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Venues.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //get all
        public IEnumerable<VenueListItem> GetVenues()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                  ctx
                      .Venues
                      .Where(v => v.OwnerId == _userId)
                      .Select(
                          v =>
                              new VenueListItem
                              {
                                  VenueId = v.VenueId,
                                  VenueName = v.VenueName,
                                  VenueLocation = v.VenueLocation,
                                  PointOfContact = v.PointOfContact
                              });
                return query.ToArray();
            }
        }
        //get by name
        public VenueDetail GetVenueByName(string venueName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .Venues
                            .Single(v => v.VenueName == venueName && v.OwnerId == _userId);
                return
                       new VenueDetail
                       {
                           VenueId = entity.VenueId,
                           VenueName = entity.VenueName,
                           VenueLocation = entity.VenueLocation,
                           PointOfContact = entity.PointOfContact,

                       };
            }
        
        }
        public bool UpdateVenue(VenueEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .Venues
                            .Single(v => v.VenueName == model.VenueName && v.OwnerId == _userId);

                entity.VenueId = model.VenueId;
                entity.VenueName = model.VenueName;
                entity.VenueLocation = model.VenueLocation;
                entity.PointOfContact = model.PointOfContact;

                return ctx.SaveChanges() == 1;
            }

        }
        public bool DeleteVenue(string venueName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .Venues
                            .Single(v => v.VenueName == venueName);
                ctx.Venues.Remove(entity);

                return ctx.SaveChanges() == 1;

            }

        }

        //will implement later
        public void AddCrewerToVenue(string crewerId, string venueId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var foundCrewer = ctx.Crewers.Single(c => c.CrewerId == crewerId);
                var foundVenue = ctx.Venues.Single(v => v.VenueId == venueId);
                foundVenue.Crewers.Add(foundCrewer);
                var testing = ctx.SaveChanges();

            }
        }

    }
}
