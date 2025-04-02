using CSharp_Ex_3.Models;

Company company = new Company();

// Thêm nhân viên vào công ty
company.AddEmployee(new ProductionEmployee("Nguyen Van A", new DateTime(1990, 5, 20), "Hanoi", 100));
company.AddEmployee(new DailyEmployee("Tran Thi B", new DateTime(1985, 10, 15), "HCM", 22));
company.AddEmployee(new Manager("Le Van C", new DateTime(1980, 7, 10), "Da Nang", 15000000, 2.5m));

Console.WriteLine("Danh sách nhân viên:");
company.DisplayAllEmployees();
void ex1() {
    Console.WriteLine($"Tổng lương công ty phải trả: {company.GetTotalSalary():N0} VND");
}
void ex2() {
    var highestPaid = company.GetHighestPaidEmployee();
    Console.WriteLine($"Nhân viên có lương cao nhất: {highestPaid?.FullName}, Lương: {highestPaid?.CalculateSalary():N0} VND");
}

void ex3() {
    var lowestPaid = company.GetLowestPaidEmployee();
    Console.WriteLine($"Nhân viên có lương thấp nhất: {lowestPaid?.FullName}, Lương: {lowestPaid?.CalculateSalary():N0} VND");
}

ex1();
ex2();
ex3();

