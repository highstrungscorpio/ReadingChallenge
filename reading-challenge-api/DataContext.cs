using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReadingChallengeApi.Models;

namespace ReadingChallengeApi
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Prompt> Prompts { get; set; }
        public DbSet<PromptBook> PromptBooks { get; set; }
    }
}