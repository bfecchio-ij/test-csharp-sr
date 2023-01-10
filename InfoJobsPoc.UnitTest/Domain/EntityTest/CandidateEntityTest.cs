using InfoJobsPoc.Core.Entities;
using InfoJobsPoc.Core.Enums;

namespace InfoJobsPoc.UnitTest.Domain.EntityTest
{
    public class CandidateEntityTest
    {
        [Fact]
        public void Validate_Candidate_ExpectedStatusEnumInvalid()
        {
            var candidate = new Candidate();
            var notifications = candidate.Validate();

            Assert.NotNull(notifications);
            Assert.Equal(4, notifications.Messages.Count());
            foreach (var notification in notifications.Messages)
            {
                Assert.Equal(StatusEnum.Invalid, notification.Status);
            }
        }
    }
}
