using PruebaBackQuala.DTOs;
using PruebaBackQuala.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaBackQuala.Application.Interfaces
{
    public interface IQualaDomain
    {
        /// <summary>
        /// Traer datos de la tabla DatosInformacionQuala
        /// </summary>
        /// <returns></returns>
        Task<List<DatosInformacionQuala>> GetDataQuala();
        /// <summary>
        /// Traer datos de la tabla MonedaInformation
        /// </summary>
        /// <returns></returns>
        Task<List<MonedaInformation>> GetDataMoneda();

        /// <summary>
        /// Editar Datos 
        /// </summary>
        /// <returns></returns>
        Task<DatosInformacionQuala> editDataQuala(DatosInformacionQuala editDataDTO);

        /// <summary>
        /// Agregar Datos
        /// </summary>
        /// <returns></returns>
        Task<DatosInformacionQuala> InsertDataQuala(DatosInformacionQuala dataInformationQuala);
    }
}
