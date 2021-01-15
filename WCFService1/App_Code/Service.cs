using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}

	public Student getDetailStudent(int id)
	{
		Student student = db.DemoCodes.Find(id);
		if (student == null)
		{
			return null;
		}
		return student;
	}

	public CompositeType getStudentList(CompositeType composite)
	{
		throw new NotImplementedException();
	}

	public bool updateStudent(Student student)
	{
		try
        {
			db.Entry(student).State = EntityState.Modified;
			db.SaveChanges();
			return true;
		}
		catch
        {
			return false;
        }
    }

	private StudentDB db = new StudentDB();
	public Student Add(Student student)
	{
		db.DemoCodes.Add(student);
		db.SaveChanges();
		return student;
	}

	public List<Student> GetStudents()
	{
		return db.DemoCodes.ToList();
	}
}
