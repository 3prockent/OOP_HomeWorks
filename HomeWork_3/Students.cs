using System;
using System.Collections.Generic;

class Student
{
    private string name;
    protected string state;

    public string getName()
    {
        return name;
    }

    public Student(string name)
    {
        this.name = name;
        state = "";
    }

    public string getState()
    {
        return state;
    }

    public void Relax()
    {
        state += "Relax ";
    }
    public void Read()
    {
        state += "Read ";
    }
    public void Write()
    {
        state += "Write ";
    }

    public virtual void Study()
    {

    }
}

class GoodStudent : Student
{
    public GoodStudent(string name) : base(name)
    {
        state += "good ";
    }
    public override void Study()
    {
        Read();
        Write();
        Read();
        Write();
        Relax();
    }
}

class BadStudent : Student
{
    public BadStudent(string name) : base(name)
    {
        state += "bad ";
    }
    public override void Study()
    {
        Relax();
        Relax();
        Relax();
        Relax();
        Read();
    }
}

class Group
{
    private string nameGroup;
    private List<Student> studentsList;
    public Group(string name)
    {
        studentsList = new List<Student>();
        nameGroup = name;
    }

    public void AddStudent(Student st)
    {
        studentsList.Add(st);
    }
    public string GetInfo()
    {
        string result = "";
        result += nameGroup + " :\n";
        foreach (Student s in studentsList)
        {
            result += s.getName() + "\n";
        }
        return result;
    }

    public string GetFullInfo()
    {
        string result = "";
        result += nameGroup + " :\n";
        foreach (Student s in studentsList)
        {
            result += s.getName() + " - " + s.getState() + "\n";
        }
        return result;
    }

}

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            Student st1 = new Student("Klara");
            GoodStudent st2 = new GoodStudent("Vlad");
            BadStudent st3 = new BadStudent("Nataliia");
            Group group1 = new Group("K-24");
            group1.AddStudent(st1);
            group1.AddStudent(st3);
            group1.AddStudent(st2);
            st1.Study();
            st2.Study();
            st3.Study();
            Console.Write(group1.GetInfo());
            Console.Write(group1.GetFullInfo());
        }
    }
}

    