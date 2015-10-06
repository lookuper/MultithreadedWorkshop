<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

void Main()
{
	// materialize
	Observable.Range(0,10).Materialize().Dump("");

	// stamp interval examples
	Observable.Interval(TimeSpan.FromSeconds(1))
		.Take(3)
		.Timestamp()
		.Dump();
	Observable.Interval(TimeSpan.FromSeconds(1))
		.Take(3)
		.TimeInterval()
		.Dump();
}