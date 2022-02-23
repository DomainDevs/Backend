using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UOW.Interfaces;

namespace Application.Services
{
    public class CreateFlight
    {
        private readonly IUOW _unitOfWork;

        public CreateFlight(IUOW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Flight Get(int id)
        {
            using (var context = _unitOfWork.Create())
            {
                var result = context.Repositories.FlightRepository.Get(id);
                result.Transport = context.Repositories.TransportRepository.Get(result.FlightId);
                /*
                foreach (var item in result.Transport)
                {
                    item.Product = context.Repositories.ProductRepository.Get(item.ProductId);
                }
                */

                return result;
            }
        }

        public void Create(Flight model)
        {

            PrepareRouteJourney(model);

            using (var context = _unitOfWork.Create())
            {
                // Header
                context.Repositories.FlightRepository.Create(model);

                // Detail
                context.Repositories.TransportRepository.Create(model.Transport);

                // Confirm changes
                context.SaveChanges();
            }
        }
        private void PrepareRouteJourney(Flight model)
        {
            /*
            foreach (var detail in model)
            {
                detail.Total = detail.Quantity * detail.Price;
                detail.SubTotal = detail.Total / (1 + Parameters.IvaRate);
                detail.Iva = detail.Total - detail.SubTotal;
            }

            model.Total = model.Detail.Sum(x => x.Total);
            model.Iva = model.Detail.Sum(x => x.Iva);
            model.SubTotal = model.Detail.Sum(x => x.SubTotal);
            */
        }

    }
}
