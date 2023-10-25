using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaBackQuala.Application.Interfaces;
using PruebaBackQuala.DTOs;
using PruebaBackQuala.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaBackQuala.Domain
{
    public class QualaDomain : IQualaDomain
    {
        private readonly DbContextQuala _context;
        public QualaDomain(DbContextQuala context)
        {
            _context = context;
        }

        public async Task<List<DatosInformacionQuala>> GetDataQuala()
        {
            try
            {
                return await _context.DatosInformacionQuala.Include(x => x.Moneda).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<MonedaInformation>> GetDataMoneda()
        {
            try
            {
                return await _context.MonedaInformation.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DatosInformacionQuala> editDataQuala(DatosInformacionQuala editDataDTO)
        {
            try
            {
                _context.Update(editDataDTO);
                await _context.SaveChangesAsync();
                return editDataDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DatosInformacionQuala> InsertDataQuala(DatosInformacionQuala dataInformationQuala)
        {
            try
            {
                _context.Add(dataInformationQuala);
                await _context.SaveChangesAsync();
                return dataInformationQuala;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
