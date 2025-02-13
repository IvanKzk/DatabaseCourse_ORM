using Shop.config;
using Shop.model;
using Shop.repository.interfaces;

namespace Shop.repository;

public class DepartmentRepository : IDepartmentRepository
{
    
    private readonly ApplicationDbContext _context;
    
    public DepartmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Department? getDepartmentById(long id)
    {
        return _context.Departments.Find(id);
    }

    public Department? getDepartmentByName(string name)
    {
        return _context.Departments.FirstOrDefault(a => a.department_name == name);
    }

    public string? getAllDepartments()
    {
        return String.Join("\n\n", _context.Departments.ToList());
    }

    public void addDepartment(Department department)
    {
        var found = _context.Departments.FirstOrDefault(a => a.department_name == department.department_name);
        if (found == null)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();   
        }
    }

    public void updateDepartment(Department department)
    {
        _context.Departments.Update(department);  
        _context.SaveChanges();
    }

    public void deleteDepartment(Department department)
    {
        _context.Departments.Remove(department);    
        _context.SaveChanges();
    }
    
}