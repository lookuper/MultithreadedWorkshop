<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.Concurrency</Namespace>
</Query>

void Main()
{
	// SubscribeOn example
	String.Format("Current thread id: {0}", Thread.CurrentThread.ManagedThreadId).Dump();
	var source = Observable.Interval(TimeSpan.FromSeconds(1))
		.Take(10);
	
	source.SubscribeOn(Scheduler.ThreadPool)
		.Subscribe(value => Console.WriteLine ("Thread Id: " + Thread.CurrentThread.ManagedThreadId));		
}