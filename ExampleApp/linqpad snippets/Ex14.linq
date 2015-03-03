<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async void Main()
{
	// Ex14, advanced await example
	var t = AsynOperation(() =>
	{
		Thread.Sleep(TimeSpan.FromSeconds(3));
		Console.WriteLine ("test");
	});
	
	Console.WriteLine ("end");
}

internal static async Task AsynOperation(Action action)
{
	await Task.Factory.StartNew(action);
	Console.WriteLine ("AsynOperation end");
}
