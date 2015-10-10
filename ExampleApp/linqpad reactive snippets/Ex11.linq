<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
</Query>

void Main()
{
	// cancel observable
	var source = Observable.Interval(TimeSpan.FromSeconds(1));
	var sourceDisposion = source.Subscribe(value => value.Dump());

	CancellationTokenSource ts = new CancellationTokenSource();
	ts.Token.Register(sourceDisposion.Dispose);
	
	Thread.Sleep(4000);
	ts.Cancel();
}