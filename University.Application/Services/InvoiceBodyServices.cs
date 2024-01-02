using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoMapper;
using IRTaxApi.Application.Dtos;
using IRTaxApi.Application.Intefaces;
using IRTaxApi.Application.Mapper;
using IRTaxApi.Data.Contexts;
using IRTaxApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Story.Application.Interfaces;

namespace IRTaxApi.Application.Repositories
{
    public class InvoiceBodyServices : IInvoiceBodyServices
    {
        private IRTaxApiDbContext _context;

        public InvoiceBodyServices(IRTaxApiDbContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Add(InvoiceBodyViewModelDto invoiceBodyDto)
        {

            if (_context.InvoiceBodies.Any(c => c.HeaderId == invoiceBodyDto.HeaderId &&  c.Sstid == invoiceBodyDto.Sstid))
            {
                return new ResultDto()
                {
                    Data = null,
                    IsSuccess = false,
                    Error = "InvoiceBody is duplicate"
                };
            }
            try
            {
                var invoiceBody = ModelMapper.MapToDto(invoiceBodyDto);
            
                _context.InvoiceBodies.Add(invoiceBody);
                await _context.SaveChangesAsync();
                return new ResultDto()
                {
                    Data = null,
                    IsSuccess = true,
                    Error = String.Empty
                };
            }
            catch (Exception e)
            {
                return new ResultDto()
                {
                    Data = null,
                    IsSuccess = false,
                    Error = e.Message
                };
            }
        }

        public async Task<ResultDto> Edit(InvoiceBodyViewModelDto invoiceBodyDto)
        {
            if (_context.InvoiceBodies.Any(c => c.HeaderId == invoiceBodyDto.HeaderId &&  c.Sstid == invoiceBodyDto.Sstid && c.Id != invoiceBodyDto.Id))
            {
                return new ResultDto()
                {
                    Data = null,
                    IsSuccess = false,
                    Error = "InvoiceBody is duplicate"
                };
            }
            else
            {
                var invoiceBody = await _context.InvoiceBodies.FirstOrDefaultAsync(a => a.Id == invoiceBodyDto.Id);
                if (invoiceBody != null)
                {
                    invoiceBody.Sstid = invoiceBodyDto.Sstid;
                    invoiceBody.Sstt = invoiceBodyDto.Sstt;
                    invoiceBody.Mu = invoiceBodyDto.Mu;
                    invoiceBody.Am = invoiceBodyDto.Am;
                    invoiceBody.Fee = invoiceBodyDto.Fee;
                    invoiceBody.Cfee = invoiceBodyDto.Cfee;
                    invoiceBody.Cut = invoiceBodyDto.Cut;
                    invoiceBody.Exr = invoiceBodyDto.Exr;
                    invoiceBody.Prdis = invoiceBodyDto.Prdis;
                    invoiceBody.Dis = invoiceBodyDto.Dis;
                    invoiceBody.Adis = invoiceBodyDto.Adis;
                    invoiceBody.Vra = invoiceBodyDto.Vra;
                    invoiceBody.Vam = invoiceBodyDto.Vam;
                    invoiceBody.Odt = invoiceBodyDto.Odt;
                    invoiceBody.Odr = invoiceBodyDto.Odr;
                    invoiceBody.Odam = invoiceBodyDto.Odam;
                    invoiceBody.Olt = invoiceBodyDto.Olt;
                    invoiceBody.Olr = invoiceBodyDto.Olr;
                    invoiceBody.Olam = invoiceBodyDto.Olam;
                    invoiceBody.Consfee = invoiceBodyDto.Consfee;
                    invoiceBody.Spro = invoiceBodyDto.Spro;
                    invoiceBody.Bros = invoiceBodyDto.Bros;
                    invoiceBody.Tcpbs = invoiceBodyDto.Tcpbs;
                    invoiceBody.Cop = invoiceBodyDto.Cop;
                    invoiceBody.Vop = invoiceBodyDto.Vop;
                    invoiceBody.Bsrn = invoiceBodyDto.Bsrn;
                    invoiceBody.Tsstam = invoiceBodyDto.Tsstam;
                    invoiceBody.Nw = invoiceBodyDto.Nw;
                    invoiceBody.Ssrv = invoiceBodyDto.Ssrv;
                    invoiceBody.Sscv = invoiceBodyDto.Sscv;

                    return new ResultDto()
                    {
                        Data = invoiceBodyDto.Sstid,
                        Error = "",
                        IsSuccess = true
                    };
                }
                else
                {
                    return new ResultDto()
                    {
                        Data = null,
                        IsSuccess = false,
                        Error = "InvoiceBody not Exist"
                    };
                }
            }
        }

        public async Task<ResultDto> Delete(long id)
        {
            var invoiceBody = await _context.InvoiceBodies.FirstOrDefaultAsync(a => a.Id == id);
            if (invoiceBody == null || invoiceBody.Id <= 0)
            {

                return new ResultDto()
                {
                    Data = null,
                    IsSuccess = false,
                    Error = "InvoiceBody not Exist"
                };
            }
            _context.InvoiceBodies.Remove(invoiceBody);
            _context.SaveChangesAsync();
            return new ResultDto()
            {
                Data = "",
                Error = "",
                IsSuccess = true
            };
        }

        public async Task<ResultDto> GetList(long headerId)
        {
            var invoiceBody = await _context.InvoiceBodies.Where(a=>a.HeaderId== headerId).Select(a=>new InvoiceBodyViewModelDto()
            {
                Id = a.Id,
                HeaderId = a.HeaderId,
                Sstid = a.Sstid,
                Sstt = a.Sstt,
                Mu = a.Mu,
                Am = a.Am,
                Fee = a.Fee.ToLongSafe(0),
                Cfee = a.Cfee.ToLongSafe(0),
                Cut = a.Cut,
                Exr = a.Exr.ToLongSafe(0),
                Prdis = a.Prdis.ToLongSafe(0),
                Dis = a.Dis.ToLongSafe(0),
                Adis = a.Adis.ToLongSafe(0),
                Vra = a.Vra,
                Vam = a.Vam.ToLongSafe(0),
                Odt = a.Odt,
                Odr = a.Odr.ToLongSafe(0),
                Odam = a.Odam.ToLongSafe(0),
                Olt = a.Olt,
                Olr = a.Olr.ToLongSafe(0),
                Olam = a.Olam.ToLongSafe(0),
                Consfee = a.Consfee.ToLongSafe(0),
                Spro = a.Spro.ToLongSafe(0),
                Bros = a.Bros.ToLongSafe(0),
                Tcpbs = a.Tcpbs.ToLongSafe(0),
                Cop = a.Cop.ToLongSafe(0),
                Vop = a.Vop.ToLongSafe(0),
                Bsrn = a.Bsrn,
                Tsstam = a.Tsstam.ToLongSafe(0),
                Nw = a.Nw,
                Ssrv = a.Ssrv.ToLongSafe(0),
                Sscv = a.Sscv.ToLongSafe(0)

            }).ToListAsync();

            if (invoiceBody == null)
            {
                return new ResultDto()
                {
                    Data = null,
                    IsSuccess = false,
                    Error = "InvoiceBody list is empty "
                };
            }

            return new ResultDto()
            {
                Data = invoiceBody,
                Error = "",
                IsSuccess = true
            };
        }

        public async Task<ResultDto> Get(long id)
        {
            var invoiceBody = await _context.InvoiceBodies.FirstOrDefaultAsync(a => a.Id == id);
            if (invoiceBody == null || invoiceBody.Id <= 0)
            {
                return new ResultDto()
                {
                    Data = null,
                    IsSuccess = false,
                    Error = "InvoiceBody not Exist"
                };
            }

            return new ResultDto()
            {
                Data =ModelMapper.MapToDto(invoiceBody),
                Error = "",
                IsSuccess = true
            };
        }
    }
}
