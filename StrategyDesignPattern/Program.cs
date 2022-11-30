interface IStrategy
{
	string GetTravelTime(string source, string destination);
}

class CarStrategy : IStrategy
{
	public string GetTravelTime(string source, string destination)
		=> "It takes 40 minutes to reach from " + source + " to " + destination + " using Car.";
}

class BikeStrategy : IStrategy
{
	public string GetTravelTime(string source, string destination)
		=> "It takes 25 minutes to reach from " + source + " to " + destination + " using Bike.";
}

class BusStrategy : IStrategy
{
	public string GetTravelTime(string source, string destination)
		=> "It takes 60 minutes to reach from " + source + " to " + destination + " using Bus.";
}

class TravelStrategy
{
	private IStrategy _strategy;
	public TravelStrategy(IStrategy chosenStrategy)
		=> _strategy = chosenStrategy;

	public void GetTravelTime(string source, string destination)
	{
		var result = _strategy.GetTravelTime(source, destination);
		Console.WriteLine(result);
	}
}

class Program
{
	static void Main()
	{
		var userStrategy = Console.ReadLine().ToLower();

		switch (userStrategy)
		{
			case "car":
				new TravelStrategy(new CarStrategy()).GetTravelTime("Point A", "Point B");
				break;
			case "bike":
				new TravelStrategy(new BikeStrategy()).GetTravelTime("Point A", "Point B");
				break;
			case "bus":
				new TravelStrategy(new BusStrategy()).GetTravelTime("Point A", "Point B");
				break;
			default:
				Console.WriteLine("You have chosen an invalid mode of transport.");
				break;
		}
	}
}