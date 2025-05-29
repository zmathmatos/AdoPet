using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alura.AdoPet.Testes
{
    public class GeraDocumentacaoTest
    {
        [Fact]
        public void QuandoExistemComandosDeveRetornarDicionarioNaoVazio()
        {
            // Arrange
            Assembly assemblyComDocComando = 
                Assembly.GetAssembly(typeof(DocComando))!;

            // Act
            Dictionary<string, DocComando> dicionario = 
                DocumentacaoDoSistema.ToDictionary(assemblyComDocComando);

            // Assert
            Assert.NotNull(dicionario);
            Assert.NotEmpty(dicionario);
            Assert.Equal(3, dicionario.Count);

        }
    }
}
