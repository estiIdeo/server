


using Health.Core.Domain.Common;
using Health.Core.Interfaces;
using Health.Data;

namespace Health.Infrastructure.Services
{
    public class TagsService : ITagsService
    {
        private readonly HealthDbContext _dbContext;
        public TagsService(HealthDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(Tag model)
        {

             await _dbContext.Tags.AddAsync(new Tag()
             {
                 Name = model.Name,
                 Color = model.Color
             });

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}