class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Department { get; set; }
    public Student(int id, string name, int age, string dept)
    {
        Id = id;
        Name = name;
        Age = age;
        Department = dept;
    }
    // Convert to string for file saving
    public override string ToString()
    {
        return $"{Id}, {Name}, {Age}, {Department}";
    }
}