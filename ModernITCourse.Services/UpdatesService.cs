using Microsoft.EntityFrameworkCore;
using ModernITCourse.DataAccessLayer;
using ModernITCourse.DataAccessLayer.Entities;
using ModernITCourse.Services.DomainTransferObjects;
using System;
using System.Threading.Tasks;

namespace ModernITCourse.Services
{
    public class UpdatesService : ServiceBase, IUpdatesService
    {
        public UpdatesService(CourseContext context) : base(context)
        {
        }

        public async Task<UpdateDto> GetUniversitiesListUpdate(DateTime? currentTimeStamp)
        {
            UpdateInfo update = await Context.Updates.AsNoTracking()
                .FirstOrDefaultAsync(u => string.Equals(u.TableName, nameof(Context.Universities)));
            var noUpdateNeeded = new UpdateDto()
            {
                NeedUpdate = false,
            };

            if (update == null)
            {
                await MarkAsUpdated(nameof(Context.Universities));
                return noUpdateNeeded;
            }

            if (!currentTimeStamp.HasValue || currentTimeStamp.Value < update.TimeStamp)
                return new UpdateDto()
                {
                    NeedUpdate = true,
                    IsFinished = update.IsFinished,
                    TimeStamp = update.TimeStamp
                };

            return noUpdateNeeded;
        }

        public async Task MarkAsUpdated(string tableName)
        {
            var update = await Context.Updates.FirstOrDefaultAsync(u => string.Equals(u.TableName, tableName));
            if (update != null)
            {
                update.TimeStamp = DateTime.Now;
                await Context.SaveChangesAsync();
                return;
            }

            await Context.Updates.AddAsync(new UpdateInfo()
            {
                IsFinished = false,
                TableName = tableName,
                TimeStamp = DateTime.Now
            });

            await Context.SaveChangesAsync();
        }
    }
}
