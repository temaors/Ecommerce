using AutoMapper;
using eCommerce.Database.DbEntities;
using eCommerce.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;

public class SaleController: BaseECommerceController
{
    private readonly IMapper _mapper;
    
    public SaleController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<SaleController> logger) 
        : base(unitOfWork, logger)
    {
        _mapper = mapper;
    }

    [HttpPost]
    [Route("sale")]
    public async Task<IActionResult> RegistrateSale(Cart cart)
    {
        double price = 0;
        HashSet<int> prods = new HashSet<int>();
        foreach (var element in cart.Products)
        {
            var product = await _unitOfWork.Products.GetById(element.Product.Id);
            if (product != null)
            {
                prods.Add(element.Product.Id);
                price += element.Count * product.Price;
            }
        }

        Sale sale = new Sale()
        {
            UserId = cart.UserId,
            Products = prods.ToList(),
            Price = price,
        };
        await _unitOfWork.Sales.Create(sale);
        return Ok();
    }
}