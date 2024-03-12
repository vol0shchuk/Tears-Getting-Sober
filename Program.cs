public class CoffeeMachine
{
    public delegate void CoffeeMachineStartedEventHandler();
    public event CoffeeMachineStartedEventHandler CoffeeMachineStarted;

    public delegate void CoffeeBrewedEventHandler(string coffeeType);
    public event CoffeeBrewedEventHandler CoffeeBrewed;

    public void StartCoffeeMachine()
    {
        Console.WriteLine("Coffee machine is starting...");
        OnCoffeeMachineStarted();
    }

    protected virtual void OnCoffeeMachineStarted()
    {
        CoffeeMachineStarted?.Invoke();
    }

    public void BrewCoffee(string coffeeType)
    {
        Console.WriteLine($"Brewing {coffeeType} coffee...");
        OnCoffeeBrewed(coffeeType);
    }

    protected virtual void OnCoffeeBrewed(string coffeeType)
    {
        CoffeeBrewed?.Invoke(coffeeType);
    }
}

class Program
{
    static void Main(string[] args)
    {
        CoffeeMachine coffeeMachine = new CoffeeMachine();

        coffeeMachine.CoffeeMachineStarted += () => Console.WriteLine("Coffee machine is now running.");
        coffeeMachine.CoffeeBrewed += (coffeeType) => Console.WriteLine($"{coffeeType} coffee is ready.");

        coffeeMachine.StartCoffeeMachine();

        coffeeMachine.BrewCoffee("Late");
    }
}
