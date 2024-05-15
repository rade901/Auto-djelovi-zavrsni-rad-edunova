using API.Data;
using API.DTOs;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DijeloviController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;


        public DijeloviController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dio>>> Get()
        {
            try
            {
                var dijelovi = await _context.Dijelovi.ToListAsync();
                return Ok(dijelovi);
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                               ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dio>> GetDio(int id)
        {
            try
            {
                var dio = await _context.Dijelovi.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(dio);
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                          ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Dio>> Insert(InsertDto insertDto)
        {
            try
            {

                var dio = new Dio
                {
                    Naziv = insertDto.Naziv,
                    Sifra = insertDto.Sifra,
                    Cijena = insertDto.Cijena,
                    Proizvodac = insertDto.Proizvodac
                };

                _context.Dijelovi.Add( dio );
                await _context.SaveChangesAsync();

                return Ok(dio);

            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                           ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, UpdateDto updateDto)
        {
            try
            {
                if (id == 0 || updateDto == null)
                {
                    return BadRequest(ModelState);
                }

                var dio = await _context.Dijelovi.FirstOrDefaultAsync(x => x.Id == id);

                if (dio == null) return NotFound();

                _mapper.Map(updateDto, dio);

                _context.Dijelovi.Update( dio );
                await _context.SaveChangesAsync( );

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                       ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {

                var dio = await _context.Dijelovi.FindAsync(id);
                if(dio != null)
                {
                    _context.Dijelovi.Remove(dio);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                        ex.Message);
            }
        }

    }
}
