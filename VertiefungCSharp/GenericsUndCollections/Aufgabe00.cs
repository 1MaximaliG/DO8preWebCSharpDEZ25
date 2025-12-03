using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsUndCollections
{
    public class Job
    {
        public string Bezeichnung { get; }
        public string Auftraggeber { get; }
        public TimeSpan Dauer { get; }
        public Job(string Bezeichnung, string Auftraggeber, TimeSpan dauer)
        {
            this.Bezeichnung = Bezeichnung;
            this.Auftraggeber = Auftraggeber;
            Dauer = dauer;
        }
    }//Ende Job
    public class Jobverwaltung
    {
        private Queue<Job> _jobs = new Queue<Job>();
        public void AddJob(Job job)
        {
            _jobs.Enqueue(job);
            Console.WriteLine(_jobs.Count);
        }
        public void GetJobDone()
        {
            Console.WriteLine(_jobs.Peek().Bezeichnung);
            Console.WriteLine(_jobs.Peek().Auftraggeber);
            Console.WriteLine(_jobs.Peek().Dauer);
            _jobs.Dequeue();
            Console.WriteLine(_jobs.Count);
        }
        public void ShowAllJobs()
        {
            foreach (var item in _jobs)
            {
                Console.WriteLine(item.Bezeichnung);
                Console.WriteLine(item.Auftraggeber);
                Console.WriteLine(item.Dauer);
            }
        }
    }
    internal class Aufgabe00
    {
        public static void TuWas()
        {
            Job job = new Job("Hausputz", "Mutti", new TimeSpan(1, 30, 25));
            Job job2 = new Job("Coden", "Gronemann GmbH", new TimeSpan(128,2, 30, 25));
            Job job3 = new Job("Weltherrschaft übernehmen", "Brain", new TimeSpan(33, 33, 33));
            Jobverwaltung verwaltung = new Jobverwaltung();
            verwaltung.AddJob(job);
            verwaltung.AddJob(job3);
            verwaltung.AddJob(job2);
            verwaltung.GetJobDone();
            verwaltung.GetJobDone();
            verwaltung.AddJob(job);
            verwaltung.GetJobDone();
            verwaltung.GetJobDone();
        }
    }
}
