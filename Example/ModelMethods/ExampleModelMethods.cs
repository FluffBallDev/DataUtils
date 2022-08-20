using System.Collections.Generic;
using System.Threading.Tasks;
using DataUtils.Example.Models;

namespace DataUtils.Example.ModelMethods
{
    /// <summary>
    /// An example ModelMethods class
    /// You will need one of these for each DataModel you have / that needs a different SQL string.
    /// </summary>
    public class ExampleModelMethods : IExampleModelMethods
    {
        private readonly ISqlDataManager _db;
        
        /// <summary>
        /// We pass in the ISQLDatamanager here and assign it to a local variable.
        /// </summary>
        /// <param name="db">ISQLDataManager</param>
        public ExampleModelMethods(ISqlDataManager db)
        {
            _db = db;
        }
        /// <summary>
        /// A simple Get method for loading stuff from the database.
        /// </summary>
        /// <returns>a List of ExampleModel's from the Database provided that they exist</returns>
        public Task<List<ExampleModel>> GetExamples()
        {
            string sql = "select * from myDatabase.myTable";

            return _db.LoadData<ExampleModel, dynamic>(sql, new { });
        }

        /// <summary>
        /// For inserting data we want to pass in the Model of data that needs to be put in the database.
        /// </summary>
        /// <param name="exampleModel">Model to assign data and attempt to insert provided that all the fields match up</param>
        /// <returns>Save Action</returns>
        public Task InsertExample(ExampleModel exampleModel)
        {
            string sql = @"insert into myDatabase.myTable (Name, Age) values (@Name, @Age);";

            return _db.SaveData(sql, exampleModel);
        }
    }
}