using System;

namespace Datalagring_CarPark_EFCore.Domain.Model
{
    class Parking
    {
        public Person Person { get; }
        public Vehicle Vehicle { get; }
        public DateTime ArrivedAt { get; }
        public DateTime DepartedAt { get; private set; }
        public Parking(Person person, Vehicle vehicle)
        {
            Person = person;
            Vehicle = vehicle;
            ArrivedAt = DateTime.Now;
        }
        public void Departed()
        {
            DepartedAt = DateTime.Now;
        }
    }
}
