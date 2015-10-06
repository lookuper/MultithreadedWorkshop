<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
</Query>

void Main()
{
	// custom observable create
	var source = Observable.Create<int>(obs => 
	{
		obs.OnNext(1);
		obs.OnNext(2);
		obs.OnCompleted();
		Thread.Sleep(2000);
		return Disposable.Create(() => Console.WriteLine ("End"));
	});
	
	var subscription = source.Subscribe(Console.WriteLine);
	Console.WriteLine ("Midle");
	subscription.Dispose();
}