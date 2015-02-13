<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
     // ex12, delay before excecution in task thread
     Task.Delay(TimeSpan.FromSeconds(2))
     .ContinueWith(res =>
     {
            Console.WriteLine ("2 sec pause");
     });
    
     Console.WriteLine ("end");
}