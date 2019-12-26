namespace Shopyy.Domain
{
    public class EnumEntity<TEnum> : IEntity<TEnum> where TEnum : struct
    {
        public EnumEntity(TEnum @enum)
        {
            Id = @enum;
            Name = @enum.ToString();
        }

        protected EnumEntity()
        {
        }

        public TEnum Id { get; private set; }

        public string Name { get; private set; }
    }
}
