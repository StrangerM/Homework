using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.BLL;

namespace Task2.DI
{
    public class DIContainer
    {
        private readonly IRepository _repository;
        

        public DIContainer(IRepository repository)
        {
            _repository = repository;
            
        }
        public void InitiateServiceMethods(string data)
        {
            _repository.FillInLists(data);
            
        }
    }
}
