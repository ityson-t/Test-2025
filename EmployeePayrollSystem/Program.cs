namespace EmployeePayrollSystem
{
    //工资计算接口
    interface ISalaryCalculator
    {
        decimal CalculateSalary();
    }
    internal static class Menu
    {
        //主菜单
        public static void DisplayMainMenu()
        {
            Console.WriteLine("=== 员工工资管理系统 ===");
            Console.WriteLine("1. 添加部门");
            Console.WriteLine("2. 添加员工");
            Console.WriteLine("3. 显示部门");
            Console.WriteLine("4. 显示员工");
            Console.WriteLine("5. 计算工资");
            Console.WriteLine("6. 查找员工");
            Console.WriteLine("7. 退出系统");
        }
        //添加员工子菜单
        public static void DisplayAddEmployeeMenu()
        {
            Console.WriteLine("=== 添加员工 ===");
            Console.WriteLine("1. 管理岗位");
            Console.WriteLine("2. 技术岗位");
            Console.WriteLine("3. 普通岗位");
        }
    }
    internal static class UserInputHelper
    {
        //检查整数输入
        public static int GetIntInput(string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt}");
                if (int.TryParse(Console.ReadLine(), out int result) && result > 0)
                {
                    return result;
                }
                Console.WriteLine($"请输入正整数。");
            }
        }
        public static int GetMenuChoice(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write($"{prompt} ({min}-{max}):");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= min && choice <= max)
                {
                    return choice;
                }
                Console.WriteLine($"请输入 {min} 到 {max} 之间的数字。");
            }
        }
        //检查金额输入
        public static decimal GetDecimalInput(string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt}");
                if (decimal.TryParse(Console.ReadLine(), out decimal result) && result > 0)
                {
                    return result;
                }
                Console.WriteLine($"请输入正数。");
            }
        }
        //检查字符串输入
        public static string GetStringInput(string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt}");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                Console.WriteLine($"输入不能为空。");
            }
        }
    }
    abstract internal class Employee : ISalaryCalculator
    {
        public int ID { get; }
        abstract public string Name { get; set; }
        abstract public string Department { get; set; }
        abstract public decimal BaseSalary { get; set; }
        abstract public decimal Bonus { get; set; }
        abstract public decimal TotalSalary { get; }
        public Employee(int id, string name, decimal baseSalary, decimal bonus, string department)
        {
            ID = id;
            Name = name;
            BaseSalary = baseSalary;
            Bonus = bonus;
            Department = department;
        }
        abstract public decimal CalculateSalary();
        public override string ToString()
        {
            return $"ID： {ID}，姓名： {Name},部门：{Department},基本工资：{BaseSalary}，奖金：{Bonus}";
        }
    }
    internal class ManagerEmployee : Employee
    {
        public override string Name { get; set; }
        public override string Department { get; set; }
        public override decimal BaseSalary { get; set; }
        public override decimal Bonus { get; set; }
        public decimal StockOptions { get; set; }
        public override decimal TotalSalary => CalculateSalary();
        public ManagerEmployee(int id, string name, decimal baseSalary, decimal bonus, string department) : base(id, name, baseSalary, bonus, department)
        {
            StockOptions = UserInputHelper.GetDecimalInput("请输入股票期权：");
        }
        public override decimal CalculateSalary()
        {
            return BaseSalary + Bonus + StockOptions;
        }
        public override string ToString()
        {
            return base.ToString() + $",股票期权：{StockOptions},总工资：{TotalSalary}";
        }
    }
    internal class EngineerEmployee : Employee
    {
        public override string Name { get; set; }
        public override string Department { get; set; }
        public override decimal BaseSalary { get; set; }
        public override decimal Bonus { get; set; }
        public decimal OvertimeSalary { get; set; }
        public override decimal TotalSalary => CalculateSalary();
        public EngineerEmployee(int id, string name, decimal baseSalary, decimal bonus, string department) : base(id, name, baseSalary, bonus, department)
        {
            OvertimeSalary = UserInputHelper.GetDecimalInput("请输入加班工资：");
        }
        public override decimal CalculateSalary()
        {
            return BaseSalary + Bonus + OvertimeSalary;
        }
        public override string ToString()
        {
            return base.ToString() + $",加班工资：{OvertimeSalary},总工资：{TotalSalary}";
        }
    }
    internal class RegularEmployee : Employee
    {
        public override string Name { get; set; }
        public override string Department { get; set; }
        public override decimal BaseSalary { get; set; }
        public override decimal Bonus { get; set; }
        public override decimal TotalSalary => CalculateSalary();
        public RegularEmployee(int id, string name, decimal baseSalary, decimal bonus, string department) : base(id, name, baseSalary, bonus, department)
        {
        }
        public override decimal CalculateSalary()
        {
            return BaseSalary + Bonus;
        }
        public override string ToString()
        {
            return base.ToString() + $",总工资：{TotalSalary}";
        }
    }
    internal static class Company
    {
        public static List<Department> Departments = new();
        public static void AddDepartment()
        {
            Departments.Add(new(UserInputHelper.GetStringInput("请输入部门名称：")));
        }
        public static void DisplayDepartments()
        {
            if (Departments.Count == 0)
            {
                Console.WriteLine("没有部门记录。");
                return;
            }
            Console.WriteLine("=== 所有部门 ===");
            for (int i = 0; i < Departments.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Departments[i].Name}");
            }
        }
        public static void DisplayAllEmployees(List<Employee> employees)
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("没有员工记录。");
                return;
            }
            Console.WriteLine("=== 所有员工 ===");
            for(int i = 0; i < Departments.Count; i++)
            {
                Console.WriteLine($"部门 {i + 1}: {Departments[i].Name}");
                Departments[i].DisplayEmployees(employees, i + 1);
            }
        }
        public static void CalculateAllSalaries(List<Employee> employees)
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("没有员工记录。");
                return;
            }
            Console.WriteLine("=== 计算所有员工工资 ===");
            foreach (var emp in employees)
            {
                Console.WriteLine($"员工ID: {emp.ID}, 姓名: {emp.Name}, 总工资: {emp.TotalSalary}");
            }
        }
        //public static void FindEmployeeById(List<Employee> employees, int id)
        //{
        //    bool isFound = false;
        //    foreach (var emp in employees)
        //    {
        //        if (emp.ID == id)
        //        {
        //            isFound = true;
        //            Console.WriteLine("=== 员工信息 ===");
        //            Console.WriteLine(emp.ToString());
        //            return;
        //        }
        //    }
        //    if (!isFound)
        //    {
        //        throw new Exception("未找到该员工ID。");
        //    }
        //}
        public static void FindEmployeeByDepartment(List<Employee> employees, int id)
        {
            bool isFound = false;
            foreach (var emp in employees)
            {
                if (emp.ID==id)
                {
                    isFound = true;
                    Console.WriteLine(emp.Department);
                }
            }
            if (!isFound)
            {
                throw new Exception("该部门没有员工记录。");
            }
        }
    }
    internal class Department
    {
        public decimal DepartmentTotalSalary { get; set; }
        public string Name { get; set; }
        public Department(string name)
        {
            Name = name;
        }
        public static Employee AddEmployee(int employeeClass)
        {
            if (employeeClass == 1)
            {
                foreach (var dept in Company.Departments)
                {
                    Console.WriteLine($"{Company.Departments.IndexOf(dept) + 1}. {dept.Name}");
                }
                int deptNo = UserInputHelper.GetMenuChoice("请输入部门编号：", 1, Company.Departments.Count);
                string departmentName = Company.Departments[deptNo - 1].Name;
                int id = UserInputHelper.GetIntInput("请输入员工ID：");
                string name = UserInputHelper.GetStringInput("请输入员工姓名：");
                decimal baseSalary = UserInputHelper.GetDecimalInput("请输入基本工资：");
                decimal bonus = UserInputHelper.GetDecimalInput("请输入奖金：");
                return new ManagerEmployee(id, name, baseSalary, bonus, departmentName);
            }
            else if (employeeClass == 2)
            {
                foreach (var dept in Company.Departments)
                {
                    Console.WriteLine($"{Company.Departments.IndexOf(dept) + 1}. {dept.Name}");
                }
                int deptNo = UserInputHelper.GetMenuChoice("请输入部门编号：", 1, Company.Departments.Count);
                string departmentName = Company.Departments[deptNo - 1].Name;
                int id = UserInputHelper.GetIntInput("请输入员工ID：");
                string name = UserInputHelper.GetStringInput("请输入员工姓名：");
                decimal baseSalary = UserInputHelper.GetDecimalInput("请输入基本工资：");
                decimal bonus = UserInputHelper.GetDecimalInput("请输入奖金：");
                return new EngineerEmployee(id, name, baseSalary, bonus, departmentName);
            }
            else
            {
                foreach (var dept in Company.Departments)
                {
                    Console.WriteLine($"{Company.Departments.IndexOf(dept) + 1}. {dept.Name}");
                }
                int deptNo = UserInputHelper.GetMenuChoice("请输入部门编号：", 1, Company.Departments.Count);
                string departmentName = Company.Departments[deptNo - 1].Name;
                int id = UserInputHelper.GetIntInput("请输入员工ID：");
                string name = UserInputHelper.GetStringInput("请输入员工姓名：");
                decimal baseSalary = UserInputHelper.GetDecimalInput("请输入基本工资：");
                decimal bonus = UserInputHelper.GetDecimalInput("请输入奖金：");                
                return new RegularEmployee(id, name, baseSalary, bonus, departmentName);
            }
        }
        public void DisplayEmployees(List<Employee> employees)
        {
            Console.WriteLine($"=== 部门: {Name} 的员工 ===");
            foreach (var emp in employees)
            {                
                Console.WriteLine(emp.ToString());
            }
        }
        public void DisplayEmployees(List<Employee> employees, int deptNo)
        {
            bool hasEmployee = false;
            foreach (var emp in employees)
            {
                if (emp.Department == Name)
                {
                    DepartmentTotalSalary += emp.TotalSalary;
                    hasEmployee = true;
                    Console.WriteLine(emp.ToString());
                }
            }
            if (!hasEmployee)
            {
                Console.WriteLine("该部门没有员工记录。");
            }
            Console.WriteLine($"部门总工资：{DepartmentTotalSalary}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new();
            while (true)
            {
                Menu.DisplayMainMenu();
                int choice = UserInputHelper.GetMenuChoice("请选择操作", 1, 7);
                try
                {
                    switch (choice)
                    {
                        case 1:
                            Company.AddDepartment();
                            Console.WriteLine("部门添加成功！");
                            break;
                        case 2:                            
                            if (Company.Departments.Count != 0)
                            {
                                Menu.DisplayAddEmployeeMenu();
                                int empType = UserInputHelper.GetMenuChoice("请选择员工类型", 1, 3);
                                Employee newEmp = Department.AddEmployee(empType);
                                employees.Add(newEmp);
                                Console.WriteLine("员工添加成功！");
                                break;
                            }
                            else
                            {
                                throw new Exception("请先添加部门。");
                            }
                        case 3:
                            Company.DisplayDepartments();
                            break;
                        case 4:
                            Company.DisplayAllEmployees(employees);
                            break;
                        case 5:
                            Company.CalculateAllSalaries(employees);
                            break;
                        case 6:
                            int searchId = UserInputHelper.GetIntInput("请输入要查找的员工ID：");
                            Company.FindEmployeeByDepartment(employees, searchId);
                            break;
                        case 7:
                            Console.WriteLine("退出系统。");
                            return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"错误: {ex.Message}");
                }
            }
        }
    }
}
