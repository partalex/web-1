namespace Shared.Realisations;

public class FilterDecor
{
    public FilterInfo Materials { get; set; } = new FilterInfo( "Materijal" );
    public FilterInfo Textures { get; set; } = new FilterInfo( "Tekstur" );
    public FilterInfo Purposes { get; set; } = new FilterInfo( "Namena" );
    public FilterInfo Patterns { get; set; } = new FilterInfo( "Tekstura" );
    public FilterInfo Colors { get; set; } = new FilterInfo( "Boja" );
    public FilterInfo Reflections { get; set; } = new FilterInfo( "Refleksija" );
    public FilterInfo Manufacturers { get; set; } = new FilterInfo( "Proizvođač" );
}