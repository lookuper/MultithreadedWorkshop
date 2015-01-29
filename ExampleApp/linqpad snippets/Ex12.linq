<Query Kind="Program" />

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