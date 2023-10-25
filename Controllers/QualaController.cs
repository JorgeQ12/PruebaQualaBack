using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaBackQuala.DTOs;
using PruebaBackQuala.Interfaces;
using PruebaBackQuala.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaBackQuala.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualaController : ControllerBase
    {

        private readonly IQualaService QualaService;
        private readonly DbContextQuala DbContext;
        public QualaController(IQualaService qualaService, DbContextQuala dbContext)
        {
            QualaService = qualaService;
            DbContext = dbContext;
        }

        [HttpGet]
        [Route(nameof(QualaController.GetDataQuala))]
        public async Task<IActionResult> GetDataQuala()
        {
            try
            {
                var resultData = QualaService.GetDataQuala();
                if (resultData.Result.IsSucces)
                {
                    return Ok(resultData.Result.Data);
                }
                return BadRequest(resultData.Result.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route(nameof(QualaController.GetDataMoneda))]
        public async Task<IActionResult> GetDataMoneda()
        {
            try
            {
                var resultData = QualaService.GetDataMoneda();
                if (resultData.Result.IsSucces)
                {
                    return Ok(resultData.Result.Data);
                }
                return BadRequest(resultData.Result.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route(nameof(QualaController.InsertDataQuala))]
        public async Task<IActionResult> InsertDataQuala(SaveDatosInformacionDTO dataInformationQuala)
        {
            try
            {
                var insertData = QualaService.InsertDataQuala(dataInformationQuala);
                if (insertData.Result.IsSucces)
                {
                    return Ok(insertData.Result.Data != null ? insertData.Result.Data : insertData.Result.DataNoList);
                }
                return Ok(dataInformationQuala);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<DatosQualaController>/5
        [HttpPut]
        [Route(nameof(QualaController.EditDataQuala))]
        public async Task<IActionResult> EditDataQuala(EditDataDTO editDataDTO)
        {
            try
            {
                var editData = QualaService.editDataQuala(editDataDTO);
                if (editData.Result.IsSucces)
                {
                    return Ok(editData.Result.Data != null ? editData.Result.Data : editData.Result.DataNoList);
                }
                return BadRequest(editData.Result.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteInfoQuala/{idCodePerson}")]
        public async Task<IActionResult> DeleteInfoQuala(int idCodePerson)
        {
            try
            {
                var deleteInfo = await DbContext.DatosInformacionQuala.FindAsync(idCodePerson);
                if (deleteInfo == null)
                {
                    return NotFound("No se encontró la información a eliminar");
                }

                DbContext.DatosInformacionQuala.Remove(deleteInfo);
                await DbContext.SaveChangesAsync();
                return Ok(new {message = "se ha eliminado correctamente" });
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
