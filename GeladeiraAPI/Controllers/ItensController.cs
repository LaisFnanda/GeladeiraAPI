using Domain.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services;
using Services.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GeladeiraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItensController : ControllerBase
    {
        private readonly IItemServices<Item> _services;        

        public ItensController(IItemServices<Item> services)
        {
            _services = services;                       
        }


        [HttpGet]
        public ActionResult<IEnumerable<Item>> Get()
        {
            try
            {
                return _services.ObterTodos();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       

        [HttpGet("{id}")]
        public ActionResult GetId(int ItemID)
        {
            try
            {
                var item = _services.ObterItem(ItemID);

                if (item == null) 
                return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
               
        [HttpPost]
        public ActionResult<string> Post([FromBody] Item item)
        {
            try
            {
                _services.InserirItem(item);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("Alterar Descrição Item")]
        public IActionResult Put([FromBody] Item item)
        {
            try
            {
                _services.Atualizar(item);
                return Ok("Atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem([FromBody] int IdItem)
        {
            try
            {
                _services.ExcluirItem(IdItem);
                return Ok("Item Removido com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Esvaziar Container")]
        public ActionResult RemoverTodos(int numAndar, int numContainer)
        {
            try
            {  
                _services.RemoverTodos(numAndar, numContainer);
                return Ok("Container esvaziado!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpOptions]
        public IActionResult ObterOptions()
        {
            Response.Headers.Append("Allow", "GET,POST,PUT,PATCH,DELETE,HEAD,OPTIONS");
            return Ok();
        }

    }

}

    

