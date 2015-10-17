<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive</Namespace>
</Query>

void Main()
{
	// create observer
	var o = Observer.Create<int>(
		value => value.Dump(),
		error => error.Message.Dump(), 
		() => "Completed".Dump());
		
	o.OnNext(5);
	o.OnNext(6);
	//o.OnError(new NotImplementedException());
	o.OnNext(7);
	o.OnCompleted();
}