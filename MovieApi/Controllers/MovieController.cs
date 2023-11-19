using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieApi.Models;
using MovieApi.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
 
namespace MovieAppapi.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class MovieController : ControllerBase
    {
        MovieContext context=new MovieContext();
 
        [HttpGet]
        [Route("ShowMovies")]
 
        public IActionResult GetShowMovies()
        {
            // var data=context.Movie_VMs.FromSqlInterpolated<Movie_VM>($"MoviesInfo");
            var data=context.Movie_VMs.FromSqlInterpolated<Movie_VM>($"xyz");
            return Ok(data);
        }
 
        [HttpGet]
        [Route("DisplayMovies/Rating/Year")]
        public IActionResult GetDisplayMovies(int rating,int year)
        {
            var data=from m in context.Movies where m.Rating ==rating && m.YearRelease== year select m;
            if(data.Count()==0)
            {
                return NotFound($"No Movies in {rating} for the year {year}");
            }
            return Ok(data);
        }
        [HttpGet]
        [Route("DisplayByRating")]
        public IActionResult GetDisplayByRating([FromQuery] int rating)
        {
            var data=context.Movies.Where(m=>m.Rating == rating);
            if(data.Count()==0)
            {
                return NotFound($"No Movies in rating {rating}");
            }
            return Ok(data);
        }
 
 
       
 
        [HttpGet]
       
        [Route("ListMovies")]
        public IActionResult Get()
        {
            // var data=context.Movies.ToList();
            var data = from m in context.Movies select m;
            return Ok(data);
 
        }
        [HttpGet]
        [Route("ListMovies/{id}")]
        public IActionResult Get(int id)
        {
            if(id==null)
            {
                return BadRequest("Id cannot be Null");
            }
            var data = (from m in context.Movies where m.Id == id select m).FirstOrDefault();
            if(data == null)
            {
                return NotFound($"Movie {id} not Found");
            }
            return Ok(data);
        }
        [HttpPost]
        [Route("AddMovie")]
        public IActionResult Post(Movie movie)
        {
            if(ModelState.IsValid)
            {
                try{
                    context.Movies.Add(movie);
                    context.SaveChanges();
                }
                catch(System.Exception ex)
                {
                    return BadRequest(ex.InnerException.Message);
                }
            }
            return Created("Record Added", movie);
        }
        [HttpPut]
        [Route("EditMovie/{id}")]
        public IActionResult Put(int id,Movie movie)
        {
            if(ModelState.IsValid)
 
            {
                //omovie is the object that fetch data from database
                //movie is the object that fetch data from UI
                Movie omovie=context.Movies.Find(id);
                omovie.Name=movie.Name;
                omovie.Rating=movie.Rating;
                omovie.YearRelease=movie.YearRelease;
                context.SaveChanges();
                return Ok();
 
            }
            return BadRequest("Unable to Edit Record");
        }
        [HttpDelete]
        [Route("DeleteMovie/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // var detail =context.Details.Where(d=>d.MovieId==id);
                // if(detail.Count() !=0)
                // {
                //     throw new Exception("Cannot Delete movie");
                // }
                var data=context.Movies.Find(id);
                context.Movies.Remove(data);
                context.SaveChanges();
                return Ok();
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            }
        }
 
    }