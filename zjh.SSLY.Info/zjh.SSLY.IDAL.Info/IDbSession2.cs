 

using System.Data.SqlClient;
namespace zjh.SSLY.IDAL.Info
{
    public partial interface IDbSession
    { 
 

	
		IActionGroupRepository ActionGroupRepository { get; set; } 
	
		IActionInfoRepository ActionInfoRepository { get; set; } 
	
		IAnalysisKeywordsRepository AnalysisKeywordsRepository { get; set; } 
	
		IBillDeliveryDtlRepository BillDeliveryDtlRepository { get; set; } 
	
		IBillDeliveryHdrRepository BillDeliveryHdrRepository { get; set; } 
	
		IBillGoodsReceiptDtlRepository BillGoodsReceiptDtlRepository { get; set; } 
	
		IBillGoodsReceiptHdrRepository BillGoodsReceiptHdrRepository { get; set; } 
	
		IBillInStockDtlRepository BillInStockDtlRepository { get; set; } 
	
		IBillPurchaseDtlRepository BillPurchaseDtlRepository { get; set; } 
	
		IBillPurchaseHdrRepository BillPurchaseHdrRepository { get; set; } 
	
		IBillRefundGoodsDtlRepository BillRefundGoodsDtlRepository { get; set; } 
	
		IBillRefundGoodsHdrRepository BillRefundGoodsHdrRepository { get; set; } 
	
		IBuyersAccountRepository BuyersAccountRepository { get; set; } 
	
		IDocumentRepository DocumentRepository { get; set; } 
	
		IHotAttributeRepository HotAttributeRepository { get; set; } 
	
		IPage_ProductRepository Page_ProductRepository { get; set; } 
	
		IProAttributeRepository ProAttributeRepository { get; set; } 
	
		IProductRepository ProductRepository { get; set; } 
	
		IProductCategoryRepository ProductCategoryRepository { get; set; } 
	
		IProjectMenuRepository ProjectMenuRepository { get; set; } 
	
		IPvuvRepository PvuvRepository { get; set; } 
	
		IRoleRepository RoleRepository { get; set; } 
	
		IShippingRepository ShippingRepository { get; set; } 
	
		IShippingAreaRepository ShippingAreaRepository { get; set; } 
	
		IShippingCountryRepository ShippingCountryRepository { get; set; } 
	
		IStockViewRepository StockViewRepository { get; set; } 
	
		ISupplierRepository SupplierRepository { get; set; } 
	
		ITbLogisticsCompaniesRepository TbLogisticsCompaniesRepository { get; set; } 
	
		ITbOrderDtlRepository TbOrderDtlRepository { get; set; } 
	
		ITbOrderHdrRepository TbOrderHdrRepository { get; set; } 
	
		ITbStoreRepository TbStoreRepository { get; set; } 
	
		ITbTraderatesRepository TbTraderatesRepository { get; set; } 
	
		IUserInfoRepository UserInfoRepository { get; set; } 
	
		IUserManageRepository UserManageRepository { get; set; } 
	}   
}
   
