<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	 // ex 6, cancellation with OperationCancelledException
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