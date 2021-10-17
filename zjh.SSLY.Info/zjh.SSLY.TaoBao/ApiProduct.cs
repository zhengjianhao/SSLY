using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;

namespace zjh.SSLY.TaoBao
{
    //商品API
    public class ApiProduct
    {
        private ITopClient _Client;
        public ITopClient Client
        {
            get
            {
                if (_Client == null)
                {
                    return new DefaultTopClient(url, appkey, appsecret);
                }
                return _Client;
            }
        }


        private string url = "http://gw.api.taobao.com/router/rest";
        private string appkey = "21801462";
        private string appsecret = "6f3a279e4eed2a0830749c6b867220a7";
        private string sessionKey = string.Empty;

        #region API列表
        //public void taobao.aftersale.get 收费查询用户售后服务模板

        //public void taobao.item.add 免费添加一个商品

        //public void taobao.item.anchor.get 收费获取可用宝贝描述规范化模块

        //public void taobao.item.barcode.update 免费更新商品条形码信息

        //public void taobao.item.bseller.add 免费助理发布商城商品

        //public void taobao.item.cseller.add 免费助理发布集市商品

        //public void taobao.item.cspu.move 免费达尔文商品老数据自动挂接

        //public void taobao.item.delete 免费删除单条商品

        //public void taobao.item.ebook.serial.add 免费添加一个网络原创电子书商品

        //public void taobao.item.ebook.serial.update 免费更新连载电子书

        //public void taobao.item.get 收费得到单个商品信息

        //public void taobao.item.img.delete 免费删除商品图片

        //public void taobao.item.img.upload 免费添加商品图片

        //public void taobao.item.joint.img 免费商品关联子图

        //public void taobao.item.joint.propimg 免费商品关联属性图

        //public void taobao.item.price.update  免费更新商品价格

        //public void taobao.item.propimg.delete 免费删除属性图片

        //public void taobao.item.propimg.upload 免费添加或修改属性图片

        //public void taobao.item.quantity.update 免费宝贝/SKU库存修改

        //public void taobao.item.recommend.add 免费橱窗推荐一个商品

        //public void taobao.item.recommend.delete 免费取消橱窗推荐一个商品

        //public void taobao.item.sku.add 免费添加SKU

        //public void taobao.item.sku.delete 免费删除SKU

        //public void taobao.item.sku.get 收费获取SKU

        //public void taobao.item.sku.price.update  免费更新商品SKU的价格

        //public void taobao.item.sku.update 免费更新SKU信息

        //public void taobao.item.skus.get 收费根据商品ID列表获取SKU信息

        //public void taobao.item.templates.get 收费获取用户宝贝详情页模板名称

        //public void taobao.item.update 免费更新商品信息

        //public void taobao.item.update.delisting 免费商品下架

        //public void taobao.item.update.listing 免费一口价商品上架

        //public void taobao.items.custom.get 收费根据外部ID取商品

        //public void taobao.items.inventory.get 收费得到当前会话用户库存中的商品列表

        //public void taobao.items.list.get 收费批量获取商品信息

        //public void taobao.items.onsale.get 收费获取当前会话用户出售中的商品列表

        //public void taobao.product.add 免费上传一个产品，不包括产品非主图和属性图片

        //public void taobao.product.get 收费获取一个产品的信息

        //public void taobao.product.img.delete 免费删除产品非主图

        //public void taobao.product.img.upload 免费上传单张产品非主图，如果需要传多张，可调多次

        //public void taobao.product.propimg.delete 免费删除产品属性图

        //public void taobao.product.propimg.upload 免费上传单张产品属性图片，如果需要传多张，可调多次

        //public void taobao.product.update 免费修改一个产品，可以修改主图，不能修改子图片

        //public void taobao.products.search 收费搜索产品信息

        //public void taobao.skus.custom.get 收费根据外部ID取商品SKU

        //public void taobao.skus.quantity.update 免费SKU库存修改

        //public void taobao.ticket.item.add 免费发布门票宝贝

        //public void taobao.ticket.item.get 免费获取新门票类目商品信息

        //public void taobao.ticket.item.update 免费编辑新门票类目商品

        //public void taobao.ticket.items.get 免费批量获取新门票类目商品信息

        //public void taobao.ump.promotion.get 收费商品优惠详情查询

        //public void tmall.brandcat.control.get 收费获取品牌类目的控制信息

        //public void tmall.brandcat.metadata.get 免费类目品牌下达尔文数据读取接口

        //public void tmall.brandcat.propinput.get 收费判断类目属性是否为可输入

        //public void tmall.brandcat.salespro.get 收费获取管控品牌类目的销售信息

        //public void tmall.brandcat.suiteconf.get 免费套装配置获取

        //public void tmall.item.desc.modules.get 收费商品描述模块信息获取

        //public void tmall.product.books.add 免费图书类目导入

        //public void tmall.product.spec.add 免费添加产品规格

        //public void tmall.product.spec.get 收费根据产品规格的Id号获取当个的规格信息

        //public void tmall.product.spec.pic.upload 免费上传产品规格认证图片

        //public void tmall.product.specs.get 收费获取产品的规格信息

        //public void tmall.product.specs.ticket.get 收费产品规格审核信息获取接口

        //public void tmall.product.suitespecs.get 免费套装产品，关键规格获取

        //public void tmall.product.template.get 免费产品接口 
        #endregion


        /// <summary>
        /// 不是所有API都需要sessionKey
        /// </summary>
        /// <param name="sessionKey"></param>
        public ApiProduct(string sessionKey = "")
        {
            this.sessionKey = sessionKey;
        }

        //taobao.products.search 收费 
        /// <summary>
        /// 搜索产品信息taobao.products.search 收费 不需要sessionKey
        /// </summary>
        /// <param name="q">搜索的关键词是用来搜索产品的title.　注:q,cid和props至少传入一个</param>
        /// <param name="cid">	 商品类目ID.调用taobao.itemcats.get获取.</param>
        /// <param name="props">属性,属性值的组合.格式:pid:vid;pid:vid;调用taobao.itemprops.get获取类目属性pid ,再用taobao.itempropvalues.get取得vid.</param>
        /// <param name="status">想要获取的产品的状态列表，支持多个状态并列获取，多个状态之间用","分隔，最多同时指定5种状态。例如，只获取小二确认的spu传入"3",只要商家确认的传入"0"，既要小二确认又要商家确认的传入"0,3"。目前只支持者两种类型的状态搜索，输入其他状态无效。</param>
        /// <param name="page_no">页码.传入值为1代表第一页,传入值为2代表第二页,依此类推.默认返回的数据是从第一页开始.</param>
        /// <param name="page_size">每页条数.每页返回最多返回100条,默认值为40.</param>
        /// <param name="vertical_market">传入值为：3表示3C表示3C垂直市场产品，4表示鞋城垂直市场产品，8表示网游垂直市场产品。一次只能指定一种垂直市场类型支持最小值为：0</param>
        /// <param name="customer_props">用户自定义关键属性,结构：pid1:value1;pid2:value2，如果有型号，系列等子属性用: 隔开 例如：“20000:优衣库:型号:001;632501:1234”，表示“品牌:优衣库:型号:001;货号:1234”</param>
        /// <param name="market_id">市场ID，1为取C2C市场的产品信息， 2为取B2C市场的产品信息。 不填写此值则默认取C2C的产品信息。</param>
        /// <param name="suite_items_str">按关联产品规格specs搜索套装产品</param>
        /// <param name="barcode_str">按条码搜索产品信息,多个逗号隔开，不支持条码为全零的方式</param>
        public ProductsSearchResponse search(string q, string cid, string props, string status, string page_no, string page_size, string vertical_market, string customer_props, string market_id, string suite_items_str, string barcode_str)
        {
            ITopClient client = new DefaultTopClient(url, appkey, appsecret);
            ProductsSearchRequest req = new ProductsSearchRequest();
            req.Fields = "name,binds,sale_props,price,desc,pic_url,modified,product_prop_imgs,status,level,pic_path,rate_num,sale_num,shop_price,standard_price,vertical_market,customer_props,property_alias,product_id,outer_id,created,tsc,cid,cat_name,props,props_str,binds_str,sale_props_str,collect_num,product_imgs,product_extra_infos,sell_pt,cspu_feature,template_id,commodity_id,is_suite_effective,suite_items_str,barcode_str";
            #region 参数赋值

            if (!string.IsNullOrEmpty(q))
            {
                req.Q = q;
            }
            if (!string.IsNullOrEmpty(cid))
            {
                req.Cid = long.Parse(cid);
            }
            if (!string.IsNullOrEmpty(props))
            {
                req.Props = props;
            }
            if (!string.IsNullOrEmpty(status))
            {
                req.Status = status;
            }
            if (!string.IsNullOrEmpty(page_no))
            {
                req.PageNo = long.Parse(page_no);
            }
            if (!string.IsNullOrEmpty(page_size))
            {
                req.PageSize = long.Parse(page_size);
            }
            if (!string.IsNullOrEmpty(vertical_market))
            {
                req.VerticalMarket = long.Parse(vertical_market);
            }
            if (!string.IsNullOrEmpty(customer_props))
            {
                req.CustomerProps = customer_props;
            }
            if (!string.IsNullOrEmpty(market_id))
            {
                req.MarketId = market_id;
            }
            if (!string.IsNullOrEmpty(suite_items_str))
            {
                req.SuiteItemsStr = suite_items_str;
            }
            if (!string.IsNullOrEmpty(barcode_str))
            {
                req.BarcodeStr = barcode_str;
            }

            #endregion
            ProductsSearchResponse response = client.Execute(req);
            return response;
        }





    }
}
