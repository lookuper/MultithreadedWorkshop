<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

void Main()
{
	// observable start example
	var start = Observable.Start(() =>
	{
		Thread.Sleep(2000);
		Console.WriteLine ("Inner Thread Id: {0}", Thread.CurrentThread.ManagedThreadId);
		return "test";
	});
	
	start.Subscribe(Console.WriteLine, () => Console.WriteLine ("end"));
	Console.WriteLine ("Main Thread Id: {0}", Thread.CurrentThread.ManagedThreadId);
}

// Define other methods and classes here