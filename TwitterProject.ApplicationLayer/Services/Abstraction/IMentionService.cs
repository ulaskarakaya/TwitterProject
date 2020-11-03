using System.Threading.Tasks;
using TwitterProject.ApplicationLayer.Models.DTOs;

namespace TwitterProject.ApplicationLayer.Services.Abstraction
{
    public interface IMentionService
    {
        Task AddMention(AddMentionDto model);
    }
}
