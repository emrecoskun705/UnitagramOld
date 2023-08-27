namespace Unitagram.Core.Domain.Entities
{
    public class UniversityDomain
    {
        public int UniversityId { get; set; }
        public University University { get; set; }

        public int DomainId { get; set; }
        public Domain Domain { get; set; }
    }
}
