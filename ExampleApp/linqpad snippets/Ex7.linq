<Query Kind="Program" />

void Main()
{
     // ex 7
     var t = Task.Factory.StartNew(() =>
     {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            throw new ArgumentNullException();
     });
    
     try
     {
            t.Wait();
     }
     catch(ArgumentNullException)
     {
            Console.WriteLine ("catch");
     }
     catch(AggregateException ae)
     {
            Console.WriteLine ("AggregateException catched");
            //ae.InnerException.Dump();
            //ae.InnerExceptions.Dump();
           
            ae.Handle((ex) =>
            {
                   if (ex is ArgumentNullException)
                   {
                         Console.WriteLine ("ArgumentNullException catched");
                         return true;
                   }
                  
                   return false;
            });   
     }