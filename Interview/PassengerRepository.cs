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
            var passenger = from g in _passengerList where g.Id == id select g;
            _passengerList.Remove(passenger.First());
        }

        public Passenger Get(int id)
        {
            return (from g in _passengerList where g.Id == id select g).First();
        }

        public IEnumerable<Passenger> GetAll()
        {
            return _passengerList;
        }

        public void Save(Passenger item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if ((from g in _passengerList where g.Id == item.Id select g).Count() != 0)
                throw new InvalidOperationException("Item Id already exists");

            _passengerList.Add(item);
        }
    }
}
