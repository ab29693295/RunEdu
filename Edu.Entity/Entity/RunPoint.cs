namespace Edu.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RunPoint")]
    public partial class RunPoint
    {
        /// <summary>
        /// 
        /// </summary>
        public RunPoint()
        {
        }

        private System.Int32 _ID;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 ID { get { return this._ID; } set { this._ID = value; } }

        private System.String _PointName;
        /// <summary>
        /// 名称
        /// </summary>
        public System.String PointName { get { return this._PointName; } set { this._PointName = value; } }

        private System.String _PointX;
        /// <summary>
        /// X坐标
        /// </summary>
        public System.String PointX { get { return this._PointX; } set { this._PointX = value; } }

        private System.String _PointY;
        /// <summary>
        /// Y坐标
        /// </summary>
        public System.String PointY { get { return this._PointY; } set { this._PointY = value; } }

        private System.Int32? _Score;
        /// <summary>
        /// 分数
        /// </summary>
        public System.Int32? Score { get { return this._Score; } set { this._Score = value; } }

        private System.Int32? _TeamID;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? TeamID { get { return this._TeamID; } set { this._TeamID = value; } }

        private System.Int32? _Status;
        /// <summary>
        /// 状态
        /// </summary>
        public System.Int32? Status { get { return this._Status; } set { this._Status = value; } }

        private System.DateTime? _CreatDate;
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime? CreatDate { get { return this._CreatDate; } set { this._CreatDate = value; } }
    }
}