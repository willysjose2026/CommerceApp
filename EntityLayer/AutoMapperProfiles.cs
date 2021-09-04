using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using EntityLayer.DTO;

namespace EntityLayer
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Stock_EntryDTO, STOCK_ENTRY>()
                .ForMember(d => d.PRODUCT_ID, a => a.MapFrom(s => s.PRODUCT_NAME))
                .ForMember(d => d.SUPPLIER_ID, a => a.MapFrom(s => s.SUPPLIER_NAME))
                .ForMember(d => d.ENTRY_DATE, a => a.MapFrom(s => DateTime.Parse(s.ENTRY_DATE)));

            CreateMap<InvoiceDTO, INVOICE>()
                .ForMember(d => d.Id, a => a.Ignore())
                .ForMember(d => d.INVOICE_DATE, a => a.UseValue(DateTime.Now))
                .ForMember(d => d.CUSTOMER_ID, a => a.MapFrom(s => s.customerId))
                .ForMember(d => d.INVOICE_TOTAL, a => a.MapFrom(s => s.invoiceTotal))
                .ForMember(d => d.Discount, a => a.MapFrom(s => s.Discount));

            CreateMap<InvoiceItemsDTO, INVOICE_ITEMS>()
                .ForMember(d => d.Id, a => a.Ignore())
                .ForMember(d => d.INVOICE_ID, a => a.MapFrom(s => s.InvoiceId))
                .ForMember(d => d.PRODUCT_ID, a => a.MapFrom(s => s.ProductId))
                .ForMember(d => d.QUANTITY, a => a.MapFrom(s => s.Quantity))
                .ForMember(d => d.TOTAL_PRICE, a => a.MapFrom(s => s.TotalPrice))
                .ForMember(d => d.discount, a => a.MapFrom(s => s.Discount));
        }
    }
}
