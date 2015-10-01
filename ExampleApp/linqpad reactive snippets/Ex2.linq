<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

void Main()
{
	// inline subscription
	var source = Observable.Range(0, 10);
	var subscription = source.Subscribe(
		value => value.Dump(),
		error => error.Message.Dump(),
		() => "Complete".Dump()
	);

	subscription.Dispose();
}

// Define other methods and classes here