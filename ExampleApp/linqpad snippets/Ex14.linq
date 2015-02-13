<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async void Main()
{
	// Ex14, advanced await example
     await AsynOperation(() =>
     {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Console.WriteLine ("test");
     });
    
     Console.WriteLine ("end");
}

private static Task AsynOperation(Action action)
{
	return Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith((res) => action());	
}