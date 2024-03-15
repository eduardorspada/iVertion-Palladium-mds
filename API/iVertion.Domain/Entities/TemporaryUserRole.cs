
using iVertion.Domain.Validation;

namespace iVertion.Domain.Entities
{
    public sealed class TemporaryUserRole : Entity
    {
        public string? Role { get; private set; }
        public string? TargetUserId { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? ExpirationDate { get; private set; }


        private void ValidationDomain(string? role,
                                      string? targetUserId,
                                      DateTime? startDate,
                                      DateTime?expirationDate)
        {
            DomainExceptionValidation.When(String.IsNullOrEmpty(role),
                                           "Invalid Role, must not be null or empty.");
            DomainExceptionValidation.When(role.Length < 5,
                                           "Invalid Role, too short, must be at least 5 characters long.");
            DomainExceptionValidation.When(role.Length > 25,
                                           "Invalid Role, too long, max 25 characters.");
            DomainExceptionValidation.When(String.IsNullOrEmpty(targetUserId),
                                           "Invalid Target User Id, must not be null or empty.");
            DomainExceptionValidation.When(startDate != null,
                                           "Invalid Start Date, must not be null");
            DomainExceptionValidation.When(startDate >= DateTime.Now,
                                           "Invalid Start Date, must be greater than the current date.");
            DomainExceptionValidation.When(expirationDate != null,
                                           "Invalid Expiration Date, must not be null");
            DomainExceptionValidation.When(expirationDate > startDate,
                                           "Invalid Expiration Date, must be greater than the Start Date.");

            Role = role;
            TargetUserId = targetUserId;
            StartDate = startDate;
            ExpirationDate = expirationDate;
            
        }
    }
}