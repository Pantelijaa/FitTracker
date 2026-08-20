using System;
using System.Collections.Generic;
using System.Text;

namespace FitTracker.BuildingBlocks.Core.Domain
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (ValueObject)obj;

            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(a => a != null ? a.GetHashCode() : 0)
                .Aggregate((a, b) => a ^ b);
        }
    }
}
