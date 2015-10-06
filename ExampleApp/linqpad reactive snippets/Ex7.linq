<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

void Main()
{
	// interval example
	var timerSpawn = Observable
		.Interval(TimeSpan.FromSeconds(1))
		.Take(5);
	
	var consoleObserver = Observer.Create<long>(
		value => { Console.WriteLine ("OnNext: {0}, Thread: {1}", value, Thread.CurrentThread.ManagedThreadId);},
		error => Console.WriteLine ("OnError: {0}", error.Message),
		() => Console.WriteLine ("OnCompleted"));
		
	var subscription = timerSpawn.Subscribe(consoleObserver);
}