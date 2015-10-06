<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

void Main()
{
	// on error exceptions
	var values = new Subject<int>();
	try
	{	        
		values.Subscribe(value => value.Dump(), error => error.Message.Dump());
	}
	catch (Exception ex)
	{
		Console.WriteLine (ex.Message.Dump() + "!!!");
	}
	values.OnNext(1);
	values.OnError(new NullReferenceException());
}