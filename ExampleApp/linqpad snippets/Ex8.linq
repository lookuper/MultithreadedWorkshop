<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	 // ex8, task continuation
     Thread.CurrentThread.ManagedThreadId.Dump();
     var t = Task.Factory.StartNew(() =>
     {
            Thread.CurrentThread.ManagedThreadId.Dump();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            return 42;
     });
    
     t.ContinueWith(previousResult =>
     {
            int res = previousResult.Result;
            Thread.CurrentThread.ManagedThreadId.Dump();
     });
}