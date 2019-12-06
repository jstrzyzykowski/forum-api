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
    }
}
