using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zjh.SSLY.Common.Info;
using zjh.SSLY.IBLL.Info;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.BLL.Info
{
    public partial class ProjectMenuService : BaseService<ProjectMenu>, IProjectMenuService
    {

        public List<ProjectMenuTree> CurrTree;
        public List<ProjectMenuTree> GetCategoryTree()
        {
            List<ProjectMenuTree> TreeList = new List<ProjectMenuTree>();
            TreeList = new List<ProjectMenuTree>();

            CurrTree = CurrentRepository.LoadEntities(u => u.Delete == false).Select(u => new ProjectMenuTree
            {
                Sort = u.Sort,
                Uid = u.Uid,
                FID = u.FID == null ? 0 : u.FID,
                ID = u.ID,
                Node = u.Node,
                Active = u.Active,
                CreateTime = u.CreateTime,
                Delete = u.Delete,
                Link = u.Link,
                iconCls = u.iconCls
            }).ToList();

            var data = CurrTree.Where(u => u.FID == 0).OrderBy(b => b.Sort);
            foreach (ProjectMenuTree tree in data)
            {
                FindChildNode(tree);
                TreeList.Add(tree);
            }
            return TreeList;
        }
        public void FindChildNode(ProjectMenuTree tree)
        {
            tree.children = new List<ProjectMenuTree>();
            var trees = CurrTree.Where(u => u.FID == tree.ID).OrderBy(b => b.Sort);

            foreach (ProjectMenuTree _tree in trees)
            {
                FindChildNode(_tree);
                tree.children.Add(_tree);
            }
        } 
    }
}
