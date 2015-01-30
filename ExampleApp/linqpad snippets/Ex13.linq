<Query Kind="Program" />

void Main()
{
     // ex 13 with async/await
     Console.WriteLine ("start");
     Task.Delay(TimeSpan.FromSeconds(3));
     Console.WriteLine ("end");
}