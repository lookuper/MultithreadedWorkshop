<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
</Query>

void Main()
{
	// subject example
	var observer = Observer.Create<String>(
		value => value.Dump(),
		error => error.Message.Dump(),
		() => "Completed".Dump());
		
	var subject = new Subject<String>();
	subject.OnNext("A");
	subject.Subscribe(observer);
	
	subject.OnNext("B");
	subject.OnError(new NullReferenceException());	
}

// Define other methods and classes here