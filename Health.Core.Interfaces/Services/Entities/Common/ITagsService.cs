using Health.Core.Domain.Common;

namespace Health.Core.Interfaces
{
    public interface ITagsService
    {
        Task<bool> Create(Tag model);
    }
}