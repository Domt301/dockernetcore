using System.Linq;

namespace DockerCore.Models {
    public interface IRepository
    {
        IQueryable<Product> Products {get;}
    }
}