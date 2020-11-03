using System.Threading.Tasks;
using TwitterProject.ApplicationLayer.Models.DTOs;

namespace TwitterProject.ApplicationLayer.Services.Abstraction
{
    public interface ILikeService
    {
        Task Like(LikeDto model);
        Task Unlike(LikeDto model);


    }
}
