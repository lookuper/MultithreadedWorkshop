<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

void Main()
{
	// Observable.Interval implementation
	var source  = Observable.Create<string>(observer =>
	{
		var timer = new System.Timers.Timer();
		timer.Interval = 1000;
		timer.Elapsed += (s, e) => observer.OnNext("tick");
		timer.Start();
		
		return () => {
		 timer.Elapsed -= (s, e) => {};
		 timer.Dispose();
		};
	});
	
	var subscription = source.Subscribe(Console.WriteLine);
	Thread.Sleep(3100);
	subscription.Dispose();
}
