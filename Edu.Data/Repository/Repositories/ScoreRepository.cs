using Edu.Entity;
namespace Edu.Data
{

    public partial class DScore : GenericRepository<Score>
	{
		EduContext db;
		public DScore(EduContext DbContext)
			: base(DbContext)
		{
			db = DbContext;
		}
	}
}
 