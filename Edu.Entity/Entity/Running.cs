namespace Edu.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Running")]
    public partial class Running
    {
        /// <summary>
        /// 
        /// </summary>
        public Running()
        {
        }

        private System.Int32 _ID;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 ID { get { return this._ID; } set { this._ID = value; } }

        private System.Int32 _UserID;
        /// <summary>
        /// 用户ID
        /// </summary>
        public System.Int32 UserID { get { return this._UserID; } set { this._UserID = value; } }

        private System.String _TeamID;
        /// <summary>
        /// 团队ID
        /// </summary>
        public System.String TeamID { get { return this._TeamID; } set { this._TeamID = value; } }

        private System.String _Totalkm;
        /// <summary>
        /// 总公里数
        /// </summary>
        public System.String Totalkm { get { return this._Totalkm; } set { this._Totalkm = value; } }

        private System.String _TotalHot;
        /// <summary>
        /// 总热量
        /// </summary>
        public System.String TotalHot { get { return this._TotalHot; } set { this._TotalHot = value; } }

        private System.String _TotalTime;
        /// <summary>
        /// 总时间
        /// </summary>
        public System.String TotalTime { get { return this._TotalTime; } set { this._TotalTime = value; } }

        private System.String _TotalScore;
        /// <summary>
        /// 总积分
        /// </summary>
        public System.String TotalScore { get { return this._TotalScore; } set { this._TotalScore = value; } }

        private System.DateTime? _CreateDate;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? CreateDate { get { return this._CreateDate; } set { this._CreateDate = value; } }
    }
}
