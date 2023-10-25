using Microsoft.AspNetCore.Mvc;
using PruebaBackQuala.Application.Interfaces;
using PruebaBackQuala.DTOs;
using PruebaBackQuala.Interfaces;
using PruebaBackQuala.Models;
using PruebaBackQuala.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaBackQuala.Application.Services
{
    public class QualaService : IQualaService
    {
        private readonly IQualaDomain QualaDomain;
        public QualaService(IQualaDomain qualaDomain)
        {
            QualaDomain = qualaDomain;
        }

        public async Task<ResultResponse<DatosInformacionDTO>> GetDataQuala()
        {
            try
            {
                List<DatosInformacionQuala> resp = await QualaDomain.GetDataQuala();
                if (resp.Count > 0)
                {
                    List<DatosInformacionDTO> respDTO = resp.Select(x => new DatosInformacionDTO
                    {
                        Codigo = x.Codigo,
                        Descripcion = x.Descripcion,
                        Direccion = x.Direccion,
                        Identificacion = x.Identificacion,
                        FechaCreacion = x.FechaCreacion,
                        Moneda = x.Moneda.Nombre
                    }).OrderByDescending(x => x.FechaCreacion).ToList();
                    return new ResultResponse<DatosInformacionDTO>(true, null, respDTO);
                }

                return new ResultResponse<DatosInformacionDTO>(true, "NotFoundData");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResultResponse<MonedaInformation>> GetDataMoneda()
        {
            try
            {
                List<MonedaInformation> resp = await QualaDomain.GetDataMoneda();
                if (resp.Count > 0)
                {
                    return new ResultResponse<MonedaInformation>(true, null, resp);
                }

                return new ResultResponse<MonedaInformation>(true, "NotFoundData");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResultResponse<DatosInformacionQuala>> InsertDataQuala(SaveDatosInformacionDTO dataInformationQuala)
        {
            try
            {
                DatosInformacionQuala dataInformationQualaSave = new DatosInformacionQuala
                {
                    Descripcion = dataInformationQuala.Descripcion,
                    Identificacion = dataInformationQuala.Identificacion,
                    Direccion = dataInformationQuala.Direccion,
                    FechaCreacion = DateTime.Now,
                    MonedaID = dataInformationQuala.Moneda
                };
                var isValid = validateCondition(dataInformationQualaSave);

                if (isValid.IsSucces)
                {
                    await QualaDomain.InsertDataQuala(dataInformationQualaSave);
                }

                return new ResultResponse<DatosInformacionQuala>(true, null, dataInformationQualaSave);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResultResponse<EditDataDTO>> editDataQuala(EditDataDTO editDataDTO)
        {
            try
            {
                DatosInformacionQuala editDatos = new DatosInformacionQuala
                {
                        Codigo = editDataDTO.Codigo,
                        Descripcion = editDataDTO.Descripcion,
                        Identificacion = editDataDTO.Identificacion,
                        Direccion = editDataDTO.Direccion,
                        FechaCreacion = DateTime.Now,
                        MonedaID = editDataDTO.Moneda
                };
                var isValid = validateCondition(editDatos);
                if (isValid.IsSucces)
                {
                    await QualaDomain.editDataQuala(editDatos);
                }

                return new ResultResponse<EditDataDTO>(true, null, editDataDTO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ResultResponse<IActionResult> validateCondition(DatosInformacionQuala dataDto)
        {
            if (dataDto.Descripcion.Length > 250 || dataDto.Descripcion == "")
            {
                return dataDto.Descripcion.Length > 250 ?
                    new ResultResponse<IActionResult> (false, "Recuerde que el texto es de máximo 250 caracteres") : new ResultResponse<IActionResult>(false, "Campo Descripcion incorrecto");
            }
            if (dataDto.Direccion.Length > 250 || dataDto.Direccion == "")
            {
                return dataDto.Direccion.Length > 250 ?
                    new ResultResponse<IActionResult> (false, "Recuerde que el texto es de máximo 250 caracteres") : new ResultResponse<IActionResult> (false, "Campo Direccion incorrecto");
            }
            if (dataDto.Identificacion.Length > 250 || dataDto.Identificacion == "")
            {
                return dataDto.Identificacion.Length > 250 ?
                    new ResultResponse<IActionResult> (false, "Recuerde que el texto es de máximo 50 caracteres") : new ResultResponse<IActionResult> (false, "Campo identificacion incorrecto");
            }

            return new ResultResponse<IActionResult>(true, null);
        }
    }
}
