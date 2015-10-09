<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

void Main()
{
	// Enumberable to Observable
	var list = new List<int>{ 1, 2, 3, 4, 5};
	var source = list.ToObservable();
	
	var subscription = source.Subscribe(
		value => Console.WriteLine ("OnNext: {0}", value),
		error => Console.WriteLine ("OnError: {0}", error.Message),
		() => Console.WriteLine ("OnCompleted"));
}