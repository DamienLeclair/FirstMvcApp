namespace WebServices.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class ReservationRepository
    {
        static ReservationRepository repo;

        public static ReservationRepository Current { get { return repo ?? (repo = new ReservationRepository()); } }

        readonly List<Reservation> data;

        ReservationRepository()
        {
            data = new List<Reservation>
            {
                new Reservation { Id = 1, ClientName = "Adam", Location = "Board Room" },
                new Reservation { Id = 2, ClientName = "Jacqui", Location = "Lecture Hall" },
                new Reservation { Id = 3, ClientName = "Russel", Location = "Meeting Room 1" }
            };
        }

        public IEnumerable<Reservation> GetAll()
        {
            return data;
        }

        public Reservation Get(int id)
        {
            return data.SingleOrDefault(d => d.Id == id);
        }

        public Reservation Add(Reservation item)
        {
            item.Id = data.Count + 1;
            data.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            var item = Get(id);
            if (item != null)
            {
                data.Remove(item);
            }
        }

        public bool Update(Reservation item)
        {
            var storedItem = Get(item.Id);
            if (storedItem != null)
            {
                storedItem.ClientName = item.ClientName;
                storedItem.Location = item.Location;
                return true;
            }

            return false;
        }
    }
}