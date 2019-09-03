using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using POSStore.Data.Interfaces;
using POSStore.Data.Model;


namespace POSStore.Data.Repositories
{
    public class CategoryRepos : IProductCategory
    {
        private readonly AppDBInfo appDBInfo;

        public CategoryRepos(AppDBInfo appDBContent)
        {
            this.appDBInfo = appDBContent;
        }

        public IEnumerable<Category> Categories => appDBInfo.Category;
    }
}
