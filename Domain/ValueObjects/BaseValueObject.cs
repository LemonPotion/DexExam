using System.Reflection;

namespace Domain.ValueObjects;


public abstract class BaseValueObject : IEquatable<BaseValueObject>
{
    public bool Equals(BaseValueObject? other)
    {
        if (other == null || other.GetType() != GetType())
            return false;
        
        foreach (var property in GetProperties())
        {
            var value1 = property.GetValue(this);
            var value2 = property.GetValue(other);
            if (!Equals(value1, value2))
                return false;
        }
        
        foreach (var field in GetFields())
        {
            var value1 = field.GetValue(this);
            var value2 = field.GetValue(other);
            if (!Equals(value1, value2))
                return false;
        }

        return true;
    }
    
    public override bool Equals(object? obj)
    {
        return Equals(obj as BaseValueObject);
    }
    
    public override int GetHashCode()
    {
        var hash = 17;

        foreach (var property in GetProperties())
        {
            var value = property.GetValue(this);
            hash = hash * 31 + (value?.GetHashCode() ?? 0);
        }

        foreach (var field in GetFields())
        {
            var value = field.GetValue(this);
            hash = hash * 31 + (value?.GetHashCode() ?? 0);
        }

        return hash;
    }
    
    private IEnumerable<PropertyInfo> GetProperties()
    {
        return GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(p => !p.GetGetMethod()!.IsVirtual);
    }
    
    private IEnumerable<FieldInfo> GetFields()
    {
        return GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
    }
    
    public static bool operator ==(BaseValueObject? left, BaseValueObject? right)
    {
        return left?.Equals(right) ?? ReferenceEquals(right, null);
    }
    
    public static bool operator !=(BaseValueObject? left, BaseValueObject? right)
    {
        return !(left == right);
    }
}