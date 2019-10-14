/// <summary>
/// @author Ankit
/// @date - 10/14/2019 2:52:40 PM 
/// </summary>
namespace SurveyShrike_API.Domain.Entities
{
    public interface ISoftDeleteEntity
    {
        public bool isDeleted { get; set; }
    }
}
