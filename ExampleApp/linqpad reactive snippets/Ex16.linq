<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Timers</Namespace>
</Query>

void Main()
{
	// FromEventPattern for Elapsed event 
	var timer = new System.Timers.Timer();
	timer.Interval = 1000;

	var source = Observable.FromEventPattern<ElapsedEventHandler, ElapsedEventArgs>(
		handler => handler.Invoke,
		h => timer.Elapsed += h,
		h => timer.Elapsed -= h);
	
	timer.Start();
	var subscription = source.Subscribe(value => value.EventArgs.Dump());
	
	Thread.Sleep(2100);
	subscription.Dispose();
}