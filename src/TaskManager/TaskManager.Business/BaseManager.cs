using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Business
{
    public class BaseManager
    {
        public BaseManager()
        {
            DataMapper.Initialize();
        }
    }
}
