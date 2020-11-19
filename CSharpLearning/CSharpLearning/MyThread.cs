using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpLearning
{
    public class MyThread : IDemonstrate
    {
        public void Demonstrate()
        {
            MyCancellationToken();
        }

        //284
        public void MySleep()
        {
            System.Console.WriteLine("This is first line.");
            Thread.Sleep(3000);
            System.Console.WriteLine("This is second line.");
            Thread.Sleep(5000);
            System.Console.WriteLine("This is third line.");
        }
        //285
        public void CreateThread()
        {
            Thread th = new Thread(() =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Executing on {Thread.CurrentThread.Name}:");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(i + 1 + " ");
                    Thread.Sleep(800);
                }
                Console.WriteLine("\n");
                Console.ResetColor();
            });
            th.Name = "new thread";
            th.Start();
        }
        //286
        public void PassParametersToNewThread()
        {
            string file_name = $"D:/ttest.txt";
            Thread newThread = new Thread(p =>
            {
                string fileName = p as string;
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        writer.WriteLine("123");
                        writer.WriteLine("456");
                        writer.WriteLine("789");
                        writer.WriteLine("0123");
                    }
                }
            });
            newThread.Start(file_name);
            newThread.Join();
        }
        //287
        public void WaitThreadByManaualResetEvent()
        {
            ManualResetEvent mnlEvt = new ManualResetEvent(false);
            Thread newThread = new Thread(() =>
            {
                int n = 1;
                int result = 0;
                while (n <= 100)
                {
                    Thread.Sleep(20);
                    result += n;
                    n++;
                }
                Console.WriteLine("result:" + result);
                // Sets the state of the event to signaled, allowing one or more waiting threads
                // to proceed.
                mnlEvt.Set();
                // Sets the state of the event to nonsignaled, causing threads to block.
                mnlEvt.Reset();
            });
            newThread.Start();
            Console.WriteLine("calculating...");
            //call main thread to wait here before it continues to execute next line.
            mnlEvt.WaitOne();
            // "Done" will be printed at the end.
            Console.WriteLine("Done");
            // So, the final result will be like this:
            // ---------------------------------------
            // calculating...
            // result:5050
            // Done
            // ---------------------------------------
        }
        //288
        public void WaitingThreadAutoResetEvent()
        {
            AutoResetEvent evt1 = new AutoResetEvent(false);
            AutoResetEvent evt2 = new AutoResetEvent(false);
            AutoResetEvent evt3 = new AutoResetEvent(false);
            Thread th1 = new Thread(() =>
            {
                Console.WriteLine("Phase one...");
                Thread.Sleep(2000);
                Console.WriteLine("Phase one done");
                evt1.Set();
            });
            Thread th2 = new Thread(() =>
            {
                evt1.WaitOne();
                Console.WriteLine("Phase two...");
                Thread.Sleep(2000);
                Console.WriteLine("Phase two done");
                evt2.Set();
            });
            Thread th3 = new Thread(() =>
            {
                evt2.WaitOne();
                Console.WriteLine("Phase three...");
                Thread.Sleep(2000);
                Console.WriteLine("Phase three done");
                evt3.Set();
            });
            th1.Start();
            th2.Start();
            th3.Start();
            evt3.WaitOne();
            Console.WriteLine("All done");
        }
        //289
        public void WriteOneFileAtTheSameTime()
        {
            string FileName = $"D:/demoFile.data";
            byte[] orgBuffer =
            {
                0x0C,0x10,0x02,
                0xE3,0x71,0xA2,
                0x13,0xB8,0x06
            };
            AutoResetEvent[] writtenEvents =
            {
                new AutoResetEvent(false),
                new AutoResetEvent(false),
                new AutoResetEvent(false)
            };
            for (int i = 0; i < 3; i++)
            {
                Thread th = new Thread((p) =>
                {
                    int currentCount = Convert.ToInt32(p);
                    int copyIndex = currentCount * 3;
                    byte[] tmpBuffer = new byte[3];
                    Array.Copy(orgBuffer, copyIndex, tmpBuffer, 0, 3);
                    // FileShare.Write is necessary.
                    // Without it, the file would not be handle at the same time.
                    // Errors are going to occur.
                    using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
                    {
                        fs.Seek(copyIndex, SeekOrigin.Begin);
                        fs.Write(tmpBuffer, 0, tmpBuffer.Length);
                    }
                    writtenEvents[currentCount].Set();
                });
                th.IsBackground = true;
                th.Start(i);
            }
            Console.WriteLine("Waiting for all threads...");
            WaitHandle.WaitAll(writtenEvents);
            Console.WriteLine("Done");
            using (FileStream fsin = new FileStream(FileName, FileMode.Open))
            {
                byte[] buffer = new byte[fsin.Length];
                fsin.Read(buffer, 0, buffer.Length);
                Console.WriteLine(BitConverter.ToString(buffer));
            }
        }
        //290
        public void LockResource()
        {
            List<int> intList = new List<int>()
            {
                100,105,108,113,265,970,160,
                410,303,302,104,103,102,921,
                500,501,521,522,210,211,212,
                213,214,175,174,376
            };
            for (int i = 0; i < 4; i++)
            {
                Thread th = new Thread(() =>
                {
                    while (true)
                    {
                        // locked resource:intList
                        lock (intList)
                        {
                            if (intList.Count == 0)
                                break;
                            Thread.Sleep(15);
                            intList.RemoveAt(0);
                            Console.WriteLine(intList.Count);
                        }
                    }
                });
                th.Start();
            }
        }
        //291
        public void StartTaskByThreeWays()
        {
            Task task1 = new Task(() =>
            {
                Console.WriteLine("Task one done.");
            });
            task1.Start();
            task1.Wait();
            Task task2 = Task.Run(() =>
            {
                Console.WriteLine("Task two done.");
            });
            task2.Wait();
            TaskFactory factory = new TaskFactory();
            Task task3 = factory.StartNew(() =>
            {
                Console.WriteLine("Task three done.");
            });
            task3.Wait();
            // additional
            Task t4 = Task.Run(() =>
            {
                string fileName = $"D:/test.txt";
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        writer.WriteLine("tssssssssssssdasd");
                    }
                }
            });
            t4.Wait();
        }
        //292
        public void TaskWithReturn()
        {
            var task = Task.Run(() =>
            {
                long r = 1L;
                int t = 1;
                while (t <= 5)
                {
                    r = r * t;
                    t++;
                }
                return r;
            });
            task.Wait();
            var result = task.Result;
            Console.WriteLine(result);
        }
        //293
        public void PassObjectIntoTask()
        {
            var state = (Name: "Jack", Age: 28);
            Task t = new Task(s =>
            {
                (string name, int age) = ((string, int))s;
                Console.WriteLine($"Name:{name}\nAge:{age}");
            }, state);
            t.Start();
            t.Wait();
        }
        //294
        public void TaskContinueWith()
        {
            Task<int> task = Task.Run(() => 10)
                                 .ContinueWith(lasttask => lasttask.Result + 15)
                                 .ContinueWith(lasttask => lasttask.Result + 20);
            task.Wait();
            Console.WriteLine(task.Result);
        }
        //295
        public void ExecuteParallelTask()
        {
            string[] fileNames =
            {
                "demo_1_dx","demo_2_dx","demo_3_dx","demo_4_dx",
                "demo_5_dx","demo_6_dx","demo_7_dx","demo_8_dx"
            };
            Random rand = new Random();
            Parallel.ForEach(fileNames, (fn) =>
            {
                int len;
                byte[] data;
                lock (rand)
                {
                    len = rand.Next(100, 90000);
                    data = new byte[len];
                    rand.NextBytes(data);
                }
                using (FileStream fs = new FileStream($"D:/" + fn, FileMode.Create))
                {
                    fs.Write(data);
                }
                Console.WriteLine($"{fn}:{data.Length}");
            });
        }
        //296
        public Task WorkAsync()
        {
            Task t = new Task(() => Console.WriteLine("Doing something"));
            t.Start();
            return t;
        }
        public async void ExecuteAsyncFunc()
        {
            Task t = WorkAsync();
            await t;
        }
        public void ShowAsyncFunc()
        {
            Console.WriteLine("===============");
            ExecuteAsyncFunc();
        }
        //297
        public async void UseTaskDelay()
        {
            Console.WriteLine("2 seconds");
            await Task.Delay(2000);
            Console.WriteLine("3 seconds");
            await Task.Delay(3000);
            Console.WriteLine("4 seconds");
            await Task.Delay(4000);
        }
        public async void CreateFileAsync()
        {
            Task t = Task.Run(() =>
            {
                string fileName = $"D:/testsss.txt";
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine("sssssss");
                    }
                }
            });
            await t;
        }
        public void CallCreateFileAsync()
        {
            UseTaskDelay();
            //CreateFileAsync();
            //create an infinite loop to test async func.
            while (true)
            {
                Console.WriteLine("Please type in something...");
                string s = Console.ReadLine();
                if (!String.IsNullOrEmpty(s) && "end".Equals(s))
                    break;
            }
        }
        //298
        public void ExecuteThreadLocal()
        {
            ThreadLocal<int> _localvar = new ThreadLocal<int>(true);
            Console.WriteLine("main thread id:" + Thread.CurrentThread.ManagedThreadId);
            Thread th1 = new Thread(() =>
            {
                _localvar.Value = 5000;
                Console.WriteLine($"ID:{Thread.CurrentThread.ManagedThreadId},Thread variable:{_localvar.Value}");
            });
            th1.Start();
            Thread th2 = new Thread(() =>
            {
                _localvar.Value = 9000;
                Console.WriteLine($"ID:{Thread.CurrentThread.ManagedThreadId},Thread variable:{_localvar.Value}");
            });
            th2.Start();
            Thread th3 = new Thread(() =>
            {
                _localvar.Value = 7500;
                Console.WriteLine($"ID:{Thread.CurrentThread.ManagedThreadId},Thread variable:{_localvar.Value}");
            });
            th3.Start();
            th1.Join();
            th2.Join();
            th3.Join();
            Console.WriteLine("All values:");
            foreach (var n in _localvar.Values)
            {
                Console.WriteLine(n);
            }
        }
        //299
        public void MyAsyncLocal()
        {
            RunThisCodeAsync().Wait();
        }
        //If we use ThreadLocal, local.Value will be null.
        //This is because the thread is different after async function.
        public async Task RunThisCodeAsync()
        {
            AsyncLocal<string> local = new AsyncLocal<string>();
            Console.WriteLine($"Initial Thread ID:{Thread.CurrentThread.ManagedThreadId}");
            local.Value = "Follow me";
            Console.WriteLine("Before async...");
            Console.WriteLine(local.Value);
            await Task.Delay(150);
            Console.WriteLine($"After async Thread ID:{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("After async...");
            Console.WriteLine(local.Value);
        }
        //300
        public void MyCancellationToken()
        {
            CancelImplementation();
        }
        public async void CancelImplementation()
        {
            CancellationTokenSource cansrc = new CancellationTokenSource();
            Console.WriteLine("Press c to cancel job.");
            Task.Run(() =>
            {
                while (true)
                {
                    var info = Console.ReadKey(true);
                    if (info.Key == ConsoleKey.C)
                    {
                        cansrc.Cancel();
                        break;
                    }
                }
            });
            int result = await RunAsync(200, cansrc.Token);
            Console.WriteLine("result:" + result);
        }
        public Task<int> RunAsync(int maxNum, CancellationToken token = default)
        {
            TaskCompletionSource<int> tcl = new TaskCompletionSource<int>();
            int x = 0;
            int res = 0;
            while (x < maxNum)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }
                res += x;
                x += 1;
                Task.Delay(500).Wait();
            }
            tcl.SetResult(res);
            return tcl.Task;
        }
    }
}
