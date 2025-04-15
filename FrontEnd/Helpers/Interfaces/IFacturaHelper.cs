using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IFacturaHelper
    {

        List<FacturaViewModel> GetFacturas();

        FacturaViewModel GetFactura(int? id);
        FacturaViewModel Add(FacturaViewModel factura);
        FacturaViewModel Update(FacturaViewModel factura);
        void Delete(int id);
    }
}
