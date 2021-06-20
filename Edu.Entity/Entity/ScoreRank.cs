namespace Edu.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ScoreRank")]
    public partial class ScoreRank
    {
        /// <summary>
        /// 
        /// </summary>
        public ScoreRank()
        {
        }

        private System.Int32 _ID;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 ID { get { return this._ID; } set { this._ID = value; } }

        private System.String _WXUserID;
        /// <summary>
        /// 
        /// </summary>
        public System.String WXUserID { get { return this._WXUserID; } set { this._WXUserID = value; } }

        private System.Int32? _RunTypeID;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? RunTypeID { get { return this._RunTypeID; } set { this._RunTypeID = value; } }

        private System.String _RunTypeName;
        /// <summary>
        /// 
        /// </summary>
        public System.String RunTypeName { get { return this._RunTypeName; } set { this._RunTypeName = value; } }

        private System.Int32? _Score;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? Score { get { return this._Score; } set { this._Score = value; } }

        private System.DateTime? _CreateDate;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? CreateDate { get { return this._CreateDate; } set { this._CreateDate = value; } }
    }
}