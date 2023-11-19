using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Models;
 
 
namespace MovieAppapi.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class DetailController : ControllerBase
    {
 
        MovieContext context=new MovieContext();
 
        [HttpGet]
        [Route("DisplayMovieDetails/{id}")]
        public IActionResult Get(int id)
        {
            var data=from d in context.Details where d.MovieId==id select new{ Artist=d.Actor,Role=d.Role,MovieName=d.Movie.Name,Year=d.Movie.YearRelease};
            return Ok(data);
        }
       
 
        [HttpGet]
        [Route("ListDetails")]
        public IActionResult Get()
        {
            // var data=context.Movies.ToList();
            var data = from d in context.Details select new{MovieName=d.Movie.Name,Artist=d.Actor,Role=d.Role};
            return Ok(data);
 
        }
       
       
       
        // [HttpGet]
        // [Route("ListDetails")]
        // public IActionResult Get()
        // {
        //     // var data=context.Movies.ToList();
        //     var data = from d in context.Details select d;
        //     return Ok(data);
 
        // }
 
 
        [HttpGet]
        [Route("ListDetails/{id}")]
        public IActionResult Get(int? id)
        {
            if(id==null)
            {
                return BadRequest("Id cannot be Null");
            }
            var data = (from d in context.Details where d.DetailId == id select d).FirstOrDefault();
            if(data == null)
            {
                return NotFound($"Movie {id} not Found");
            }
            return Ok(data);
        }
        [HttpPost]
        [Route("AddDetail")]
        public IActionResult Post(Detail detail)
        {
            if(ModelState.IsValid)
            {
                try{
                    context.Details.Add(detail);
                    context.SaveChanges();
                }
                catch(System.Exception ex)
                {
                    return BadRequest(ex.InnerException.Message);
                }
            }
            return Created("Record Added", detail);
        }
 
        [HttpPut]
        [Route("EditDetail/{id}")]
        public IActionResult Put(int id,Detail detail)
        {
            if(ModelState.IsValid)
 
            {
                //omovie is the object that fetch data from database
                //movie is the object that fetch data from UI
                Detail odetail=context.Details.Find(id);
                odetail.Actor=detail.Actor;
               
                odetail.Gender=detail.Gender;
                odetail.Role=detail.Role;
                odetail.Movie=detail.Movie;
                context.SaveChanges();
                return Ok();
 
            }
            return BadRequest("Unable to Edit Record");
        }
 
        [HttpDelete]
        [Route("DeleteDetail/{id}")]
        public IActionResult Delete(int id)
        {
           
                var data=context.Details.Find(id);
                context.Details.Remove(data);
                context.SaveChanges();
                return Ok();
           
           
            }
            }
        }