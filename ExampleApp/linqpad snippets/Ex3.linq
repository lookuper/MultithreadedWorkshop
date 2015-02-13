<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	 //ex3, create using Factory method
     var t = Task.Factory.StartNew((state) =>
     {
            return state != null;
     }, new Object());
    
     //t.Start();
     t.Result.Dump();
}