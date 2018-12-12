using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleApp.Models;

namespace VehicleApp.Models.VehicleMakeViewModels
{
    public class IndexViewModel //<T> : List<T>
    {
        /*
        public Guid Id { get; set; }

        [Required, StringLength(20)]
        public string Name { get; set; }

        [StringLength(10)]
        [Display(Name = "Abbreviation")]
        public string Abrv { get; set; }
        */
        //public ICollection<VehicleModel> VehicleModels { get; set; }

        //public VehicleMake VehicleMake { get; set; }

        public List<VehicleMake> VehicleMakes { get; set; }

        /*
        public int PageIndex { get; set; }
        public int NumberOfPages { get; set; }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < NumberOfPages);
            }
        }

        /*
        // Constructor
        public IndexViewModel(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            NumberOfPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        // Used for creating the PagedList - constructors can't run asynchronous code
        public static async Task<IndexViewModel<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return new IndexViewModel<T>(items, count, pageIndex, pageSize);
        }
        */
    }
}
