using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STKDotNetCore.PizzaApi.Db;
using System.Xml.Schema;
using static STKDotNetCore.PizzaApi.Db.AppDbContext;

namespace STKDotNetCore.PizzaApi.Features.Pizza
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public PizzaController()
        {
            _appDbContext = new AppDbContext();
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var lst = await _appDbContext.Pizzas.ToListAsync();
            return Ok(lst);
        }

        [HttpGet("Extras")]
        public async Task<IActionResult> GetExtrasAsync()
        {
            var lst = await _appDbContext.PizzaExtras.ToListAsync();
            return Ok(lst);
        }

        [HttpGet("Order/{invoiceNo}")]
        public async Task<IActionResult> GetOrderAsync(string invoiceNo)
        {
            var item = await _appDbContext.PizzaOrders.FirstOrDefaultAsync(x=> x.PizzaOrderInvoiceNo == invoiceNo);
            var lst = await _appDbContext.PizzaOrderDetails.Where(x=> x.PizzaOrderInvoiceNo == invoiceNo).ToListAsync();

            //return Ok(new
            //{
            //    Order = item,
            //    OrderDetail = lst
            //});

            CombineModel combineModel = new CombineModel()
            {
                Order = item,
                Details = lst
            };
            return Ok(combineModel);
        }

        [HttpPost("Order")]
        public async Task<IActionResult> OrderAsync(OrderRequest orderRequest)
        {
            var pizzaItem = await _appDbContext.Pizzas.FirstOrDefaultAsync(x => x.Id == orderRequest.PizzaId);
            var total = pizzaItem.Price;

            if (orderRequest.Extras.Length > 0)
            {
                //select * from Tbl_PizzaExtra where PizzaExtraId In (1,2,3,4)
                //foreach (var item in orderRequest.Extras)
                //{
                //}

                var lstExtra = await _appDbContext.PizzaExtras.Where(x => orderRequest.Extras.Contains(x.Id)).ToListAsync();
                total += lstExtra.Sum(x => x.Price);
            }
            var invoiceNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            PizzaOrderModel pizzaOrderModel = new PizzaOrderModel()
            {
                PizzaId = orderRequest.PizzaId,
                PizzaOrderInvoiceNo = invoiceNo,
                TotalAmount = total
            };

            List<PizzaOrderDetailModel> pizzaOrderDetailModels = orderRequest.Extras.Select(extraId => new PizzaOrderDetailModel
            {
                PizzaExtraId = extraId,
                PizzaOrderInvoiceNo = invoiceNo
            }).ToList();


            await _appDbContext.PizzaOrders.AddAsync(pizzaOrderModel);
            await _appDbContext.PizzaOrderDetails.AddRangeAsync(pizzaOrderDetailModels);
            await _appDbContext.SaveChangesAsync();

            OrderResponse response = new OrderResponse()
            {
                InvoiceNo = invoiceNo,
                Message ="Thank you for your order! Enjoy your pizza!",
                TotalAmount= total
            };

            return Ok(response);
        }
    }
}
