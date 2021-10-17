
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.IBLL.Info
{
    public partial interface IActionInfoService : IBaseService<ActionInfo>
    {
        bool IsActionInfoIsOk(ActionInfo actionInfo, UserInfo CurrentUserInfo);

        /// <summary>
        /// 清空角色权限
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        bool ClearRoleAcion(int roleID);
    }

}
