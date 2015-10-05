<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

void Main()
{
	// hot observable example
	var source = Observable.Interval(TimeSpan.FromSeconds(1))
		.Take(5)
		.Publish();

	source.Connect();
	source.Subscribe(v => Console.WriteLine ("1s: " + v));	
	Thread.Sleep(TimeSpan.FromSeconds(2));
	source.Subscribe(v => Console.WriteLine ("2s: " + v));	
	// or here	
	source.Connect();
	
	// cold observable example
//	var source = Observable.Interval(TimeSpan.FromSeconds(1))
//		.Take(5);
//
//	source.Subscribe(v => Console.WriteLine ("1s: " + v));	
//	Thread.Sleep(TimeSpan.FromSeconds(2));
//	source.Subscribe(v => Console.WriteLine ("2s: " + v));	
}

// Define other methods and classes here