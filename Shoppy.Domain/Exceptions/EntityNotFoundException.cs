using System;
using System.Collections.Generic;
using System.Text;

namespace Shopyy.Domain.Exceptions
{
    public class EntityNotFoundException<TEntity> : Exception
        where TEntity : IEntity
    {
        public EntityNotFoundException(object key) : base(FormatMessage(nameof(TEntity), key))
        {
        }

        private static string FormatMessage(string name, object key) => $"Resource: {name} is not found for key: {key}";
    }
}
