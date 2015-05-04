using System.Web.Http;

namespace WebServices.Controllers
{
    using System.Collections.Generic;
    using WebServices.Models;

    public class WebController : ApiController
    {
        readonly ReservationRepository repo = ReservationRepository.Current;

        public IEnumerable<Reservation> GetAllReservations()
        {
            return repo.GetAll();
        }

        public Reservation GetReservation(int id)
        {
            return repo.Get(id);
        }

        //public Reservation PostReservation(Reservation item)
        [HttpPost]
        public Reservation CreateReservation(Reservation item)
        {
            return repo.Add(item);
        }

        //public bool PutReservation(Reservation item)
        [HttpPut]
        public bool UpdateReservation(Reservation item)
        {
            return repo.Update(item);
        }

        public void DeleteReservation(int id)
        {
            repo.Remove(id);
        }
    }
}
