using Alura.Adopet.Console.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Util
{
    public static class PetAPartirDoCSV
    {
        public static Pet ConverteDoTexto(this string? linha)
        {
            if (linha == null) 
            { 
                throw new ArgumentNullException(nameof(linha), StringResources.LinhaNula); 
            }

            if (string.IsNullOrEmpty(linha)) 
            { 
                throw new ArgumentException(nameof(linha), StringResources.LinhaVazia); 
            }

            string[] propriedades = linha.Split(';');

            if (propriedades.Length < 3)
            {
                throw new ArgumentException(StringResources.QuantidadeInsuficienteDeCampos, nameof(linha));
            }

            if (!Guid.TryParse(propriedades[0], out Guid guid))
            {
                throw new ArgumentException(StringResources.GuidInvalido, nameof(linha));
            }

            if (!int.TryParse(propriedades[2], out int tipoPet) || tipoPet is < 0 or > 1)
            {
                throw new ArgumentException(StringResources.TipoInvalido, nameof(linha));
            }

            return new Pet(
                guid,
                propriedades[1],
                tipoPet == 0 ? TipoPet.Gato : TipoPet.Cachorro
            );
        }

    }
}
