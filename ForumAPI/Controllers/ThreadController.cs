using AutoMapper;
using ForumAPI.Entities;
using ForumAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Controllers
{
    [Route("api/thread")]
    public class ThreadController : ControllerBase
    {
        private readonly ThreadContext _threadContext;
        private readonly IMapper _mapper;

        public ThreadController(ThreadContext threadContext, IMapper mapper)
        {
            _threadContext = threadContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<ThreadDetailsDto>> Get()
        {
            var threads = _threadContext.Threads.ToList();
            var threadDtos = _mapper.Map<List<ThreadDetailsDto>>(threads);

            return Ok(threadDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<ThreadDetailsDto> Get(int id)
        {
            var thread = _threadContext.Threads
                .FirstOrDefault(m => m.Id == id);

            if(thread == null)
            {
                return NotFound();
            }

            var threadDto = _mapper.Map<ThreadDetailsDto>(thread);

            return Ok(threadDto);
        }

        [HttpPost]
        public ActionResult Post([FromBody]ThreadDto model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var thread = _mapper.Map<Thread>(model);
            _threadContext.Threads.Add(thread);
            _threadContext.SaveChanges();

            var key = thread.Id;
            //var tmp = _threadContext.Threads.Last<Thread>().Id;
            //var key = tmp + 1;

            return Created("api/thread/" + key, null);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]ThreadDto model)
        {
            var thread = _threadContext.Threads
                .FirstOrDefault(m => m.Id == id);

            if (thread == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            thread.Subject = model.Subject;
            thread.AddDate = model.AddDate;
            thread.UpdateDate = model.UpdateDate;
            thread.Author = model.Author;
            thread.Content = model.Content;

            _threadContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var thread = _threadContext.Threads
                .FirstOrDefault(m => m.Id == id);

            if (thread == null)
            {
                return NotFound();
            }

            _threadContext.Remove(thread);
            _threadContext.SaveChanges();

            return NoContent();
        }
    }
}
