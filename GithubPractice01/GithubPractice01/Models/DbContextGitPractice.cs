using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GithubPractice01.Models
{
    public class DbContextGitPractice : DbContext
    {
        public DbSet<BulletinBoard> BulletinBoards { get; set; }
    }
}