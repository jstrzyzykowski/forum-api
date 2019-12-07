using AutoMapper;
using ForumAPI.Entities;
using ForumAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Controllers
{
    [Route("api/thread/{threadId}/comment")]
    public class CommentController : ControllerBase
    {
        private readonly ThreadContext _threadContext;
        private readonly IMapper _mapper;

        public CommentController(ThreadContext threadContext, IMapper mapper)
        {
            _threadContext = threadContext;
            _mapper = mapper;
        }

        [HttpDelete]
        public ActionResult Delete(int threadId)
        {
            var thread = _threadContext.Threads
                .Include(m => m.Comments)
                .FirstOrDefault(m => m.Id == threadId);

            if (thread == null)
            {
                return NotFound();
            }

            _threadContext.Comments.RemoveRange(thread.Comments);
            _threadContext.SaveChanges();

            return NoContent();
        }


        [HttpGet]
        public ActionResult Get(int threadId)
        {
            var thread = _threadContext.Threads
                .Include(m => m.Comments)
                .FirstOrDefault(m => m.Id == threadId);

            if (thread == null)
            {
                return NotFound();
            }

            var comments = _mapper.Map<List<CommentDto>>(thread.Comments);

            return Ok(comments);
        }


        [HttpPost]
        public ActionResult Post(int threadId, [FromBody] CommentDto model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var thread = _threadContext.Threads
                .Include(m => m.Comments)
                .FirstOrDefault(m => m.Id == threadId);

            if (thread == null)
            {
                return NotFound();
            }

            var comment = _mapper.Map<Comment>(model);
            thread.Comments.Add(comment);
            _threadContext.SaveChanges();

            return Created($"api/thread/{threadId}", null);
        }
    }
}
