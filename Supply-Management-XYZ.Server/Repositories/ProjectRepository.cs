using Supply_Management_XYZ.Server.Contracts;
using Supply_Management_XYZ.Server.Data;
using Supply_Management_XYZ.Server.Models;

namespace Supply_Management_XYZ.Server.Repositories;

public class ProjectRepository : GeneralRepository<Project>, IProjectRepository
{
    public ProjectRepository(SupplyManagementDbContext context) : base(context)
    {
    }
}
