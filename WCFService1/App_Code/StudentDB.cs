using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StudentDB
/// </summary>
public class StudentDB : DbContext
{
    public StudentDB() : base("name=MyConnectionString")
    {
    }
    public System.Data.Entity.DbSet<Student> DemoCodes { get; set; }
}