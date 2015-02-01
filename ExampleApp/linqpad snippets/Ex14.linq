<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	// Ex14
     var t = AsynOperation(() =>
     {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Console.WriteLine ("test");
     });
    
     Console.WriteLine ("end");
}

private static Task AsynOperation(Action action)
{
	return Task.Delay(TimeSpan.FromSecond(1));
}