using ASPNETLabCourse.Database;
using ASPNETLabCourse.Interfaces;
using ASPNETLabCourse.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ASPNETLabCourse.Repositories
{
    public class ShoesRepository : IAllShoes
    {
        private readonly AppDbContent appDbContent;

        public ShoesRepository(AppDbContent appDbContent) { this.appDbContent = appDbContent; }

        public IEnumerable<Shoes> GetShoes => appDbContent.Shoes.Include(s => s.Category);

        public Shoes GetShoesById(int Id) => appDbContent.Shoes.FirstOrDefault(s => s.Id == Id);

        public IEnumerable<Shoes> GetShoesByCategory(string Category) => 
            appDbContent.Shoes.Where(s => s.Category.Name.Equals(Category)).Include(s => s.Category);
    }
}