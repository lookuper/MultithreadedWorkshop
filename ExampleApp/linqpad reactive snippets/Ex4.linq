<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

void Main()
{
	// many subscriptions for one notifier
	var source = Observable.Interval(TimeSpan.FromSeconds(1));
	
	var subscription = source.Subscribe(value => value.Dump());
	var subscription2 = source.Subscribe(value => value.Dump());
	
	Thread.Sleep(5000);
	subscription.Dispose();
	Thread.Sleep(2000);
	subscription2.Dispose();
}