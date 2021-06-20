using Edu.Entity;
namespace Edu.Data
{

    public partial class DScoreRank : GenericRepository<ScoreRank>
	{
		EduContext db;
		public DScoreRank(EduContext DbContext)
			: base(DbContext)
		{
			db = DbContext;
		}
	}
}
 