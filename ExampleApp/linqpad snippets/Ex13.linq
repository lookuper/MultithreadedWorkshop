<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async void Main()
{
     // ex 13, async/await flow
     Console.WriteLine ("start");
     await Task.Delay(TimeSpan.FromSeconds(3));
     Console.WriteLine ("end");
}