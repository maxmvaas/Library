using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Library.entities;
using System.Data;

namespace Library.dal
{
    internal interface IDatabaseRepository
    {
        DataTable LoadBooks();

        void Add(Book book);
    }
}
