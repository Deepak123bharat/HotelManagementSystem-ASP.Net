using HMS.Data;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Services
{
    public class AccomodationTypesService
    {
        public IEnumerable<AccomodationType> GetAllAccomodationTypes()
        {
            using (var context = new HMSContext())
            {
                return context.AccomodationTypes.ToList();
            }
        }
        public IEnumerable<AccomodationType> SearchAccomodationTypes(string searchTerm)
        {
            using (var context = new HMSContext())
            {
                var accomodationTyeps = context.AccomodationTypes.AsQueryable();
                if(!string.IsNullOrEmpty(searchTerm))
                {
                    accomodationTyeps = accomodationTyeps.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));
                }
                return accomodationTyeps.ToList();
            }
        }

        public AccomodationType GetAccomodationTypeByID(int ID)
        {
            using (var context = new HMSContext())
            {
                return context.AccomodationTypes.Find(ID);
            }
        }

        public bool SaveAccomodationType(AccomodationType accomodationType)
        {
            using (var context = new HMSContext())
            {
                context.AccomodationTypes.Add(accomodationType);
                return context.SaveChanges() > 0;
            }
        }

        public bool UpdateAccomodationType(AccomodationType accomodationType)
        {
            using (var context = new HMSContext())
            {
                context.Entry<AccomodationType>(accomodationType).State = System.Data.Entity.EntityState.Modified;
                return context.SaveChanges() > 0;
            }
        }

        public bool DeleteAccomodationType(AccomodationType accomodationType)
        {
            using (var context = new HMSContext())
            {
                context.Entry<AccomodationType>(accomodationType).State = System.Data.Entity.EntityState.Deleted;
                return context.SaveChanges() > 0;
            }
        }
    }
}
