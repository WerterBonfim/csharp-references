using System;

namespace C6
{
    public class Employee
    {
        public string Name { get; set; }
        public Address EmployeeAddress { get; set; }

    }

    public class Address
    {
        public string HomeAddress { get; set; }
        public string City { get; set; }
    }

    public class Demo07 : DemoBase
    {      
        public override void Execute()
        {
            var emp = new Employee();

            

            emp.Name = "Werter";
            emp.EmployeeAddress = new Address
            {
                HomeAddress = "Rua ali 123",
                City = "Lizandropolis"
            };

            //C# 5
            if (emp != null && emp.EmployeeAddress != null)
                Console.WriteLine(emp.Name + " " + emp.EmployeeAddress.HomeAddress + " " + emp.EmployeeAddress.City);

            emp.Name = null;

            // C# 6
            Console.WriteLine(emp?.Name + " " + emp?.EmployeeAddress?.HomeAddress + " " + emp?.EmployeeAddress?.City);
        }
    }
}
