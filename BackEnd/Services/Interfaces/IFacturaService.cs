using BackEnd.DTO;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IFacturaService
    {
        bool CreateFactura(FacturaDTO Factura);
        bool UpdateFactura(FacturaDTO Factura);
        void DeleteFactura(int id);
        List<FacturaDTO> GetFacturas();
        FacturaDTO GetFacturaById(int id);
    }
}
