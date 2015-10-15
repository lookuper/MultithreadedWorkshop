<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Concurrency</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	// from async 
	var source = Observable.FromAsync(cancel => LongRunningOperation(cancel))
		.Timeout(TimeSpan.FromMilliseconds(1100));
		
	source.Subscribe(Console.WriteLine);
	
}

public Task<int> LongRunningOperation(CancellationToken token)
{
	return Task.Run(() =>
	{
		for (int i = 0; i < 10; i++)
		{
			Thread.Sleep(100);
            if (token.IsCancellationRequested)
			{
				"Task cancelled".Dump();
				token.ThrowIfCancellationRequested();
			}
		}
	
		return 42;
	});
}