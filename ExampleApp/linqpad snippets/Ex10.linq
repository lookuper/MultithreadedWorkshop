<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
       // ex10
     var t = Task.Factory.StartNew(() =>
     {
            Console.WriteLine ("task 1");
            var t2 = Task.Factory.StartNew(() =>
            {
                   Thread.Sleep(TimeSpan.FromSeconds(3));
                   Console.WriteLine ("task 2 end");
            }, TaskCreationOptions.AttachedToParent);
           
            Console.WriteLine ("task 1 end");
     }, TaskCreationOptions.LongRunning);
    
     t.Wait();
     Console.WriteLine ("snippet end");
     var t3 = Task.Factory.StartNew(() =>
     {
            Console.WriteLine ("task 1");
            var t2 = Task.Factory.StartNew(() =>
            {
                   Thread.Sleep(TimeSpan.FromSeconds(3));
                   Console.WriteLine ("task 2 end");
            });
           
            Console.WriteLine ("task 1 end");
     }, TaskCreationOptions.LongRunning);
    
     t3.Wait();
     Console.WriteLine ("snippet end");
}