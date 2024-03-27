namespace clubes.Models;

public class Clube
{
    public int Numero { get; set; } 
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public List<string> Pais { get; set; }
    public string Imagem { get; set; }

    public Clube()
    {
        Pais = new List<string>();
    }
}
