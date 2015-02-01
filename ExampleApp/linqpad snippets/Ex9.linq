<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
     // ex9
     var t = Task.Factory.StartNew(() =>
     {
            throw new NotImplementedException();
     });
    
     t.ContinueWith((res) =>
     {
            Console.WriteLine ("OnlyOnRanToCompletion");
     }, TaskContinuationOptions.OnlyOnRanToCompletion);

     t.ContinueWith((res) =>
     {
            res.Exception.InnerExceptions.Dump();
            Console.WriteLine ("OnlyOnFaulted");
     }, TaskContinuationOptions.OnlyOnFaulted);  
}