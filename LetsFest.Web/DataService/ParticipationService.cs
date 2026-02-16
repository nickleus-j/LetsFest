using LetsFest.Data;
using System.Security.Claims;

namespace LetsFest.Web.DataService
{
    public class ParticipationService
    {
        IDataUnitOfWork _unitOfWork;
        public ParticipationService(IDataUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Participate(long eventId,short roleId, ClaimsIdentity claimsIdentity)
        {
            var userIdClaim = claimsIdentity.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim != null)
            {
                var userIdValue = userIdClaim.Value;
                await _unitOfWork.EventParticipationRepository.ParticipateInEvent(eventId, userIdClaim.Value, roleId);
            }
        }
        public async Task Participate(long eventId, short roleId, string userName)
        {
            await _unitOfWork.EventParticipationRepository.ChooseEventParticipant(userName, eventId, roleId);
        }
    }
}
