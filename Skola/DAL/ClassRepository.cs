using Skola.Data;
using Skola.Models.ViewModels;
using Skola.Models;
using Microsoft.EntityFrameworkCore;

namespace Skola.DAL
{
    public class ClassRepository : IClassRepository
    {
        private readonly AppDbContext _context;

        public ClassRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ClassViewModel> GetAll()
        {
            return _context.Classes.Select(c => new ClassViewModel
            {
                ClassId = c.ClassId,
                GradeId = c.GradeId,
                Naziv = c.Naziv,
                Vrsta = c.VrstaOdeljenja.Value,
                JezikNastave = c.JezikNastave.Value,
                Kombinovano = c.Kombinovano,
                CelodnevnaNastava = c.CelodnevnaNastava,
                IzdvojenoOdeljenje = c.IzdvojenoOdeljenje,
                NazivIzdvojeneSkole = c.NazivIzdvojeneSkole,
                OdeljenjskiStaresina = c.OdeljenjskiStaresina,
                Smena = c.Smena,
                UkupanBrojUcenika = c.UkupanBrojUcenika,
                BrojUcenika = c.BrojUcenika,
                BrojUcenica = c.BrojUcenica
            }).ToList();
        }

        public ClassViewModel? GetById(int id)
        {
            var c = _context.Classes
                .Include(x => x.VrstaOdeljenja)
                .Include(x => x.JezikNastave)
                .FirstOrDefault(x => x.ClassId == id);

            if (c == null) return null;

            return new ClassViewModel
            {
                ClassId = c.ClassId,
                GradeId = c.GradeId,
                Naziv = c.Naziv,
                Vrsta = c.VrstaOdeljenja.Value,
                JezikNastave = c.JezikNastave.Value,
                Kombinovano = c.Kombinovano,
                CelodnevnaNastava = c.CelodnevnaNastava,
                IzdvojenoOdeljenje = c.IzdvojenoOdeljenje,
                NazivIzdvojeneSkole = c.NazivIzdvojeneSkole,
                OdeljenjskiStaresina = c.OdeljenjskiStaresina,
                Smena = c.Smena,
                UkupanBrojUcenika = c.UkupanBrojUcenika,
                BrojUcenika = c.BrojUcenika,
                BrojUcenica = c.BrojUcenica
            };
        }


        public void Add(ClassViewModel viewModel)
        {
            // ✅ Validacija GradeId
            if (!_context.Grades.Any(g => g.GradeId == viewModel.GradeId))
                throw new Exception("Ne postoji izabrani razred (GradeId).");

            // ✅ Validacija šifarnika
            if (string.IsNullOrWhiteSpace(viewModel.Vrsta))
                throw new Exception("Vrsta odeljenja je obavezna.");

            if (string.IsNullOrWhiteSpace(viewModel.JezikNastave))
                throw new Exception("Jezik nastave je obavezan.");

            var entity = new Class
            {
                GradeId = viewModel.GradeId,
                Naziv = viewModel.Naziv,
                VrstaOdeljenjaId = GetCodebookId(viewModel.Vrsta),
                JezikNastaveId = GetCodebookId(viewModel.JezikNastave),
                Kombinovano = viewModel.Kombinovano,
                CelodnevnaNastava = viewModel.CelodnevnaNastava,
                IzdvojenoOdeljenje = viewModel.IzdvojenoOdeljenje,
                NazivIzdvojeneSkole = viewModel.NazivIzdvojeneSkole,
                OdeljenjskiStaresina = viewModel.OdeljenjskiStaresina,
                Smena = viewModel.Smena,
                UkupanBrojUcenika = viewModel.UkupanBrojUcenika,
                BrojUcenika = viewModel.BrojUcenika,
                BrojUcenica = viewModel.BrojUcenica
            };

            _context.Classes.Add(entity);
            _context.SaveChanges();
        }

        public void Update(ClassViewModel viewModel)
        {
            var entity = _context.Classes.FirstOrDefault(x => x.ClassId == viewModel.ClassId);
            if (entity == null) return;

            entity.Naziv = viewModel.Naziv;
            entity.GradeId = viewModel.GradeId;
            entity.VrstaOdeljenjaId = GetCodebookId(viewModel.Vrsta);
            entity.JezikNastaveId = GetCodebookId(viewModel.JezikNastave);
            entity.Kombinovano = viewModel.Kombinovano;
            entity.CelodnevnaNastava = viewModel.CelodnevnaNastava;
            entity.IzdvojenoOdeljenje = viewModel.IzdvojenoOdeljenje;
            entity.NazivIzdvojeneSkole = viewModel.NazivIzdvojeneSkole;
            entity.OdeljenjskiStaresina = viewModel.OdeljenjskiStaresina;
            entity.Smena = viewModel.Smena;
            entity.UkupanBrojUcenika = viewModel.UkupanBrojUcenika;
            entity.BrojUcenika = viewModel.BrojUcenika;
            entity.BrojUcenica = viewModel.BrojUcenica;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Classes.FirstOrDefault(x => x.ClassId == id);
            if (entity == null) return;

            _context.Classes.Remove(entity);
            _context.SaveChanges();
        }

        public bool Exists(int id)
        {
            return _context.Classes.Any(x => x.ClassId == id);
        }

        private int GetCodebookId(string value)
        {
            var item = _context.CodebookItems.FirstOrDefault(x => x.Value == value);
            if (item == null)
                throw new Exception($"Vrednost '{value}' nije pronađena u šifarniku.");
            return item.ItemId;
        }
    }
}
