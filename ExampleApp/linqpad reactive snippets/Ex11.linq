<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
</Query>

void Main()
{
	// hot observalbe 
	var source = Observable.Interval(TimeSpan.FromSeconds(1));
	var hot = Observable.Publish(source);
	var subscription = hot.Subscribe(
		value => Console.WriteLine ("OnNext: {0}", value),
		error => Console.WriteLine ("OnError: {0}", error.Message),
		() => Console.WriteLine ("OnCompleted"));

	hot.Connect();
	Thread.Sleep(6000);
	var subscription2 = hot.Subscribe(
		value => Console.WriteLine ("OnNext2: {0}", value),
		error => Console.WriteLine ("OnError2: {0}", error.Message),
		() => Console.WriteLine ("OnCompleted2"));
		
	Thread.Sleep(2000);
	subscription.Dispose();
}