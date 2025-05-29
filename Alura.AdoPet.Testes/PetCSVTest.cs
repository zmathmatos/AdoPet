using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.AdoPet.Testes
{
    public class PetCSVTest
    {
        [Fact]
        public void QuandoStringForValidaDeveRetornarUmPet()
        {
            // Arrange
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";
            
            // Act
            Pet pet = linha.ConverteDoTexto();

            // Assert
            Assert.NotNull(pet);
        }

        [Fact]
        public void QuandoStringForNulaDeveLancarArgumentNullException()
        {
            // Arrange
            string? linha = null;

            // Act + Assert
            Assert.Throws<ArgumentNullException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void QuandoStringForVaziaDeveLancarArgumentException()
        {
            // Arrange
            string? linha = string.Empty;

            // Act + Assert
            Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void QuandoCamposInsuficienteDeveLancarArgumentException()
        {
            // Arrange
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão";

            // Act + Assert
            Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void QuandoGuidInvalidoDeveLancarArgumentException()
        {
            // Arrange
            string linha = "000;Lima Limão;1";

            // Act + Assert
            Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void QuandoTipoForInvalidoDeveLancarArgumentException()
        {
            // Arrange
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;3";

            // Act + Assert
            Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
        }
    }
}
