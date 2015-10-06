<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

void Main()
{
	// select example
	var source = Observable.Range(1, 255);
	source.Select(i => new {Number = i, Character = (char)(i + 64)}).Dump();

	// blocking operation 
	var interval = Observable.Interval(TimeSpan.FromSeconds(3));
	interval.First().Dump();

	// Count example
	var numbers = Observable.Range(0, 5);
	numbers.Dump("numbers");
	numbers.Count().Dump("count");	
}