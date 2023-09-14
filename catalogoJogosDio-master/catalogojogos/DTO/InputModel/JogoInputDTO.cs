using System.ComponentModel.DataAnnotations;

namespace catalogojogos.DTO.InputModel
{
    public class JogoInputDTO
    {

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O nome do jogo deve conter entre 3 e 50 caracteres")]
        public string Nome { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome da produtora deve conter entre 3 e 100 caracteres")]
        public string Produtora { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "O preço do jogo dever ser entre 1 e 1000 reais")]
        public double Preco { get; set; }
    }
}
