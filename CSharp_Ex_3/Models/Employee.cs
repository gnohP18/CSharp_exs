namespace Models
{
    public abstract class Employee
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }

        public Employee(string fullName, DateTime birthDate, string address)
        {
            FullName = fullName;
            BirthDate = birthDate;
            Address = address;
        }

        // Phương thức abstract bắt buộc các lớp con phải triển khai
        public abstract decimal CalculateSalary();

        public override string ToString()
        {
            return $"{FullName}, {BirthDate.ToShortDateString()}, {Address}, Lương: {CalculateSalary():N0} VND";
        }
    }
}
