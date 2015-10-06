<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
</Query>

void Main()
{
	// replay subject example
	var observer = Observer.Create<String>(
		value => value.Dump(),
		error => error.Message.Dump(),
		() => "Completed".Dump());
		
	var subject = new ReplaySubject<String>(1);
	subject.OnNext("A");
	subject.OnNext("B");
	subject.Subscribe(observer);
	
	subject.OnNext("C");
	subject.OnCompleted();
}