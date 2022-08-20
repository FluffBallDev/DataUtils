using System.Collections.Generic;
using System.Threading.Tasks;
using DataUtils.Example.Models;

namespace DataUtils.Example.ModelMethods
{
    public interface IExampleModelMethods
    {
        Task<List<ExampleModel>> GetExamples();
        Task InsertExample(ExampleModel exampleModel);
    }
}