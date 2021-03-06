﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Memorandum.Models
{
  public class Message
  {
    [DisplayName("ID")]
    public int ID { get; set; }

    [DisplayName("送信者ID")]
    public int SenderID { get; set; }

    [DisplayName("文章")]
    public string Sentence { get; set; }

    [DisplayName("日期")]
    public int Time { get; set; }

    public virtual ICollection<Account> Accounts { get; set; }

    public virtual ICollection<Reaction> Reactions { get; set; }
  
  }
}