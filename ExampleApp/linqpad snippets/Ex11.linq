<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
     // ex11, Factory static methods ContinueWhen...
     var t1 = Task.Factory.StartNew(() =>
     {
            return "task 1";
     });
    
     var t2 = Task.Factory.StartNew(() =>
     {
            return "task 2";
     });
    
     Task.Factory.ContinueWhenAny(new []{t1,t2}, (res) =>
     {
            Console.WriteLine (res.Result);
     });
           
     Task.Factory.ContinueWhenAll(new []{t1,t2}, (res) =>
     {
            Console.WriteLine ();
            res.ToList().ForEach(x => Console.WriteLine (x.Result));
     });
}