namespace Datalagring_CarPark_EFCore.Domain.Model
{
    class Vehicle
    {
        public string RegistrationNumber { get; }
        public string Notes { get; }
        public Vehicle(string registrationNumber, string notes)
        {
            RegistrationNumber = registrationNumber;
            Notes = notes;
        }
    }
}