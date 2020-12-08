using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Memorandum.Models
{
  public class MemorandumDb : DbContext
  {
    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Goal> Goals { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Reaction> Reactions { get; set; }
  }
}