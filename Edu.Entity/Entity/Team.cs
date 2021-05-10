
namespace Edu.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Team")]
    public partial class Team
    {


        /// <summary>
        /// 
        /// </summary>
        public Team()
        {
        }

        private System.Int32 _ID;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 ID { get { return this._ID; } set { this._ID = value; } }

        private System.String _TeamName;
        /// <summary>
        /// 团队名称
        /// </summary>
        public System.String TeamName { get { return this._TeamName; } set { this._TeamName = value; } }

        private System.String _TeamNum;
        /// <summary>
        /// 团队编号
        /// </summary>
        public System.String TeamNum { get { return this._TeamNum; } set { this._TeamNum = value; } }

        private System.String _TeamDes;
        /// <summary>
        /// 团队描述
        /// </summary>
        public System.String TeamDes { get { return this._TeamDes; } set { this._TeamDes = value; } }

        private System.Int32? _MaxCount;
        /// <summary>
        /// 团队最大人数
        /// </summary>
        public System.Int32? MaxCount { get { return this._MaxCount; } set { this._MaxCount = value; } }

        private System.DateTime? _CreatDate;
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime? CreatDate { get { return this._CreatDate; } set { this._CreatDate = value; } }

        private System.Int32? _Creator;
        /// <summary>
        /// 创建人用户ID
        /// </summary>
        public System.Int32? Creator { get { return this._Creator; } set { this._Creator = value; } }
    }
}

