<Query Kind="Program" />

void Main()
{
	 // ex 6
     var c = new CancellationTokenSource();
     var token = c.Token;
     var t = Task.Factory.StartNew(() =>
     {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            token.ThrowIfCancellationRequested();          
            Console.WriteLine ("test");
     }, token);
    
     c.Cancel();
     t.Wait();
}