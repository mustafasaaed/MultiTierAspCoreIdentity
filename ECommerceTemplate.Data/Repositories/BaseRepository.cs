using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceTemplate.Data.Repositories
{
   internal class BaseRepository
    {

        private readonly DbContext _context;

        public DbContext Context
        {
            get { return _context; }
        }


        public BaseRepository(DbContext context)
        {
            this._context = context;
        }


    }
}
