using Edu.Entity;
namespace Edu.Data
{

    public partial class DTeamUser : GenericRepository<TeamUser>
	{
		EduContext db;
		public DTeamUser(EduContext DbContext)
			: base(DbContext)
		{
			db = DbContext;
		}
	}
}
 