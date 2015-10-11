<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System</Namespace>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Concurrency</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
  <Namespace>System.Reactive.Joins</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.PlatformServices</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
  <Namespace>System.Reactive.Threading.Tasks</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	// task to observable conversion
	var task = Task.Factory.StartNew(() =>
	{
		Thread.Sleep(1900);
		return 42;
	});

	var source = task.ToObservable()
		.Timeout(TimeSpan.FromSeconds(2))
		.FirstAsync();
		
	source.Subscribe(Console.WriteLine);
	
	"End".Dump();
}