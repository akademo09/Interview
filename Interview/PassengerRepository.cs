using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{

    public class PassengerRepository : IRepository<Passenger, int>
    {
        readonly ICollection<Passenger> _passengerList;

        public PassengerRepository(ICollection<Passenger> passengersList)
        {
            _passengerList = passengersList ?? throw new NullReferenceException("Null passenger list passed");
        }
        public virtual void Delete(int id)
        {
            var passenger = Get(id);

            if (passenger!= null)
                _passengerList.Remove(passenger);
            else
                throw new InvalidOperationException($"Item with id {id} does not exist");
        }

        public virtual Passenger Get(int id)
        { 
            var res = from g in _passengerList where g.Id == id select g;

            if (!res.Any())
                return null;
            else
                return res.First();
        }

        public virtual IEnumerable<Passenger> GetAll()
        {
            return _passengerList;
        }

        public virtual void Save(Passenger item)
        {
            if (item == null)
                throw new ArgumentNullException("Null Passenger reference received");
            if(item.Id < 0)
                throw new ArgumentOutOfRangeException("Invalid ID value passed - ID must be greater than zero.");
            if(item.Name == null)
                throw new ArgumentNullException("Null reference passed for Passenger Name");

            if ((from g in _passengerList where g.Id == item.Id select g).Count() != 0)
                throw new InvalidOperationException("Item Id already exists");

            _passengerList.Add(item);
        }
    }
}
