using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models.ViewModels
{
    public class PageInfo
    {
        public int ItemsTotal { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPageNum =>
            (int)Math.Ceiling((decimal)ItemsTotal/ItemsPerPage);
    }
}