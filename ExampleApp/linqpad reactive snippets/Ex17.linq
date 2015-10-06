<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

void Main()
{
	// DistinctUntilChanged example (will surface values only if they are different from the previous value)
	var subject = new Subject<int>();
	var distinct = subject.DistinctUntilChanged();
	subject.Subscribe(Console.WriteLine);
	distinct.Subscribe(value => Console.WriteLine ("distinct: {0}" + Environment.NewLine, value));
	subject.OnNext(1);
	subject.OnNext(2);
	subject.OnNext(1);
	subject.OnNext(1);
	subject.OnNext(1);
	subject.OnNext(2);
}