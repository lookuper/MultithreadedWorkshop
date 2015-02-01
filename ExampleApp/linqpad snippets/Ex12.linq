<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
     // ex12
     Task.Delay(TimeSpan.FromSeconds(2))
     .ContinueWith(res =>
     {
            Console.WriteLine ("2 sec pause");
     });
    
     Console.WriteLine ("end");
     TaskScheduler.Default.Dump();
}