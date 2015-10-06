<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

void Main()
{
 	//observer subscription
	var source = Observable.Range(0, 10);
	var observer = Observer.Create<int>(
		value => value.Dump(),
		error => error.Message.Dump(),
		() => "Completed".Dump());
		
	var subscription = source.Subscribe(observer);
	Console.WriteLine ("end");
}