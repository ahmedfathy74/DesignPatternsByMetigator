using StrategyDesignPattern.After;

while (true)
{
    string origin = "Montreal";
    string destination = "New York";
    Console.WriteLine($"{origin} → {destination}");
    Console.Write("Route preference [1] walking, [2] cycling, [3] driving, [4] transit, [5] flights): ");
    if (Enum.TryParse(Console.ReadLine(), out RoutePreference routePreference) &&
        Enum.IsDefined(typeof(RoutePreference), routePreference))
    {
        NavigationContext navigationContext = new NavigationContext(new DrivingNavigationStrategy());
        switch (routePreference)
        {
            case RoutePreference.Walking:
                FindFastestRoute();
                navigationContext.SwitchNavigationStrategy(new WalkingNavigationStrategy());
                break;
            case RoutePreference.Cycling:
                FindFastestRoute();
                navigationContext.SwitchNavigationStrategy(new CyclingNavigationStrategy());
                break;
            case RoutePreference.Driving:
                FindFastestRoute();
                navigationContext.SwitchNavigationStrategy(new DrivingNavigationStrategy());
                break;
            case RoutePreference.Transit:
                FindFastestRoute();
                navigationContext.SwitchNavigationStrategy(new TransitNavigationStrategy());
                break;
            case RoutePreference.Flight:
                FindFastestRoute();
                navigationContext.SwitchNavigationStrategy(new FlightNavigationStrategy());
                break;
            default:
                break;
        }
        var route = navigationContext.Navigate(origin, destination);

        Console.WriteLine(route);
    }
    else
    {
        Console.WriteLine("INVALID CHOICE!!! Press any key to continue");
    }

    Console.ReadKey();
    Console.Clear();
}



static void FindFastestRoute()
{
    Console.Clear();
    Console.Write($"Finding fastest route considering distance, weather, and safety");
    Thread.Sleep(750);
    for (int i = 0; i < 10; i++)
    {
        Thread.Sleep(350);
        Console.Write(".");
    }
    Console.Clear();
}
