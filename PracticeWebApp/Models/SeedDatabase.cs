using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PracticeWebApp.Models
{
    public static class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TaskTrackerDbContext(serviceProvider.GetRequiredService<DbContextOptions<TaskTrackerDbContext>>()))
            {
                if (context.Tasks.Any())
                {
                    return;
                }
                else
                {
                    String jsonData = "";
                    using (StreamReader reader = new StreamReader("./wwwroot/data.json"))
                    {
                        jsonData = reader.ReadToEnd();
                    }
                    List<Task> tasks = JsonConvert.DeserializeObject<List<Task>>(jsonData);
                    context.Tasks.AddRange(tasks);
                    context.SaveChanges();
                }
            }
        }
    }
}
