var s = new Stopwatch();

s.Start();

Thread.Sleep(1000);

Console.WriteLine(s.ElapsedMilliseconds);
Thread.Sleep(1000);


Console.WriteLine(s.ElapsedMilliseconds);


s.Stop();
