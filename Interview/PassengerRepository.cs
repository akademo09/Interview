using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{

    public class PassengerRepository : IRepository<Passenger, int>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Passenger Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Passenger> GetAll()
        {
            return Enumerable.Empty<Passenger>();
        }

        public void Save(Passenger item)
        {
            throw new NotImplementedException();
        }
    }
}
