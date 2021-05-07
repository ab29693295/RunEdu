using Edu.Entity;
namespace Edu.Data
{

    public partial class DRunning : GenericRepository<Running>
	{
		EduContext db;
		public DRunning(EduContext DbContext)
			: base(DbContext)
		{
			db = DbContext;
		}
	}
}
 