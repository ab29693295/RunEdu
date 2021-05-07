namespace Edu.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TeamUser")]
    public partial class TeamUser
    {
        /// <summary>
        /// 
        /// </summary>
        public TeamUser()
        {
        }

        private System.Int32 _ID;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 ID { get { return this._ID; } set { this._ID = value; } }

        private System.Int32? _TeamID;
        /// <summary>
        /// �Ŷ�ID
        /// </summary>
        public System.Int32? TeamID { get { return this._TeamID; } set { this._TeamID = value; } }

        private System.String _TeamName;
        /// <summary>
        /// �Ŷ�����
        /// </summary>
        public System.String TeamName { get { return this._TeamName; } set { this._TeamName = value; } }

        private System.Int32? _UserID;
        /// <summary>
        /// �û�ID
        /// </summary>
        public System.Int32? UserID { get { return this._UserID; } set { this._UserID = value; } }

        private System.String _UserName;
        /// <summary>
        /// �û�����
        /// </summary>
        public System.String UserName { get { return this._UserName; } set { this._UserName = value; } }

        private System.Decimal? _TotalKM;
        /// <summary>
        /// �����
        /// </summary>
        public System.Decimal? TotalKM { get { return this._TotalKM; } set { this._TotalKM = value; } }

        private System.Int32? _TotalScore;
        /// <summary>
        /// �ܻ���
        /// </summary>
        public System.Int32? TotalScore { get { return this._TotalScore; } set { this._TotalScore = value; } }

        private System.Int32? _Status;
        /// <summary>
        /// �Ƿ����� 1��ʾ����
        /// </summary>
        public System.Int32? Status { get { return this._Status; } set { this._Status = value; } }

        private System.DateTime? _CreatDate;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public System.DateTime? CreatDate { get { return this._CreatDate; } set { this._CreatDate = value; } }
    }
}