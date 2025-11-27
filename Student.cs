namespace dotnetInternTasks;

class Student
{
    public string FirstName
    {
        get;
        set;
    }

    public string LastName
    {
        get;
        set;
    }

    protected byte age;

    public byte Age
    {
        get
        {
            return age;
        }
        set
        {
            if (value > 130)
            {
                age = 130;
            }
            else
            {
                age = value;
            }
        }
    }

    public static int count;

    public Student()
    {
        count++;
        FirstName = $"Test{count}";
        LastName = $"Test{count}";
        Age = 17;
    }

    public Student(string firstName, string lastName, byte age)
    {
        count++;
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public override string ToString()
    {
        return FirstName.PadRight(12, ' ') + LastName.PadRight(12, ' ') + $"{age}".PadRight(3, ' ');
    }
}