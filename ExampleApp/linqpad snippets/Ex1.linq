<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.Parallel.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	// ex 1, create using Task costructor
		var t = new Task(() =>
		{
			Console.WriteLine ("responce");
		});
		
		t.Status.Dump();
		
//		t.Start();
//		t.Status.Dump();
//		t.Wait();
//		
//		t.Status.Dump();
}