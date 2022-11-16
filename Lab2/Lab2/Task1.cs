using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2;

public static class Task1
{
    private static List<Job> GetUnorderedJobs()
    {
        var result = new List<Job>();
        var exit = false;
        var idIterator = 0;
        while (!exit)
        {
            var line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                exit = true;
                break;
            }

            var values = line.Split(' ', StringSplitOptions.TrimEntries);
            if(values.Length != 2 
               || !double.TryParse(values[0], out var jobLength)
               || !double.TryParse(values[1], out var jobDeadline))
            {
                continue;
            }

            idIterator++;
            var newJob = new Job()
            {
                Id = idIterator,
                Deadline = jobDeadline,
                Length = jobLength
            };
            result.Add(newJob);
        }

        return result;
    }
    public static void Run(Func<double, double> getLateness)
    {
        Console.WriteLine("Please, enter all the tasks as: \n" +
                          "\tlength deadline" +
                          "\nTo end an input, enter a blank line");
        var orderedJobs = GetUnorderedJobs()
            .OrderBy(job => job.Deadline)
            .ToList();
        double currentTime = 0;
        foreach (var job in orderedJobs)
        {
            var lateness = currentTime + job.Length - job.Deadline;
            currentTime += job.Length;
            Console.WriteLine($"Added job with id:{job.Id}" +
                              $"\tlen:{job.Length}" +
                              $"\tdeadline:{job.Deadline}" +
                              $"\tweighted late:{getLateness(lateness)}" +
                              $"\tcurrent time:{currentTime}");
        }
        
    }
}