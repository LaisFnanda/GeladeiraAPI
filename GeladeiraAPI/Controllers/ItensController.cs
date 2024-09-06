using Domain;
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
        private readonly IServices<Item> _services;        

        public ItensController(IServices<Item> services)
        {
            _services = services;                       
        }


        [HttpGet, HttpHead]
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
        public ActionResult <Item> Get(int id)
        {
            try
            {
                Item item = new Item { ID = id };
                return _services.ObterItem(item);
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
                _services.Inserir(item);
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

        [HttpDelete("Excluir um item")]
        public ActionResult Delete([FromBody] Item item)
        {
            try
            {
                _services.Excluir(item);
                return Ok("Removido com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }         

    }

}

    

