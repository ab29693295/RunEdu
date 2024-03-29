namespace Edu.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Score")]
    public partial class Score
    {
        /// <summary>
        /// 
        /// </summary>
        public Score()
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

        private System.String _UserName;
        /// <summary>
        /// 
        /// </summary>
        public System.String UserName { get { return this._UserName; } set { this._UserName = value; } }

        private System.Int32? _TotalScore;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? TotalScore { get { return this._TotalScore; } set { this._TotalScore = value; } }

        private System.String _TypeName;
        /// <summary>
        /// 
        /// </summary>
        public System.String TypeName { get { return this._TypeName; } set { this._TypeName = value; } }

        private System.DateTime? _CreatDate;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? CreatDate { get { return this._CreatDate; } set { this._CreatDate = value; } }
    }
}