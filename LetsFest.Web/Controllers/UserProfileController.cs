using LetsFest.Data.Dto;
using LetsFest.Data.Entity;
using LetsFest.Mysql;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using LetsFest.Web.DataService;

namespace LetsFest.Web.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly FestContext _context;
        private UserProfileService upService;
        public UserProfileController(FestContext context)
        {
            _context = context;
            upService=new UserProfileService(context);
        }
        public async Task<JsonResult> searchUser(string name)
        {
            return Json(await upService.searchUsers(name));
        }
        public IActionResult ProfileLink(string userId)
        {
            var profile=_context.UserProfile.SingleOrDefault(x => x.UserId == userId);
            var dto = AutoMapperConfig.Mapper.Map<UserProfileDto>(profile);
            dto.ProfilePicUrl="https://live.staticflickr.com/2376/1539767578_a28b5e7341_b.jpg";
            return PartialView(dto);
        }
        public IActionResult Profile(int profileId)
        {
            var profile = _context.UserProfile.SingleOrDefault(x => x.Id == profileId);
            var dto = AutoMapperConfig.Mapper.Map<UserProfileDto>(profile);
            dto.ProfilePicUrl = "https://live.staticflickr.com/2376/1539767578_a28b5e7341_b.jpg";
            return View(dto);
        }
    }
}
