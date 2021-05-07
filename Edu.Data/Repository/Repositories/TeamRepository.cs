using Edu.Entity;
namespace Edu.Data
{

    public partial class DTeam : GenericRepository<Team>
	{
		EduContext db;
		public DTeam(EduContext DbContext)
			: base(DbContext)
		{
			db = DbContext;
		}
	}
}
 