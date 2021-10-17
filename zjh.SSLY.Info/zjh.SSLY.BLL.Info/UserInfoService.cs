using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zjh.SSLY.IBLL.Info;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.BLL.Info
{
    public partial class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {
        public UserInfo Login(LoginUserInfo loginUserInfo)
        {
            var temp = this.dbSession.UserInfoRepository.LoadEntities(
                u => u.UCode == loginUserInfo.UCode && u.UserPwd == loginUserInfo.Pwd).FirstOrDefault();

            return temp;
        }

        public bool ClearUserRoles(int uid)
        { 
            var temp = CurrentRepository.LoadEntities(U => U.ID == uid).FirstOrDefault();
            if (temp != null)
            {
                temp.Role.Clear();
                return CurrentRepository.UpdateEntity(temp);
            } 
            return false; 
        }



    }
}
