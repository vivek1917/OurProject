using MongoDB.Driver;
using OurProject.Models;

namespace OurProject.Services
{
    public class AssignmentStatusUpdaterService : BackgroundService
    {
        private readonly IMongoCollection<Assignment> _assignmentsCollection;
        private readonly TimeSpan _updateInterval = TimeSpan.FromHours(1);

        public AssignmentStatusUpdaterService(IMongoDatabase database)
        {
            _assignmentsCollection = database.GetCollection<Assignment>("assignments");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await UpdateOverdueAssignments();
                await Task.Delay(_updateInterval, stoppingToken);
            }
        }

        private async Task UpdateOverdueAssignments()
        {
            var filter = Builders<Assignment>.Filter.And(
                Builders<Assignment>.Filter.Lt(a => a.DueDate, DateTime.UtcNow),
                Builders<Assignment>.Filter.Eq(a => a.Status, "ongoing")
            );

            var update = Builders<Assignment>.Update.Set(a => a.Status, "overdue");

            await _assignmentsCollection.UpdateManyAsync(filter, update);
        }

    }
}
