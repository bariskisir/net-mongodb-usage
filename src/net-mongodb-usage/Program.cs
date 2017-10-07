using MongoDB.Bson;
using net_mongothis.db_usage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace net_mongodb_usage
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new MongoDBContext();

            // Get all employees
            var allEmployees = db.GetEmployee();

            // Get by id
            var employeeById = db.GetEmployee(new ObjectId("595152fd28c7b9be12251719"));

            // Get by name
            var employeesByName = db.GetEmployeeByName("Alisander");

            // Create new employee
            var employee = new Employee();
            employee.Name = "Kemal";
            employee.Surname = "Etikan";
            employee.Email = "kemaletikan@example.com";

            db.Create(employee);
            // Update existing record
            db.Update(new ObjectId("595152fd28c7b9be12251719"), employee);

            // Remove record
            db.Remove(new ObjectId("595152fd28c7b9be12251719"));
        }
    }
}
