using BasketballXd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BasketballXd.Controllers
{
    [Route("Matchdatum")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Matchdatum> Post(CreateMatchDto createMatch)
        {
            var match = new Matchdatum
            {
                SubIn = DateTime.Now,
                PlayerId = Guid.NewGuid(),
                Fga = createMatch.FGA,
                Fgm = createMatch.FGM,
                Foul = createMatch.Foul,
                CreatedTime = DateTime.Now,




            };
            if (match != null)
            {
                using (var context = new BasketteamContext())
                {
                    context.Matchdata.Add(match);
                    context.SaveChanges();
                    return StatusCode(201, match);
                }
            }
            return BadRequest();
        }
        [HttpGet]
        public ActionResult<Matchdatum> Get()
        {
            using (var context = new BasketteamContext())
            {
                return Ok(context.Matchdata.ToList());
            }
        }

        [HttpPut]
        public ActionResult<Matchdatum> Put(Guid Id, UpdateMatchDto updateMatchDto)
        {
            using (var context = new BasketteamContext())
            {
                var existingMatch = context.Matchdata.FirstOrDefault(d => d.Id == Id);
                if (existingMatch != null)
                {
                    existingMatch.Fga = updateMatchDto.FGA;
                    existingMatch.Fgm = updateMatchDto.FGM;
                    existingMatch.SubOut = DateTime.Now;
                    existingMatch.UpdatedTime = DateTime.Now;



                    context.SaveChanges();

                    return Ok(existingMatch);

                }
                return NotFound();
            }
        }
        [HttpDelete]
        public ActionResult Delete(Guid Id)
        {
            using (var context = new BasketteamContext())
            {
                var delMatch = context.Matchdata.FirstOrDefault(x => x.Id == Id);
                if (delMatch != null)
                {
                    context.Matchdata.Remove(delMatch);
                    context.SaveChanges();
                    return StatusCode(200, delMatch);
                }
                return NotFound();
            }

        }
    }
}
