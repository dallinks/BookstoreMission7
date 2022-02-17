using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore2.Models.ViewModels
    //PageInfo Viewmodel, has information about what page we're going to use
{
    public class PageInfo
    {
        public int TotalNumProjects { get; set; }
        public int ProjectsPerPage { get; set; }
        public int CurrentPage { get; set; }
        //how many pages we need

        public int TotalPages => (int) Math.Ceiling((double) TotalNumProjects / ProjectsPerPage); 
    }
}
