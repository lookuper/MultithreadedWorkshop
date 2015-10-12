<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

void Main()
{
	// Do Example
	var source = Observable.Interval(TimeSpan.FromSeconds(1))
		.Take(5)
		.Select(_ => DateTime.Now)
		.Do(value => value.Dump());
		
	source.Subscribe();
}