using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.IBLL.Info
{
    public partial interface IUserInfoService : IBaseService<UserInfo>
    {
        UserInfo Login(LoginUserInfo loginUserInfo);
        bool ClearUserRoles(int uid);
    }
}
