using CSharp_Ex_2.Models;

var employee1 = new Employee(1, "Phong", 4);
var employee2 = new Employee(2, "Nhi", 7);
var employee3 = new Employee(3, "Huy", 2);

var insurance1 = new LongTermInsurance("A", 12000, 1000, 2);
var insurance2 = new LongTermInsurance("B", 20000, 1000, 3);
var insurance3 = new LongTermInsurance("C", 1000, 100, 1);

var insurance4 = new ShortTermInsurance("D", 9000, 11);
var insurance5 = new ShortTermInsurance("E", 11000, 7);
var insurance6 = new ShortTermInsurance("F", 5000, 8);

var company  = new Company();
employee1.SoldInsurances.Add(insurance1);
employee1.SoldInsurances.Add(insurance2);
employee1.SoldInsurances.Add(insurance4);

// employee2.SoldInsurances.Add(insurance3);

employee3.SoldInsurances.Add(insurance5);
employee3.SoldInsurances.Add(insurance6);

company.Add(employee1);
company.Add(employee2);
company.Add(employee3);

void ex2() {
    foreach(var employee in company.GetAll())
    {
        employee.ShowSoldInsurance();
    }
}

void ex3() {
    var list = company.GetAll().Where(_ => _.CalculateTotalCommission() > 50);
    foreach (var item in list)
    {
        System.Console.WriteLine(item.ToString());
    }
}

void ex4() {
    var list = company.GetAll().Where(_ => !_.CheckKPI());
    foreach (var item in list)
    {
        System.Console.WriteLine(item.ToString());
    }
}

void ex5() {
    var list = company.GetAll().Where(_ => _.CheckKPI());
    foreach (var item in list)
    {
        System.Console.WriteLine(item.ToString());
    }
}
// ex2();
// ex3();
// ex4();
ex5() ;

