using DataAccessLayer.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenaricRepoWithEF.Models
{
    public class HomeModel
    {
        public List<Post> PostsList { get; set; }
        public List<Blog> BlogsList { get; set; }
    }
}
