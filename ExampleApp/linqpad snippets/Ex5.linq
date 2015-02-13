<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	// ex 5, gracefully cancellation
    var c = new CancellationTokenSource();
    var t = Task.Factory.StartNew(() =>
    {
           Thread.Sleep(TimeSpan.FromSeconds(1));
           if (c.IsCancellationRequested)
                  return;
                 
           Console.WriteLine ("test");
    }, c.Token);
	
   	c.Cancel();
}