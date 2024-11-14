namespace Domain.Entities;

/// <summary>
/// Базовый абстрактный класс сущности.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Уникальный идентификатор сущности.
    /// </summary>
    public Guid Id { get; protected set; }

    /// <summary>
    /// Переопределение метода для сравнения с другим объектом.
    /// </summary>
    /// <param name="obj">Объект сущности для сравнения.</param>
    /// <returns>bool</returns>
    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;
        else if (obj is not BaseEntity entity)
            return false;
        else if (entity.Id != Id)
            return false;
        return true;
    }

    /// <summary>
    /// Переопределение метода для получения хэш-кода объекта.
    /// </summary>
    /// <returns>Хэш-код.</returns>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    /// <summary>
    /// Переопределение ToString для логгирования.
    /// </summary>
    /// <returns>Все поля в виде строки.</returns>
    public override string ToString()
    {
        var props = GetType().GetProperties();
        var values = props.Select(prop => $"{prop.Name}: {prop.GetValue(this) ?? "null"}");
        return string.Join(" ", values);
    }

    /// <summary>
    /// Оператор сравнения на равенство.
    /// </summary>
    /// <param name="left">Левый операнд.</param>
    /// <param name="right">Правый операнд.</param>
    /// <returns>True, если объекты равны; иначе false.</returns>
    public static bool operator ==(BaseEntity? left, BaseEntity? right)
    {
        if (ReferenceEquals(left, right))
            return true;
        if (left is null || right is null)
            return false;
        return left.Equals(right);
    }

    /// <summary>
    /// Оператор сравнения на неравенство.
    /// </summary>
    /// <param name="left">Левый операнд.</param>
    /// <param name="right">Правый операнд.</param>
    /// <returns>True, если объекты не равны; иначе false.</returns>
    public static bool operator !=(BaseEntity? left, BaseEntity? right)
    {
        return !(left == right);
    }
}