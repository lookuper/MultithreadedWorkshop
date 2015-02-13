<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	 //ex4, cancellation before start
     var c = new CancellationTokenSource();
     var t = Task.Factory.StartNew(() =>
     {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            return 5;
     }, c.Token);
    
     c.Cancel(throwOnFirstException:true);	 
     t.Status.Dump();
       /*
       This has two primary benefits:
       If the token has cancellation requested prior to the Task starting to execute, 
	   	the Task won't execute. Rather than transitioning to Running, it'll immediately transition to
		Canceled. This avoids the costs of running the task if it would just be canceled while running anyway.
       If the body of the task is also monitoring the cancellation token and throws an 
	    OperationCanceledException containing that token (which is what ThrowIfCancellationRequested 
		does), then when the task sees that OCE, it checks whether the OCE's token matches the Task's
		token. If it does, that exception is viewed as an acknowledgement of cooperative cancellation 
		and the Task transitions to the Canceled state (rather than the Faulted state).
       */
}