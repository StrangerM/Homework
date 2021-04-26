using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.BLL;

namespace Task2.DI
{
    class DIContainer
    {
        private readonly IRepository _service1;
        

        public DIContainer(IRepository service)
        {
            _service1 = service;
            
        }
        public void InitiateServiceMethods(string data)
        {
            _service1.FillInLists(data);
            
        }
    }
}
