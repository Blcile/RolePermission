using RolePermission.Model;
using RolePermission.Model.SearchParam;
using System.Collections.Generic;
using System.Linq;

namespace RolePermission.IBLL
{
    public partial interface ISMFIELDService
    {
        /// <summary>
        /// 多条件搜索数据字典信息
        /// </summary>
        /// <param name="fieldParam">数据字典查询参数实体</param>
        /// <returns></returns>
        IQueryable<SMFIELD> LoadSearchEntities(FieldParam fieldParam);
        /// <summary>
        /// 获取自连接树形列表数据
        /// </summary>
        /// <returns>自定义的树形结构</returns>
        IQueryable<SMFIELD> GetAllMetadata(int id);
        #region MyRegion
        /// <summary>
        /// 获取下拉框的数据
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="colum">列明</param>
        /// <param name="parentId">父节点编号</param>
        /// <returns></returns>
        List<SMFIELD> GetSysField(string table, string colum, string parentMyTexts);
        /// <summary>
        /// 获取下拉框的数据
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="colum">列明</param>
        /// <returns></returns>
        List<SMFIELD> GetSysField(string table, string colum);
        /// <summary>
        /// 根据父亲的Id，获取数据字典
        /// </summary>
        /// <param name="id">父亲节点的主键</param>
        /// <returns></returns>
        List<SMFIELD> GetSysFieldByParentId(int id);
        /// <summary>
        /// 根据父亲的Id，获取数据字典
        /// </summary>
        /// <param name="id">父亲节点的主键</param>
        /// <returns></returns>
        List<SMFIELD> GetSysFieldByParent(string id, string parentid, string value);
        /// <summary>
        /// 根据主键id，获取数据字典的展示字段
        /// </summary>
        /// <param name="id">父亲节点的主键</param>
        /// <returns></returns>
        string GetMyTextsById(int id);
        #endregion
    }
}
