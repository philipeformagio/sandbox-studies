using Xunit;

namespace Demo.Tests
{
    public class AssertStringsTests
    {
        [Fact]
        public void Teste_de_PadLeft()
        {
            // Arrage
            var nome = "Philipe";

            // Act
            var nomeComZero = nome.PadLeft(7, '0');

            // Assert
            Assert.Equal("Philipe", nomeComZero);
        }

        [Fact]
        public void StringTools_UnirNomes_RetornaNomeCompleto()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir("Philipe", "Formagio");

            // Assert
            Assert.Equal("Philipe Formagio", nomeCompleto);
        }

        [Fact]
        public void StringTools_UnirNomes_DeveIgnorarCase()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir("Philipe", "Formagio");

            // Assert
            Assert.Equal("PHILIPE FORMAGIO", nomeCompleto, true);
        }

        [Fact]
        public void StringTools_UnirNomes_DeveConterTrecho()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir("Philipe", "Formagio");

            // Assert
            Assert.Contains("For", nomeCompleto);
        }

        [Fact]
        public void StringTools_UnirNomes_DeveComecarCom()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir("Philipe", "Formagio");

            // Assert
            Assert.StartsWith("Phi", nomeCompleto);
        }

        [Fact]
        public void StringTools_UnirNomes_DeveTerminarCom()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir("Philipe", "Formagio");

            // Assert
            Assert.EndsWith("gio", nomeCompleto);
        }

        [Fact]
        public void StringTools_UnirNomes_ValidaExpressaoRegular()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir("Philipe", "Formagio");

            // Assert
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", nomeCompleto);
        }
    }
}
