using Pi.Core.Entity;
using Pi.Core.Models;
using Pi.Core.Repositories;
using Pi.Core.Services;
using Pi.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pi.Service.Services
{
    public class ShoppingCartService : Service<ShoppingCart>, IShoppingCartService
    {
        public ShoppingCartService(IUnitOfWork unitOfWork, IRepository<ShoppingCart> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<IEnumerable<ShoppingCart>> GetWithProductByIdAsync(int appuserId)
        {
            return await _unitOfWork.ShoppingCarts.GetWithProductByIdAsync(appuserId);
        }
        
        public async Task<ErrorModel<Product>> ProductStockControl(int productId,int stok)
        {
            ErrorModel<Product> errorModel = new ErrorModel<Product>();

            var model= await _unitOfWork.Products.SingleOrDefaultAsync(x => x.Id == productId);

            if (model == null)
            {

                errorModel.IsOk = false;
                errorModel.Status = 400;
                errorModel.Errors.Add("Product not found");

                return errorModel;
            } 

            if (model.Stock< stok)
            {

                errorModel.IsOk = false;
                errorModel.Status = 400;
                errorModel.Errors.Add("Product is out of stock");

                return errorModel;
            }

            errorModel.IsOk = true;
            errorModel.Model = model;

            return errorModel;
        }   
        
        public async Task<ErrorModel<Appuser>> AppuserControl(int appuserid)
        {
            ErrorModel<Appuser> errorModel = new ErrorModel<Appuser>();

            var model = await _unitOfWork.Appusers.SingleOrDefaultAsync(x => x.Id == appuserid);

            if (model == null)
            {

                errorModel.IsOk = false;
                errorModel.Status = 400;
                errorModel.Errors.Add("User not found");

                return errorModel;
            } 

   
            errorModel.IsOk = true;
            errorModel.Model = model;

            return errorModel;
        }
        

        public async Task<ErrorModel<ShoppingCart>> ShoppingCartControl(int productId,int appyserid)
        {
            ErrorModel<ShoppingCart> errorModel = new ErrorModel<ShoppingCart>();

            var model = await _unitOfWork.ShoppingCarts.SingleOrDefaultAsync(x => x.AppuserId == appyserid && x.ProductId == productId);

            if (model == null)
            {

                errorModel.IsOk = false;

                return errorModel;
            }


            errorModel.IsOk = true;
            errorModel.Model = model;


            return errorModel;
        }




    }
}
