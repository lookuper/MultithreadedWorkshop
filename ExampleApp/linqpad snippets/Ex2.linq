<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	 // ex2, crate using contrstructor with return value
     var t = new Task<int>(() =>
     {
            return 5;
     });
    
     t.Start();
     t.Result.Dump();
}

// Define other methods and classes here