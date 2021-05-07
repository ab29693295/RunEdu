using Edu.Entity;
namespace Edu.Data
{

    public partial class DRunPoint : GenericRepository<RunPoint>
	{
		EduContext db;
		public DRunPoint(EduContext DbContext)
			: base(DbContext)
		{
			db = DbContext;
		}
	}
}
 