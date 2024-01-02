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
    public class InvoicePaymentServices : IInvoicePaymentServices
    {
        private IRTaxApiDbContext _context;

        public InvoicePaymentServices(IRTaxApiDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Add(InvoicePaymentViewModelDto invoicePaymentDto)
        {

            if (_context.InvoicePayments.Any(c => c.HeaderId == invoicePaymentDto.HeaderId && (invoicePaymentDto.Trn == "" || c.Trn == invoicePaymentDto.Trn)))
            {
                return new ResultDto()
                {
                    Data = null,
                    IsSuccess = false,
                    Error = "InvoicePayment is duplicate"
                };
            }
            try
            {
                var invoicePayment = ModelMapper.MapToDto(invoicePaymentDto);
            
                _context.InvoicePayments.Add(invoicePayment);
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

        public async Task<ResultDto> Edit(InvoicePaymentViewModelDto invoicePaymentDto)
        {
            if (_context.InvoicePayments.Any(c => (invoicePaymentDto.Trn == "" || c.Trn == invoicePaymentDto.Trn) && (invoicePaymentDto.Trn == "" || c.Trn == invoicePaymentDto.Trn) && c.Id != invoicePaymentDto.Id))
            {
                return new ResultDto()
                {
                    Data = null,
                    IsSuccess = false,
                    Error = "InvoicePayment is duplicate"
                };
            }
            else
            {
                var invoicePayment = await _context.InvoicePayments.FirstOrDefaultAsync(a => a.Id == invoicePaymentDto.Id);
                if (invoicePayment != null)
                {
                    invoicePayment.Iinn = invoicePaymentDto.Iinn;
                    invoicePayment.Acn = invoicePaymentDto.Acn;
                    invoicePayment.Trmn = invoicePaymentDto.Trmn;
                    invoicePayment.Trn = invoicePaymentDto.Trn;
                    invoicePayment.Pcn = invoicePaymentDto.Pcn;
                    invoicePayment.Pid = invoicePaymentDto.Pid;
                    invoicePayment.Pdt = invoicePaymentDto.Pdt;
                    invoicePayment.Pmt = invoicePaymentDto.Pmt;
                    invoicePayment.Pv = invoicePaymentDto.Pv;

                    return new ResultDto()
                    {
                        Data = invoicePaymentDto.Id,
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
                        Error = "InvoicePayment not Exist"
                    };
                }
            }
        }

        public async Task<ResultDto> Delete(long id)
        {
            var invoicePayment = await _context.InvoicePayments.FirstOrDefaultAsync(a => a.Id == id);
            if (invoicePayment == null || invoicePayment.Id <= 0)
            {

                return new ResultDto()
                {
                    Data = null,
                    IsSuccess = false,
                    Error = "InvoicePayment not Exist"
                };
            }
            _context.InvoicePayments.Remove(invoicePayment);
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
            var invoicePayment = await _context.InvoicePayments.Where(a=>a.HeaderId == headerId).Select(a=>new InvoicePaymentViewModelDto()
            {
                Id = a.Id,
                HeaderId = a.HeaderId,
                Iinn = a.Iinn,
                Acn = a.Acn,
                Trmn = a.Trmn,
                Trn = a.Trn,
                Pcn = a.Pcn,
                Pid = a.Pid,
                Pdt = a.Pdt,
                Pmt = a.Pmt,
                Pv = a.Pv
            }).ToListAsync();

            if (invoicePayment == null)
            {
                return new ResultDto()
                {
                    Data = null,
                    IsSuccess = false,
                    Error = "InvoicePayment list is empty "
                };
            }

            return new ResultDto()
            {
                Data = invoicePayment,
                Error = "",
                IsSuccess = true
            };
        }

        public async Task<ResultDto> Get(long id)
        {
            var invoicePayment = await _context.InvoicePayments.FirstOrDefaultAsync(a => a.Id == id);
            if (invoicePayment == null || invoicePayment.Id <= 0)
            {
                return new ResultDto()
                {
                    Data = null,
                    IsSuccess = false,
                    Error = "InvoicePayment not Exist"
                };
            }

            return new ResultDto()
            {
                Data =ModelMapper.MapToDto(invoicePayment),
                Error = "",
                IsSuccess = true
            };
        }
    }
}
