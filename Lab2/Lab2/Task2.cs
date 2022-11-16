using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2;

public static class Task2
{
    private static List<Job> GetUnorderedJobs()
    {
        var result = new List<Job>();
        var exit = false;
        int idIterator = 0;
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
               || !double.TryParse(values[0], out var jobStart)
               || !double.TryParse(values[1], out var jobDeadline))
            {
                continue;
            }

            idIterator++;
            var newJob = new Job()
            {
                Id = idIterator,
                Deadline = jobDeadline,
                StartTime = jobStart
            };
            result.Add(newJob);
        }

        return result;
    }

    public static void Run()
    {
        Console.WriteLine("Please, enter all the tasks as: \n" +
                          "\tstart deadline" +
                          "\nTo end an input, enter a blank line");
        var orderedJobs = GetUnorderedJobs()
            .OrderBy(job => job.Deadline)
            .ToList();
        double currentTime = 0;
        foreach (var job in orderedJobs)
        {
            if (job.StartTime < currentTime)
            {
                continue;
            }
            Console.WriteLine($"Added job with id:{job.Id}" +
                              $"\tstart:{job.StartTime}" +
                              $"\tdeadline:{job.Deadline}" +
                              $"\tprevious time:{currentTime}");
            currentTime = job.Deadline;
        }
    }
}