using Skola.DAL;
using Skola.Models.ViewModels;

namespace Skola.BL
{
    public class ClassService
    {
        private readonly IClassRepository _repo;

        public ClassService(IClassRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<ClassViewModel> GetAll() => _repo.GetAll();
        public ClassViewModel? GetById(int id) => _repo.GetById(id);
        public void Add(ClassViewModel vm) => _repo.Add(vm);
        public void Update(ClassViewModel vm) => _repo.Update(vm);
        public void Delete(int id) => _repo.Delete(id);
    }
}
