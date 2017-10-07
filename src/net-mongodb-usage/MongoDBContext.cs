using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using net_mongodb_usage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace net_mongothis.db_usage
{
    public class MongoDBContext
    {
        private MongoClient client;
        private MongoServer server;
        private MongoDatabase db;
        public MongoDBContext()
        {
            this.client = new MongoClient("mongodb://127.0.0.1:27017");
            this.server = this.client.GetServer();
            this.db = server.GetDatabase("hr");
        }
        public IEnumerable<Employee> GetEmployee()
        {
            return this.db.GetCollection<Employee>("employee").FindAll();
        }
        public Employee GetEmployee(ObjectId id)
        {
            var result = Query<Employee>.EQ(x => x.Id, id);
            return this.db.GetCollection<Employee>("employee").FindOne(result);
        }
        public IEnumerable<Employee> GetEmployeeByName(string name)
        {
            var result = Query<Employee>.EQ(x => x.Name, name);
            return this.db.GetCollection<Employee>("employee").Find(result);
        }
        public Employee Create(Employee employee)
        {
            this.db.GetCollection<Employee>("employee").Save(employee);
            return employee;
        }
        public void Update(ObjectId id, Employee employee)
        {
            employee.Id = id;
            var result = Query<Employee>.EQ(x => x.Id, id);
            var operation = Update<Employee>.Replace(employee);
            this.db.GetCollection<Employee>("employee").Update(result, operation);
        }
        public void Remove(ObjectId id)
        {
            var result = Query<Employee>.EQ(x => x.Id, id);
            var operation = this.db.GetCollection<Employee>("employee").Remove(result);
        }
    }
}
