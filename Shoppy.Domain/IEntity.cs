namespace Shopyy.Domain
{
    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }
}
