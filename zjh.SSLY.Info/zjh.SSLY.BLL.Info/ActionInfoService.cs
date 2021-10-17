using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zjh.SSLY.IBLL.Info;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.BLL.Info
{
    public partial class ActionInfoService : BaseService<ActionInfo>, IActionInfoService
    {
        public bool IsActionInfoIsOk(ActionInfo actionInfo, UserInfo CurrentUserInfo)
        {
            if (actionInfo == null || CurrentUserInfo == null)
            {
                return false;
            }
            IUserInfoService bllUser = new UserInfoService();
            var userInfo = bllUser.LoadEntities(u => u.UCode == CurrentUserInfo.UCode).FirstOrDefault();
            return userInfo.Role.Where(u => u.ActionInfo.Contains(actionInfo)).Count() > 0;
        }
        public bool ClearRoleAcion(int roleID)
        {
            IRoleService roleSerivce = new RoleService();
            var role = roleSerivce.LoadEntities(r => r.ID == roleID).FirstOrDefault();
            if (role != null)
            {
                role.ActionInfo.Clear();
                return roleSerivce.UpdateEntity(role);
            }
            return false;
        }
    }
}
