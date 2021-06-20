
using Edu.Data;
using Edu.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Edu.Service
{
    public partial class UnitOfWork : IDisposable
    {
	
		private DEduContext _DEduContext;
      
        public DEduContext DEduContext
        {
            get
            {
                if (this._DEduContext == null)
                {
                    this._DEduContext = new DEduContext(context);
                }
                return _DEduContext;
            }
        }
        private DLogInfo _DLogInfo;

        public DLogInfo DLogInfo
        {
            get
            {
                if (this._DLogInfo == null)
                {
                    this._DLogInfo = new DLogInfo(context);
                }
                return _DLogInfo;
            }
        }
        private DRunning _DRunning;

        public DRunning DRunning
        {
            get
            {
                if (this._DRunning == null)
                {
                    this._DRunning = new DRunning(context);
                }
                return _DRunning;
            }
        }

        private DRunPoint _DRunPoint;

        public DRunPoint DRunPoint
        {
            get
            {
                if (this._DRunPoint == null)
                {
                    this._DRunPoint = new DRunPoint(context);
                }
                return _DRunPoint;
            }
        }

        private DScore _DScore;

        public DScore DScore
        {
            get
            {
                if (this._DScore == null)
                {
                    this._DScore = new DScore(context);
                }
                return _DScore;
            }
        }

        private DScoreRank _DScoreRank;

        public DScoreRank DScoreRank
        {
            get
            {
                if (this._DScoreRank == null)
                {
                    this._DScoreRank = new DScoreRank(context);
                }
                return _DScoreRank;
            }
        }

        private DTeam _DTeam;
      
        public DTeam DTeam
        {
            get
            {
                if (this._DTeam == null)
                {
                    this._DTeam = new DTeam(context);
                }
                return _DTeam;
            }
        }

		
		private DTeamUser _DTeamUser;
      
        public DTeamUser DTeamUser
        {
            get
            {
                if (this._DTeamUser == null)
                {
                    this._DTeamUser = new DTeamUser(context);
                }
                return _DTeamUser;
            }
        }

		
	

		
		private DUserInfo _DUserInfo;
      
        public DUserInfo DUserInfo
        {
            get
            {
                if (this._DUserInfo == null)
                {
                    this._DUserInfo = new DUserInfo(context);
                }
                return _DUserInfo;
            }
        }

	
    }
}