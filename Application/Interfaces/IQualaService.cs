using PruebaBackQuala.DTOs;
using PruebaBackQuala.Models;
using PruebaBackQuala.Utilities;
using System;
using System.Threading.Tasks;

namespace PruebaBackQuala.Interfaces
{
    public interface IQualaService
    {
        /// <summary>
        /// Traer datos de la tabla DatosInformacionQuala
        /// </summary>
        /// <returns></returns>
        Task<ResultResponse<DatosInformacionDTO>> GetDataQuala();
        /// <summary>
        /// Traer datos de la tabla MonedaInformation
        /// </summary>
        /// <returns></returns>
        Task<ResultResponse<MonedaInformation>> GetDataMoneda();

        /// <summary>
        /// Editar Dtaos 
        /// </summary>
        /// <returns></returns>
        Task<ResultResponse<EditDataDTO>> editDataQuala(EditDataDTO editDataDTO);
        /// <summary>
        /// Agregar Datos
        /// </summary>
        /// <returns></returns>
        Task<ResultResponse<DatosInformacionQuala>> InsertDataQuala(SaveDatosInformacionDTO dataInformationQuala);
    }
}
