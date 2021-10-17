 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zjh.SSLY.IBLL.Info;
using zjh.SSLY.DAL.Info;
using zjh.SSLY.IDAL.Info;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.BLL.Info
{ 
	
	public partial class ActionGroupService :BaseService<ActionGroup>, IActionGroupService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.ActionGroupRepository;
        }
	}  
	
	public partial class ActionInfoService :BaseService<ActionInfo>, IActionInfoService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.ActionInfoRepository;
        }
	}  
	
 
	
	public partial class BillDeliveryDtlService :BaseService<BillDeliveryDtl>, IBillDeliveryDtlService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.BillDeliveryDtlRepository;
        }
	}  
	
	public partial class BillDeliveryHdrService :BaseService<BillDeliveryHdr>, IBillDeliveryHdrService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.BillDeliveryHdrRepository;
        }
	}  
	
	public partial class BillGoodsReceiptDtlService :BaseService<BillGoodsReceiptDtl>, IBillGoodsReceiptDtlService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.BillGoodsReceiptDtlRepository;
        }
	}  
	
	public partial class BillGoodsReceiptHdrService :BaseService<BillGoodsReceiptHdr>, IBillGoodsReceiptHdrService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.BillGoodsReceiptHdrRepository;
        }
	}  
	
	public partial class BillInStockDtlService :BaseService<BillInStockDtl>, IBillInStockDtlService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.BillInStockDtlRepository;
        }
	}  
	
	public partial class BillPurchaseDtlService :BaseService<BillPurchaseDtl>, IBillPurchaseDtlService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.BillPurchaseDtlRepository;
        }
	}  
	
	public partial class BillPurchaseHdrService :BaseService<BillPurchaseHdr>, IBillPurchaseHdrService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.BillPurchaseHdrRepository;
        }
	}  
	
	public partial class BillRefundGoodsDtlService :BaseService<BillRefundGoodsDtl>, IBillRefundGoodsDtlService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.BillRefundGoodsDtlRepository;
        }
	}  
	
	public partial class BillRefundGoodsHdrService :BaseService<BillRefundGoodsHdr>, IBillRefundGoodsHdrService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.BillRefundGoodsHdrRepository;
        }
	}  
	
	public partial class BuyersAccountService :BaseService<BuyersAccount>, IBuyersAccountService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.BuyersAccountRepository;
        }
	}  
	
	public partial class DocumentService :BaseService<Document>, IDocumentService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.DocumentRepository;
        }
	}  
	
	public partial class HotAttributeService :BaseService<HotAttribute>, IHotAttributeService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.HotAttributeRepository;
        }
	}  
	
	public partial class Page_ProductService :BaseService<Page_Product>, IPage_ProductService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.Page_ProductRepository;
        }
	}  
	
	public partial class ProAttributeService :BaseService<ProAttribute>, IProAttributeService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.ProAttributeRepository;
        }
	}  
	
	public partial class ProductService :BaseService<Product>, IProductService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.ProductRepository;
        }
	}  
	
	public partial class ProductCategoryService :BaseService<ProductCategory>, IProductCategoryService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.ProductCategoryRepository;
        }
	}  
	
	public partial class ProjectMenuService :BaseService<ProjectMenu>, IProjectMenuService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.ProjectMenuRepository;
        }
	}  
	
	public partial class PvuvService :BaseService<Pvuv>, IPvuvService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.PvuvRepository;
        }
	}  
	
	public partial class RoleService :BaseService<Role>, IRoleService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.RoleRepository;
        }
	}  
	
	public partial class ShippingService :BaseService<Shipping>, IShippingService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.ShippingRepository;
        }
	}  
	
	public partial class ShippingAreaService :BaseService<ShippingArea>, IShippingAreaService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.ShippingAreaRepository;
        }
	}  
	
	public partial class ShippingCountryService :BaseService<ShippingCountry>, IShippingCountryService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.ShippingCountryRepository;
        }
	}  
	
	public partial class StockViewService :BaseService<StockView>, IStockViewService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.StockViewRepository;
        }
	}  
	
	public partial class SupplierService :BaseService<Supplier>, ISupplierService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.SupplierRepository;
        }
	}  
	
	public partial class TbLogisticsCompaniesService :BaseService<TbLogisticsCompanies>, ITbLogisticsCompaniesService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.TbLogisticsCompaniesRepository;
        }
	}  
	
	public partial class TbOrderDtlService :BaseService<TbOrderDtl>, ITbOrderDtlService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.TbOrderDtlRepository;
        }
	}  
	
	public partial class TbOrderHdrService :BaseService<TbOrderHdr>, ITbOrderHdrService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.TbOrderHdrRepository;
        }
	}  
	
	public partial class TbStoreService :BaseService<TbStore>, ITbStoreService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.TbStoreRepository;
        }
	}  
	
	public partial class TbTraderatesService :BaseService<TbTraderates>, ITbTraderatesService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.TbTraderatesRepository;
        }
	}  
	
	public partial class UserInfoService :BaseService<UserInfo>, IUserInfoService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.UserInfoRepository;
        }
	}  
	
	public partial class UserManageService :BaseService<UserManage>, IUserManageService
    {
		public override void SetCurrentRepository()
        {
            this.CurrentRepository = this.dbSession.UserManageRepository;
        }
	}  
	
}