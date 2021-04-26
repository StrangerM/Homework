using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.BLL
{
    public interface IRepository
    {
        void FillInLists(string role);
        void FillInLists();
    }
}
