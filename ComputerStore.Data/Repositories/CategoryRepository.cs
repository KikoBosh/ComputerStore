using ComputerStore.Data.Entities;
using ComputerStore.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerStore.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ComputerStoreContext _context;

        public CategoryRepository(ComputerStoreContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public bool Delete(Category category)
        {
            try
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }



        public Category GetById(int id)
        {
            return _context.Categories.Find(id);
        }

        public void Update(Category category)
        {
            var existingCategory = _context.Categories.Find(category.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;
                _context.SaveChanges();
            }
        }
    }
}
