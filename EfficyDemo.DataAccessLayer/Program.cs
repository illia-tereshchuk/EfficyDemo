﻿using System;
using System.Linq;
using EfficyDemo.Dal;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        // Test commit on new OS
        using (var context = new EfficyDbContext())
        {
            var employees = context.Employees
                .Include(e => e.Team)
                .Include(e => e.Counters)
                .ToList();

            foreach (var employee in employees)
            {
                Console.WriteLine($"Employee: {employee.Name}, Team: {employee.Team.Name}");
                foreach (var counter in employee.Counters)
                {
                    Console.WriteLine($"  Counter: {counter.Value}");
                }
            }
        }
    }
}