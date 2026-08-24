using Application.DTOs;
using Application.Services.Lesson;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace corbret.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonController : ControllerBase
    {
        private readonly LessonService _service;

        public LessonController(LessonService service)
        {
            _service = service;
        }

        // GET: api/Lesson/GetAllLessons
        [HttpGet("GetAllLessons")]
        public async Task<ActionResult<IEnumerable<LessonDTO>>> GetAllLessons()
        {
            var lessons = await _service.GetAllLessons();

            return Ok(lessons);
        }

        // GET: api/Lesson/GetLessonById/{id}
        [HttpGet("GetLessonById/{id}")]
        public async Task<ActionResult<LessonDTO>> GetLessonById(int id)
        {
            var lesson = await _service.GetLessonById(id);

            if (lesson == null)
            {
                return NotFound($"Lesson with id {id} does not exist");
            }

            return Ok(lesson);
        }

        // POST: api/Lesson/AddLesson
        [HttpPost("AddLesson")]
        public async Task<ActionResult<LessonDTO>> AddLesson(LessonDTO lessonDTO)
        {
            var result = await _service.CreateLesson(lessonDTO);

            if (result == null)
            {
                return BadRequest("Invalid data, or the related Department/Function/Industry does not exist.");
            }

            return Ok(result);
        }

        // PUT: api/Lesson/UpdateLesson/{id}
        [HttpPut("UpdateLesson/{id}")]
        public async Task<IActionResult> UpdateLesson(int id, LessonDTO lessonDTO)
        {
        
            lessonDTO.id = id;

            var result = await _service.UpdateLesson(lessonDTO);
        
            if (!result)
            {
                return NotFound($"Lesson with id {id} does not exist");
            }

            return Ok("Lesson updated successfully");
        }

        // DELETE: api/Lesson/DeleteLesson/{id}
        [HttpDelete("DeleteLesson/{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            var result = await _service.DeleteLesson(id);

            if (!result)
            {
                return NotFound($"Lesson with id {id} does not exist");
            }

            return Ok("Lesson deleted successfully");
        }
    }
}