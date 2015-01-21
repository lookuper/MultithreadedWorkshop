<Query Kind="Program" />

void Main()
{
	// ex 5
    var c = new CancellationTokenSource();
    var t = Task.Factory.StartNew(() =>
    {
           Thread.Sleep(TimeSpan.FromSeconds(1));
           if (c.IsCancellationRequested)
                  return;
                 
           Console.WriteLine ("test");
    }, c.Token);
         c.Cancel();
		 
    SynchronizationContext.Current.Dump();
    ExecutionContext.Capture().Dump();
}