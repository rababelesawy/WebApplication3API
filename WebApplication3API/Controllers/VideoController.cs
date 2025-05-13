using Master.Core.Dtos;
using Master.Core.Entities;
using Master.Repository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly StoreContext _context;

        public VideoController(StoreContext context)
        {
            _context = context;
        }

        // Admin only
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddVideo([FromBody] VideoDtos dto)
        {
            var video = new video
            {
                Title = dto.Title,
                YouTubeUrl = dto.YouTubeUrl
            };

            _context.Videos.Add(video);
            await _context.SaveChangesAsync();

            return Ok("Video added successfully");
        }

        // Admin only
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditVideo(int id, [FromBody] VideoDtos dto)
        {
            var video = await _context.Videos.FindAsync(id);
            if (video == null) return NotFound();

            video.Title = dto.Title;
            video.YouTubeUrl = dto.YouTubeUrl;

            await _context.SaveChangesAsync();
            return Ok("Video updated successfully");
        }

        // Admin only
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteVideo(int id)
        {
            var video = await _context.Videos.FindAsync(id);
            if (video == null) return NotFound();

            _context.Videos.Remove(video);
            await _context.SaveChangesAsync();
            return Ok("Video deleted successfully");
        }

        // Anyone (Admin or User)
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllVideos()
        {
            var videos = await _context.Videos
                .OrderByDescending(v => v.CreatedAt)
                .ToListAsync();

            return Ok(videos);
        }




    }
}
