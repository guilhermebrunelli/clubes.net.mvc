namespace clubes.Models;

public class DetailsVM
{
    public Clube Anterior { get; set; }
    public Clube Atual { get; set; }
    public Clube Proximo { get; set; }
    public List<Pais> Paises { get; set; }
}
