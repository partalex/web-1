namespace Shared.Realisations;

public class FilterParamsDecor
{
    public string? Name { get; set; }
    public List<int>? Materials { get; set; }
    public List<int>? Purposes { get; set; }
    public List<int>? Colors { get; set; }
    public List<int>? Reflections { get; set; }
    public List<int>? Patterns { get; set; }
    public List<int>? Manufacturers { get; set; }

    public void Reset()
    {
        Name = null;
        Materials = null;
        Purposes = null;
        Colors = null;
        Reflections = null;
    }

    public void UpdateName(string value)
    {
        Name = value;
    }

    public void UpdateMaterials(List<int> value)
    {
        Materials = value;
    }

    public void UpdatePurposes(List<int> value)
    {
        Purposes = value;
    }

    public void UpdatePatterns(List<int> value)
    {
        Patterns = value;
    }


    public void UpdateColors(List<int> value)
    {
        Colors = value;
    }

    public void UpdateReflections(List<int> value)
    {
        Reflections = value;
    }

    public void UpdateManufacturers(List<int> value)
    {
        Manufacturers = value;
    }
}