 

using zjh.SSLY.IDAL.Info;
using System.Data.Objects;
namespace zjh.SSLY.DAL.Info
{
    public partial class DbSession : IDbSession
    {
 

	
		private IActionGroupRepository _ActionGroupRepository;

        public IActionGroupRepository ActionGroupRepository
        {
            get
            {
                if (_ActionGroupRepository == null)
                {
                    _ActionGroupRepository = new ActionGroupRepository();
                }
                return _ActionGroupRepository;
            }
            set
            {
                _ActionGroupRepository = value;
            }
        }
	
		private IActionInfoRepository _ActionInfoRepository;

        public IActionInfoRepository ActionInfoRepository
        {
            get
            {
                if (_ActionInfoRepository == null)
                {
                    _ActionInfoRepository = new ActionInfoRepository();
                }
                return _ActionInfoRepository;
            }
            set
            {
                _ActionInfoRepository = value;
            }
        }
	
		private IAnalysisKeywordsRepository _AnalysisKeywordsRepository;

        public IAnalysisKeywordsRepository AnalysisKeywordsRepository
        {
            get
            {
                if (_AnalysisKeywordsRepository == null)
                {
                    _AnalysisKeywordsRepository = new AnalysisKeywordsRepository();
                }
                return _AnalysisKeywordsRepository;
            }
            set
            {
                _AnalysisKeywordsRepository = value;
            }
        }
	
		private IBillDeliveryDtlRepository _BillDeliveryDtlRepository;

        public IBillDeliveryDtlRepository BillDeliveryDtlRepository
        {
            get
            {
                if (_BillDeliveryDtlRepository == null)
                {
                    _BillDeliveryDtlRepository = new BillDeliveryDtlRepository();
                }
                return _BillDeliveryDtlRepository;
            }
            set
            {
                _BillDeliveryDtlRepository = value;
            }
        }
	
		private IBillDeliveryHdrRepository _BillDeliveryHdrRepository;

        public IBillDeliveryHdrRepository BillDeliveryHdrRepository
        {
            get
            {
                if (_BillDeliveryHdrRepository == null)
                {
                    _BillDeliveryHdrRepository = new BillDeliveryHdrRepository();
                }
                return _BillDeliveryHdrRepository;
            }
            set
            {
                _BillDeliveryHdrRepository = value;
            }
        }
	
		private IBillGoodsReceiptDtlRepository _BillGoodsReceiptDtlRepository;

        public IBillGoodsReceiptDtlRepository BillGoodsReceiptDtlRepository
        {
            get
            {
                if (_BillGoodsReceiptDtlRepository == null)
                {
                    _BillGoodsReceiptDtlRepository = new BillGoodsReceiptDtlRepository();
                }
                return _BillGoodsReceiptDtlRepository;
            }
            set
            {
                _BillGoodsReceiptDtlRepository = value;
            }
        }
	
		private IBillGoodsReceiptHdrRepository _BillGoodsReceiptHdrRepository;

        public IBillGoodsReceiptHdrRepository BillGoodsReceiptHdrRepository
        {
            get
            {
                if (_BillGoodsReceiptHdrRepository == null)
                {
                    _BillGoodsReceiptHdrRepository = new BillGoodsReceiptHdrRepository();
                }
                return _BillGoodsReceiptHdrRepository;
            }
            set
            {
                _BillGoodsReceiptHdrRepository = value;
            }
        }
	
		private IBillInStockDtlRepository _BillInStockDtlRepository;

        public IBillInStockDtlRepository BillInStockDtlRepository
        {
            get
            {
                if (_BillInStockDtlRepository == null)
                {
                    _BillInStockDtlRepository = new BillInStockDtlRepository();
                }
                return _BillInStockDtlRepository;
            }
            set
            {
                _BillInStockDtlRepository = value;
            }
        }
	
		private IBillPurchaseDtlRepository _BillPurchaseDtlRepository;

        public IBillPurchaseDtlRepository BillPurchaseDtlRepository
        {
            get
            {
                if (_BillPurchaseDtlRepository == null)
                {
                    _BillPurchaseDtlRepository = new BillPurchaseDtlRepository();
                }
                return _BillPurchaseDtlRepository;
            }
            set
            {
                _BillPurchaseDtlRepository = value;
            }
        }
	
		private IBillPurchaseHdrRepository _BillPurchaseHdrRepository;

        public IBillPurchaseHdrRepository BillPurchaseHdrRepository
        {
            get
            {
                if (_BillPurchaseHdrRepository == null)
                {
                    _BillPurchaseHdrRepository = new BillPurchaseHdrRepository();
                }
                return _BillPurchaseHdrRepository;
            }
            set
            {
                _BillPurchaseHdrRepository = value;
            }
        }
	
		private IBillRefundGoodsDtlRepository _BillRefundGoodsDtlRepository;

        public IBillRefundGoodsDtlRepository BillRefundGoodsDtlRepository
        {
            get
            {
                if (_BillRefundGoodsDtlRepository == null)
                {
                    _BillRefundGoodsDtlRepository = new BillRefundGoodsDtlRepository();
                }
                return _BillRefundGoodsDtlRepository;
            }
            set
            {
                _BillRefundGoodsDtlRepository = value;
            }
        }
	
		private IBillRefundGoodsHdrRepository _BillRefundGoodsHdrRepository;

        public IBillRefundGoodsHdrRepository BillRefundGoodsHdrRepository
        {
            get
            {
                if (_BillRefundGoodsHdrRepository == null)
                {
                    _BillRefundGoodsHdrRepository = new BillRefundGoodsHdrRepository();
                }
                return _BillRefundGoodsHdrRepository;
            }
            set
            {
                _BillRefundGoodsHdrRepository = value;
            }
        }
	
		private IBuyersAccountRepository _BuyersAccountRepository;

        public IBuyersAccountRepository BuyersAccountRepository
        {
            get
            {
                if (_BuyersAccountRepository == null)
                {
                    _BuyersAccountRepository = new BuyersAccountRepository();
                }
                return _BuyersAccountRepository;
            }
            set
            {
                _BuyersAccountRepository = value;
            }
        }
	
		private IDocumentRepository _DocumentRepository;

        public IDocumentRepository DocumentRepository
        {
            get
            {
                if (_DocumentRepository == null)
                {
                    _DocumentRepository = new DocumentRepository();
                }
                return _DocumentRepository;
            }
            set
            {
                _DocumentRepository = value;
            }
        }
	
		private IHotAttributeRepository _HotAttributeRepository;

        public IHotAttributeRepository HotAttributeRepository
        {
            get
            {
                if (_HotAttributeRepository == null)
                {
                    _HotAttributeRepository = new HotAttributeRepository();
                }
                return _HotAttributeRepository;
            }
            set
            {
                _HotAttributeRepository = value;
            }
        }
	
		private IPage_ProductRepository _Page_ProductRepository;

        public IPage_ProductRepository Page_ProductRepository
        {
            get
            {
                if (_Page_ProductRepository == null)
                {
                    _Page_ProductRepository = new Page_ProductRepository();
                }
                return _Page_ProductRepository;
            }
            set
            {
                _Page_ProductRepository = value;
            }
        }
	
		private IProAttributeRepository _ProAttributeRepository;

        public IProAttributeRepository ProAttributeRepository
        {
            get
            {
                if (_ProAttributeRepository == null)
                {
                    _ProAttributeRepository = new ProAttributeRepository();
                }
                return _ProAttributeRepository;
            }
            set
            {
                _ProAttributeRepository = value;
            }
        }
	
		private IProductRepository _ProductRepository;

        public IProductRepository ProductRepository
        {
            get
            {
                if (_ProductRepository == null)
                {
                    _ProductRepository = new ProductRepository();
                }
                return _ProductRepository;
            }
            set
            {
                _ProductRepository = value;
            }
        }
	
		private IProductCategoryRepository _ProductCategoryRepository;

        public IProductCategoryRepository ProductCategoryRepository
        {
            get
            {
                if (_ProductCategoryRepository == null)
                {
                    _ProductCategoryRepository = new ProductCategoryRepository();
                }
                return _ProductCategoryRepository;
            }
            set
            {
                _ProductCategoryRepository = value;
            }
        }
	
		private IProjectMenuRepository _ProjectMenuRepository;

        public IProjectMenuRepository ProjectMenuRepository
        {
            get
            {
                if (_ProjectMenuRepository == null)
                {
                    _ProjectMenuRepository = new ProjectMenuRepository();
                }
                return _ProjectMenuRepository;
            }
            set
            {
                _ProjectMenuRepository = value;
            }
        }
	
		private IPvuvRepository _PvuvRepository;

        public IPvuvRepository PvuvRepository
        {
            get
            {
                if (_PvuvRepository == null)
                {
                    _PvuvRepository = new PvuvRepository();
                }
                return _PvuvRepository;
            }
            set
            {
                _PvuvRepository = value;
            }
        }
	
		private IRoleRepository _RoleRepository;

        public IRoleRepository RoleRepository
        {
            get
            {
                if (_RoleRepository == null)
                {
                    _RoleRepository = new RoleRepository();
                }
                return _RoleRepository;
            }
            set
            {
                _RoleRepository = value;
            }
        }
	
		private IShippingRepository _ShippingRepository;

        public IShippingRepository ShippingRepository
        {
            get
            {
                if (_ShippingRepository == null)
                {
                    _ShippingRepository = new ShippingRepository();
                }
                return _ShippingRepository;
            }
            set
            {
                _ShippingRepository = value;
            }
        }
	
		private IShippingAreaRepository _ShippingAreaRepository;

        public IShippingAreaRepository ShippingAreaRepository
        {
            get
            {
                if (_ShippingAreaRepository == null)
                {
                    _ShippingAreaRepository = new ShippingAreaRepository();
                }
                return _ShippingAreaRepository;
            }
            set
            {
                _ShippingAreaRepository = value;
            }
        }
	
		private IShippingCountryRepository _ShippingCountryRepository;

        public IShippingCountryRepository ShippingCountryRepository
        {
            get
            {
                if (_ShippingCountryRepository == null)
                {
                    _ShippingCountryRepository = new ShippingCountryRepository();
                }
                return _ShippingCountryRepository;
            }
            set
            {
                _ShippingCountryRepository = value;
            }
        }
	
		private IStockViewRepository _StockViewRepository;

        public IStockViewRepository StockViewRepository
        {
            get
            {
                if (_StockViewRepository == null)
                {
                    _StockViewRepository = new StockViewRepository();
                }
                return _StockViewRepository;
            }
            set
            {
                _StockViewRepository = value;
            }
        }
	
		private ISupplierRepository _SupplierRepository;

        public ISupplierRepository SupplierRepository
        {
            get
            {
                if (_SupplierRepository == null)
                {
                    _SupplierRepository = new SupplierRepository();
                }
                return _SupplierRepository;
            }
            set
            {
                _SupplierRepository = value;
            }
        }
	
		private ITbLogisticsCompaniesRepository _TbLogisticsCompaniesRepository;

        public ITbLogisticsCompaniesRepository TbLogisticsCompaniesRepository
        {
            get
            {
                if (_TbLogisticsCompaniesRepository == null)
                {
                    _TbLogisticsCompaniesRepository = new TbLogisticsCompaniesRepository();
                }
                return _TbLogisticsCompaniesRepository;
            }
            set
            {
                _TbLogisticsCompaniesRepository = value;
            }
        }
	
		private ITbOrderDtlRepository _TbOrderDtlRepository;

        public ITbOrderDtlRepository TbOrderDtlRepository
        {
            get
            {
                if (_TbOrderDtlRepository == null)
                {
                    _TbOrderDtlRepository = new TbOrderDtlRepository();
                }
                return _TbOrderDtlRepository;
            }
            set
            {
                _TbOrderDtlRepository = value;
            }
        }
	
		private ITbOrderHdrRepository _TbOrderHdrRepository;

        public ITbOrderHdrRepository TbOrderHdrRepository
        {
            get
            {
                if (_TbOrderHdrRepository == null)
                {
                    _TbOrderHdrRepository = new TbOrderHdrRepository();
                }
                return _TbOrderHdrRepository;
            }
            set
            {
                _TbOrderHdrRepository = value;
            }
        }
	
		private ITbStoreRepository _TbStoreRepository;

        public ITbStoreRepository TbStoreRepository
        {
            get
            {
                if (_TbStoreRepository == null)
                {
                    _TbStoreRepository = new TbStoreRepository();
                }
                return _TbStoreRepository;
            }
            set
            {
                _TbStoreRepository = value;
            }
        }
	
		private ITbTraderatesRepository _TbTraderatesRepository;

        public ITbTraderatesRepository TbTraderatesRepository
        {
            get
            {
                if (_TbTraderatesRepository == null)
                {
                    _TbTraderatesRepository = new TbTraderatesRepository();
                }
                return _TbTraderatesRepository;
            }
            set
            {
                _TbTraderatesRepository = value;
            }
        }
	
		private IUserInfoRepository _UserInfoRepository;

        public IUserInfoRepository UserInfoRepository
        {
            get
            {
                if (_UserInfoRepository == null)
                {
                    _UserInfoRepository = new UserInfoRepository();
                }
                return _UserInfoRepository;
            }
            set
            {
                _UserInfoRepository = value;
            }
        }
	
		private IUserManageRepository _UserManageRepository;

        public IUserManageRepository UserManageRepository
        {
            get
            {
                if (_UserManageRepository == null)
                {
                    _UserManageRepository = new UserManageRepository();
                }
                return _UserManageRepository;
            }
            set
            {
                _UserManageRepository = value;
            }
        }
	}
	
}