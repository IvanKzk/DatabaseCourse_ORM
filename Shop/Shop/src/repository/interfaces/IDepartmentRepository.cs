using Shop.model;

namespace Shop.repository.interfaces;

public interface IDepartmentRepository
{
    Department? getDepartmentById(long id);

    Department? getDepartmentByName(string name);
    
    string? getAllDepartments();
    
    void addDepartment(Department department);
    
    void updateDepartment(Department department);
    
    void deleteDepartment(Department department);
    
}