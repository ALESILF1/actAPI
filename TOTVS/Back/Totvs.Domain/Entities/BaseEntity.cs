using System.Diagnostics.CodeAnalysis;

namespace Alesilf.Totvs.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
