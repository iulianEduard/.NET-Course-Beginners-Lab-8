using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab8.ConsoleApp.Multithreading
{
    public class MultithreadingExample
    {
        private bool isDone;

        public delegate int BinaryOp(int x, int y);

        public void GetCurrentThread()
        {
            Thread thread = Thread.CurrentThread;
            Console.WriteLine($"Name: {thread.Name}, State: {thread.ThreadState}");

            Console.ReadKey();
        }

        public void DelegateOperation()
        {
            Console.WriteLine("***** Synch Delegate Review *****");
            Console.WriteLine("Main() invoked on thread { 0}.", Thread.CurrentThread.ManagedThreadId);

            BinaryOp b = new BinaryOp(Add);
            int answer = b(10, 10);

            Console.WriteLine("Doing more work in Main()!");
            Console.WriteLine("10 + 10 is {0}.", answer);

            Console.ReadLine();
        }

        public void AsyncDelegateOperation()
        {
            Console.WriteLine("***** Async Delegate Invocation *****");
            Console.WriteLine("Main() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            BinaryOp b = new BinaryOp(Add);
            IAsyncResult iftAR = b.BeginInvoke(10, 10, null, null);

            Console.WriteLine("Doing more work in Main()!");
            // Obtain the result of the Add() method when ready.

            int answer = b.EndInvoke(iftAR);

            Console.WriteLine("10 + 10 is {0}.", answer);
            Console.ReadLine();
        }

        public void AsyncCallbackDelegateOperation()
        {
            Console.WriteLine("***** AsyncCallbackDelegate Example * ****");
            Console.WriteLine("Main() invoked on thread { 0}.", Thread.CurrentThread.ManagedThreadId);

            BinaryOp b = new BinaryOp(Add);
            IAsyncResult iftAR = b.BeginInvoke(10, 10, new AsyncCallback(AddComplete), null);
            
            // Assume other work is performed here...
            while (!isDone)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Working....");
            }

            Console.ReadLine();
        }

        private int Add(int x, int y)
        {
            // Print out the ID of the executing thread.
            Console.WriteLine("Add() invoked on thread{ 0}.", Thread.CurrentThread.ManagedThreadId);

            // Pause to simulate a lengthy operation.
            Thread.Sleep(5000);

            return x + y;
        }

        private void AddComplete(IAsyncResult itfAR)
        {
            Console.WriteLine("AddComplete() invoked on thread { 0}.", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your addition is complete");
            isDone = true;
        }
    }
}

