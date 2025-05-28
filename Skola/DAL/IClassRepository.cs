using Skola.Models.ViewModels;

namespace Skola.DAL
{
    public interface IClassRepository
    {
        IEnumerable<ClassViewModel> GetAll();
        ClassViewModel? GetById(int id);
        void Add(ClassViewModel viewModel);
        void Update(ClassViewModel viewModel);
        void Delete(int id);
        bool Exists(int id);
    }
}
