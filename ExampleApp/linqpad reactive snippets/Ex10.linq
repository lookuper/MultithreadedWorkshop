<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
</Query>

void Main()
{
	// behaviour subject example	
	var observer = Observer.Create<String>(
		value => value.Dump(),
		error => error.Message.Dump(),
		() => "Completed".Dump());
		
	var subject = new BehaviorSubject<String>("TEST");
	subject.OnNext("A");	
	subject.Subscribe(observer);
}