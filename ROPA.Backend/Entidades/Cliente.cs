using System.ComponentModel.DataAnnotations;

public class Cliente
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nombre { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string Correo { get; set; }
}


