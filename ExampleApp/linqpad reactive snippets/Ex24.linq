<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.Concurrency</Namespace>
</Query>

void Main()
{
	// async/await example 
	var fws = new FileSystemWatcher(@"C:\")
	{
		IncludeSubdirectories = true,
		EnableRaisingEvents = true
	};
	
	var source = from c in Observable.FromEventPattern<FileSystemEventArgs>(fws, "Changed")
				 select c.EventArgs.FullPath;

	source.Window(TimeSpan.FromSeconds(5)).Subscribe(async window =>
	{
		var count = await window.Count();
		Console.WriteLine("{0} events last 5 seconds", count);
	});
}