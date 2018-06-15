namespace SqliteBox
{
    using System;
    using System.Diagnostics;
    using System.IO;

    class Program
    {
        static void Main()
        {
            File.Delete(Database.FileName);
            const int n = 100_000;
            using (var db = new Database())
            {
                var sw = Stopwatch.StartNew();
                for (var i = 0; i < n; i++)
                {
                    db.Foos.Add(new Foo { Text = "abc" });
                }

                db.SaveChanges();
                sw.Stop();
                Console.WriteLine($"Inserting {n} items took {sw.ElapsedMilliseconds} ms ({sw.ElapsedMilliseconds / n} ms/insert), file size: {new FileInfo(Database.FileName).Length/(1024)} KB");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}
