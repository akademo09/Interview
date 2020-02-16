using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{

    public class PassengerRepository : IRepository<Passenger, int>
    {
        List<Passenger> _passengerList;

        public PassengerRepository()
        {
            _passengerList = new List<Passenger>();
        }
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
            return _passengerList;
        }

        public void Save(Passenger item)
        {
            _passengerList.Add(item);
        }
    }
}
