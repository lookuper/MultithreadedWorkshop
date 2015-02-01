<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
     // ex 13 with async/await
     Console.WriteLine ("start");
     Task.Delay(TimeSpan.FromSeconds(3));
     Console.WriteLine ("end");
}