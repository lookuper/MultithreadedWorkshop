<Query Kind="Program">
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.Concurrency</Namespace>
</Query>

void Main()
{
	// For each mouse left down event, get each mouse move event and return it until
	// the next mouse left up event occurs
	
	IObservable<Event<MouseEventArgs>> draggingEvent =
		 from mouseLeftDownEvent in control.GetMouseLeftDown()
		 from mouseMoveEvent in control.GetMouseMove().Until(control.GetMouseLeftUp())
		 select mouseMoveEvent;
}