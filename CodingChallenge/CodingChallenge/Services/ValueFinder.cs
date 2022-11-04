namespace CodingChallenge.Services;

public class ValueFinder : IValueFinder
{
    public int GetValue(object? obj)
    {
        var value = 0;
        if (obj is null || !obj.GetType().Namespace.StartsWith("CodingChallenge"))
            return value;
        foreach (var property in obj.GetType().GetProperties())
        {                       
            var propertyValue = property.GetValue(obj);
            if (property.Name == "value" && propertyValue is int)
                value += (int)property.GetValue(obj);
            else
                value += GetValue(propertyValue);
        }

        return value;
    }
}