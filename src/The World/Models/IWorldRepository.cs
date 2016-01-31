using System.Collections.Generic;
using TheWorld.Models;

namespace The_World.Models
{
    public interface IWorldRepository
    {
        IEnumerable<Trip> GetAllTrips();
        IEnumerable<Trip> GetAllTripsWithStops();
    }
}