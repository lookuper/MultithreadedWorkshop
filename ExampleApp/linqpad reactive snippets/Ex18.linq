<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

void Main()
{
	// skip/take
	Observable
		.Range(0, 10)
		.Skip(5)
		.Take(2)
		.Subscribe(Console.WriteLine);

//	// skip/take last
//	Observable.Range(0, 10)
//		.SkipLast(2)
//		.TakeLast(3)
//		.Subscribe(Console.WriteLine);
//		
//	// skip until example
//	var subject = new Subject<int>();
//	var otherSubject = new Subject<Unit>();
//	subject
//		.SkipUntil(otherSubject)
//		.Subscribe(Console.WriteLine);
//	
//	subject.OnNext(1);
//	subject.OnNext(2);
//	otherSubject.OnNext(Unit.Default);
//	subject.OnNext(3);
}