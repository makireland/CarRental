namespace DublinCarRental.Entities
{
    public class Vehicle
    {
        public string CarModel { get; private set; }
       
        public Vehicle(string carModel)
        {
            CarModel = carModel;
        }

    }
}
