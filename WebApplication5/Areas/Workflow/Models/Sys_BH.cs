using Lab.Framework;
using System;
using System.Linq;

namespace WebApplication5.Areas.Workflow.Models
{
    /// <summary>
    /// 编号
    /// </summary>
    public partial class Sys_BH
    {
        public static object LockObject { get; set; }

        /// <summary>
        /// 根据编号ID获取下一流水编号
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string GetBH(string ID)
        {
            var entity = NH.Session.Load<Sys_BH>(ID);
            if (entity == null)
            {
                throw new Exception("不存在该编号");
            }
            switch (entity.RestType)
            {
                case 2: entity.SeriesNumber = entity.LastDate.Date == DateTime.Now.Date ? entity.SeriesNumber + 1 : 1;break;
                case 1:entity.SeriesNumber= entity.LastDate.Year==DateTime.Now.Year&& entity.LastDate.Month == DateTime.Now.Month? entity.SeriesNumber + 1 : 1; break;
                case 0:entity.SeriesNumber = entity.LastDate.Year == DateTime.Now.Year ? entity.SeriesNumber + 1 : 1; break;
                default:throw new Exception("找不到相应的编号重置方式");
            }
            entity.LastDate = DateTime.Now;
            entity.SaveOrUpdate();

            var str = entity.Template;
            str = str.Replace("{年份}",DateTime.Now.Year.ToString()).Replace("{月份}",DateTime.Now.Month.ToString("00")).Replace("{日期}", DateTime.Now.Day.ToString("00"));
            str = str.Replace("{流水号}",entity.SeriesNumber.ToString().PadLeft((int)entity.NumberLength,'0'));
            return str;
        }
    }
}

