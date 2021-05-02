using Xunit;

namespace Demo.Tests
{
    public class AssertCollectionTests
    {
        [Fact]
        public void Funcionario_Habilidades_NaoDevePossuirHabilidadesVazias()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Philipe", 10000);

            // Assert
            Assert.All(funcionario.Habilidades, habilidade => Assert.False(string.IsNullOrEmpty(habilidade)));
        }

        [Fact]
        public void Funcionario_Habilidades_JuniorDevePossuirHabilidadesBasica()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Philipe", 10000);

            // Assert
            Assert.Contains("OOP", funcionario.Habilidades);
        }

        [Fact]
        public void Funcionario_Habilidades_JuniorNaoDevePossuirHabilidadesBasica()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Philipe", 2000);

            // Assert
            Assert.DoesNotContain("Microservices", funcionario.Habilidades);
        }
        
        [Fact]
        public void Funcionario_Habilidades_SeniorDevePossuirTodasHabilidades()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Philipe", 15000);

            var habilidades = new[]
            {
                "Lógica de Programação",
                "OOP",
                "Testes",
                "Microservices"
            };

            // Assert
            Assert.Equal(funcionario.Habilidades, habilidades);
        }

    }
}
