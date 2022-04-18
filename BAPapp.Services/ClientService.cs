using BAPapp.Data;
using BAPapp.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Services
{
    public class ClientService
    {
        private readonly Guid _userId;
        public ClientService(Guid userId)
        {
            _userId = userId;
        }
        //create
        public bool CreateClient(ClientCreate model)
        {
            Client entity = new Client
            {

                Company = model.Company,
                Contact = model.Contact,


            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Clients.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        //get all
        public IEnumerable<ClientListItem> GetClients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                      ctx
                          .Clients
                          .Where(c => c.OwnerId == _userId)
                          .Select(
                              c =>
                                  new ClientListItem
                                  {

                                      Company = c.Company,
                                      Contact = c.Contact,

                                  });
                return query.ToArray();
            }
        }

        //get by event
        public ClientDetail GetClientById(int clientId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .Clients
                            .Single(c => c.ClientId == clientId && c.OwnerId == _userId);
                return
                       new ClientDetail
                       {

                           Company = entity.Company,
                           Contact = entity.Contact,
                           
                       };
            }
        }
        public bool UpdateClient(ClientEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .Clients
                            .Single(c => c.Company == model.Company && c.OwnerId == _userId);


                entity.Company = model.Company;
                entity.Contact = model.Contact;
           
                return ctx.SaveChanges() == 1;
            }

        }
        public bool DeleteClient(int clientId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .Clients
                            .Single(c => c.ClientId == clientId);
                ctx.Clients.Remove(entity);

                return ctx.SaveChanges() == 1; ;

            }

        }

    }
}
