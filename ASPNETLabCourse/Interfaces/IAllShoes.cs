using ASPNETLabCourse.Models;
using System.Collections.Generic;

namespace ASPNETLabCourse.Interfaces
{
    public interface IAllShoes
    {
        IEnumerable<Shoes> GetShoes { get; }
        Shoes GetShoesById (int Id);
        IEnumerable<Shoes> GetShoesByCategory (string Category);
    }
}
