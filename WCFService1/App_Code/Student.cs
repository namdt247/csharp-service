using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for Student
/// </summary>
[DataContract]
public class Student
{
    [DataMember]
    public int Id { get; set; }
    [DataMember]
    public string RollNumber { get; set; }
    [DataMember]
    public string Name { get; set; }
    [DataMember]
    public string Birthday { get; set; }
    [DataMember]
    public GenderStudent Gender { get; set; }
    [DataMember]
    public string Email { get; set; }
    [DataMember]
    public string Description { get; set; }
}

public enum GenderStudent
{
    Male, Female
}