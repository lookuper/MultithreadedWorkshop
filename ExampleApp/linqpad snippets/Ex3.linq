<Query Kind="Program" />

void Main()
{
	 //ex3
     var t = Task.Factory.StartNew((state) =>
     {
            return state != null;
     }, new Object());
    
     //t.Start();
     t.Result.Dump();
}