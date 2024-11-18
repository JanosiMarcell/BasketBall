using BasketballXd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasketballXd.Controllers
{
    [Route("Player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Player> Post(CreatePlayerDto createPlayer)
        {
            var player = new Player
            {
                Id=Guid.NewGuid(),
                Name=createPlayer.Name,
                Height=createPlayer.Height,
                Weight=createPlayer.Weight,
                CreatedTime=DateTime.Now,


            };
            if (player != null)
            {
                using (var context = new BasketteamContext())
                {
                    context.Players.Add(player);
                    context.SaveChanges();
                    return StatusCode(201, player);
                }
            }
            return BadRequest();
        }

        [HttpGet]
        public ActionResult<Player> Get()
        {
            using (var context = new BasketteamContext())
            {
                return Ok(context.Players.ToList());
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Player> GetById(Guid id)
        {
            using (var context = new BasketteamContext())
            {
                var player = context.Players.FirstOrDefault(x => x.Id == id);
                if (player != null)
                {
                    return Ok(player);
                }
                return NotFound();
            }
        }

        [HttpPut]
        public ActionResult<Player> Put(Guid Id, UpdatePlayerDto updatePlayerDto)
        {
            using (var context = new BasketteamContext())
            {
                var existingPlayer=context.Players.FirstOrDefault(x =>x.Id == Id);
                if (existingPlayer != null)
                {
                    existingPlayer.Name = updatePlayerDto.Name;
                    existingPlayer.Height = updatePlayerDto.Height;
                    existingPlayer.Weight = updatePlayerDto.Weight;
                    context.SaveChanges();
                    return StatusCode(200,existingPlayer);
                }
                return NotFound();
            }

        }
        [HttpDelete]
        public ActionResult Delete(Guid Id)
        {
            using (var context = new BasketteamContext())
            {
                var delPlayer = context.Players.FirstOrDefault(x => x.Id == Id);
                if (delPlayer != null)
                {
                    context.Players.Remove(delPlayer);
                    context.SaveChanges();
                    return StatusCode(200, delPlayer);
                }
                return NotFound();
            }

        }




    }
}
