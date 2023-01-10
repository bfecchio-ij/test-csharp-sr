using InfoJobsPoc.Core.Entities;
using InfoJobsPoc.Core.Enums;

namespace InfoJobsPoc.UnitTest.Domain.EntityTest
{
    public class ExperienceEntityTest
    {
        [Fact]
        public void Validate_Experience_ExpectedStatusEnumInvalid()
        {
            var experience = new Experience() { };
            var notifications = experience.Validate();

            Assert.NotNull(notifications);
            Assert.True(notifications.Messages.Count() > 0);
            foreach (var notification in notifications.Messages)
            {
                Assert.Equal(StatusEnum.Invalid, notification.Status);
            }
        }
    }
}
