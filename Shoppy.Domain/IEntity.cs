using System;

namespace Shopyy.Domain
{
    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }

    public interface IEntity : IEntity<Guid>
    { }
}
