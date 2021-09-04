using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IServices<T>
    {
        void Insert(T variable);
        List<T> Get();
        void Update(T variable);
        void Delete(T variable);
        T Search(int Id);

    }
}
