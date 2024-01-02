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
    public class InvoiceHeaderServices : IInvoiceHeaderServices
    {
        private IRTaxApiDbContext _context;

        public InvoiceHeaderServices(IRTaxApiDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Add(InvoiceHeaderViewModelDto aDto)
        {

            if (_context.InvoiceHeaders.Any(c => c.CompanyId == aDto.CompanyId &&  c.Taxid == aDto.Taxid))
            {
                return new ResultDto()
                {
                    Data = null,
                    IsSuccess = false,
                    Error = "InvoiceHeader is duplicate"
                };
            }
            try
            {
                var a = ModelMapper.MapToDto(aDto);
            
                _context.InvoiceHeaders.Add(a);
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

        public async Task<ResultDto> Edit(InvoiceHeaderViewModelDto aDto)
        {
            if (_context.InvoiceHeaders.Any(c => c.CompanyId == aDto.CompanyId &&  c.Taxid == aDto.Taxid && c.Id != aDto.Id))
            {
                return new ResultDto()
                {
                    Data = null,
                    IsSuccess = false,
                    Error = "InvoiceHeader is duplicate"
                };
            }
            else
            {
                var a = await _context.InvoiceHeaders.FirstOrDefaultAsync(a => a.Id == aDto.Id);
                if (a != null)
                {
                    a.Taxid = aDto.Taxid;
                    a.OrderDate = aDto.OrderDate;
                    a.RegisterDate = aDto.RegisterDate;
                    a.Indatim = aDto.Indatim;
                    a.Indati2m = aDto.Indati2m;
                    a.Inty = aDto.Inty;
                    a.Inno = aDto.Inno;
                    a.Irtaxid = aDto.Irtaxid;
                    a.Inp = aDto.Inp;
                    a.Ins = aDto.Ins;
                    a.Tins = aDto.Tins;
                    a.Tob = aDto.Tob;
                    a.Bid = aDto.Bid;
                    a.Tinb = aDto.Tinb;
                    a.Sbc = aDto.Sbc;
                    a.Bpc = aDto.Bpc;
                    a.Bbc = aDto.Bbc;
                    a.Ft = aDto.Ft;
                    a.Bpn = aDto.Bpn;
                    a.Scln = aDto.Scln;
                    a.Scc = aDto.Scc;
                    a.Crn = aDto.Crn;
                    a.Billid = aDto.Billid;
                    a.Tprdis = aDto.Tprdis;
                    a.Tdis = aDto.Tdis;
                    a.Tadis = aDto.Tadis;
                    a.Tvam = aDto.Tvam;
                    a.Todam = aDto.Todam;
                    a.Tbill = aDto.Tbill;
                    a.Setm = aDto.Setm;
                    a.Cap = aDto.Cap;
                    a.Insp = aDto.Insp;
                    a.Tvop = aDto.Tvop;
                    a.Tax17 = aDto.Tax17;
                    a.Cdcn = aDto.Cdcn;
                    a.Cdcd = aDto.Cdcd;
                    a.Tonw = aDto.Tonw;
                    a.Torv = aDto.Torv;
                    a.Tocv = aDto.Tocv;
                    a.Uid = aDto.Uid;
                    a.ReferenceNumber = aDto.ReferenceNumber;
                    a.Status = aDto.Status;

                    return new ResultDto()
                    {
                        Data = aDto.Id,
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
                        Error = "InvoiceHeader not Exist"
                    };
                }
            }
        }

        public async Task<ResultDto> Delete(long id)
        {
            var a = await _context.InvoiceHeaders.FirstOrDefaultAsync(a => a.Id == id);
            if (a == null || a.Id <= 0)
            {

                return new ResultDto()
                {
                    Data = null,
                    IsSuccess = false,
                    Error = "InvoiceHeader not Exist"
                };
            }
            _context.InvoiceHeaders.Remove(a);
            _context.SaveChangesAsync();
            return new ResultDto()
            {
                Data = "",
                Error = "",
                IsSuccess = true
            };
        }

        public async Task<ResultDto> GetList(int companyId)
        {
            var a = await _context.InvoiceHeaders.Where(a=>a.CompanyId== companyId).Select(a=>new InvoiceHeaderViewModelDto()
            {
                Id = a.Id,
                CompanyId = a.CompanyId,
                Taxid = a.Taxid,
                OrderDate = a.OrderDate,
                RegisterDate = a.RegisterDate,
                Indatim = a.Indatim,
                Indati2m = a.Indati2m,
                Inty = a.Inty,
                Inno = a.Inno,
                Irtaxid = a.Irtaxid,
                Inp = a.Inp,
                Ins = a.Ins,
                Tins = a.Tins,
                Tob = a.Tob,
                Bid = a.Bid,
                Tinb = a.Tinb,
                Sbc = a.Sbc,
                Bpc = a.Bpc,
                Bbc = a.Bbc,
                Ft = a.Ft,
                Bpn = a.Bpn,
                Scln = a.Scln,
                Scc = a.Scc,
                Crn = a.Crn,
                Billid = a.Billid,
                Tprdis = a.Tprdis,
                Tdis = a.Tdis,
                Tadis = a.Tadis,
                Tvam = a.Tvam,
                Todam = a.Todam,
                Tbill = a.Tbill,
                Setm = a.Setm,
                Cap = a.Cap,
                Insp = a.Insp,
                Tvop = a.Tvop,
                Tax17 = a.Tax17,
                Cdcn = a.Cdcn,
                Cdcd = a.Cdcd,
                Tonw = a.Tonw,
                Torv = a.Torv,
                Tocv = a.Tocv,
                Uid = a.Uid,
                ReferenceNumber = a.ReferenceNumber,
                Status = a.Status,
            }).ToListAsync();

            if (a == null)
            {
                return new ResultDto()
                {
                    Data = null,
                    IsSuccess = false,
                    Error = "InvoiceHeader list is empty "
                };
            }

            return new ResultDto()
            {
                Data = a,
                Error = "",
                IsSuccess = true
            };
        }

        public async Task<ResultDto> Get(long id)
        {
            var a = await _context.InvoiceHeaders.FirstOrDefaultAsync(a => a.Id == id);
            if (a == null || a.Id <= 0)
            {
                return new ResultDto()
                {
                    Data = null,
                    IsSuccess = false,
                    Error = "InvoiceHeader not Exist"
                };
            }

            return new ResultDto()
            {
                Data =ModelMapper.MapToDto(a),
                Error = "",
                IsSuccess = true
            };
        }
    }
}
