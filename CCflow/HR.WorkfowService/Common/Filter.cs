using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.WorkflowService.Common
{
    /// <summary>
    /// 过滤条件类
    /// </summary>
    public class Filter
    {
        private string _relation = "like";
        private string _dataType = "string";
        private string _left = "";
        private string _right = "";
        private string _connect = "AND";

        /// <summary>
        /// 属性名称
        /// </summary>
        public string property
        {
            get;
            set;
        }

        /// <summary>
        /// 属性类型
        /// </summary>
        public string dataType
        {
            get
            {
                return _dataType;
            }
            set
            {
                _dataType = value;
            }
        }

        /// <summary>
        /// 运行符号，如=、like、not like
        /// </summary>
        public string relation
        {
            get
            {
                return _relation;
            }
            set
            {
                _relation = value;
            }
        }

        /// <summary>
        /// 属性值
        /// </summary>
        public string value
        {
            get;
            set;
        }

        /// <summary>
        /// 左则符号，如(、((等
        /// </summary>
        public string left
        {
            get
            {
                return _left;
            }
            set
            {
                _left = value;
            }
        }

        /// <summary>
        /// 右侧符号，如),))等
        /// </summary>
        public string right
        {
            get
            {
                return _right;
            }
            set
            {
                _right = value;
            }
        }

        /// <summary>
        /// 连接符,如 and 、or
        /// </summary>
        public string connect
        {
            get
            {
                return _connect;
            }
            set
            {
                _connect = value;
            }
        }
    }
}
