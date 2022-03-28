using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PromartApi.Dto;
using PromartApi.Entidades;
using PromartApi.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromartApi.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;
        public ClienteController(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteDto>>> Get()
        {
            var clientes = await applicationDbContext.Clientes.ToListAsync();
            return mapper.Map<List<ClienteDto>>(clientes);
        }

        [HttpGet("{id}", Name = "GetCliente")]
        public async Task<ActionResult<ClienteDto>> Get(int id)
        {
            var cliente = await applicationDbContext.Clientes.FirstOrDefaultAsync(o => o.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }
            return mapper.Map<ClienteDto>(cliente);
        }


        [HttpPost]
        public async Task<ActionResult<ClienteDto>> Post(ClienteCreationDto clienteCreationDto)
        {
            var cliente = mapper.Map<Clientes>(clienteCreationDto);

            applicationDbContext.Add(cliente);
            await applicationDbContext.SaveChangesAsync();

            var dto = mapper.Map<ClienteDto>(cliente);

            return new CreatedAtRouteResult("GetCliente", new { id = cliente.Id}, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteDto>> Put(int id, ClienteCreationDto clienteCreationDto)
        {
            var cliente = await applicationDbContext.Clientes.FirstOrDefaultAsync(o => o.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }
            mapper.Map(clienteCreationDto, cliente);

            applicationDbContext.Entry(cliente).State = EntityState.Modified;

            await applicationDbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteDto>> Post(int id)
        {
            var cliente = await applicationDbContext.Clientes.FirstOrDefaultAsync(o => o.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            applicationDbContext.Entry(cliente).State = EntityState.Deleted;

            await applicationDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
