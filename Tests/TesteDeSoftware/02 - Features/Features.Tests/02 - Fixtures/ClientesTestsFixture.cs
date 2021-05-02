using Features.Clientes;
using System;
using Xunit;

namespace Features.Tests
{
    [CollectionDefinition(nameof(ClienteCollection))]
    public class ClienteCollection : ICollectionFixture<ClientesTestsFixture>
    {}

    public class ClientesTestsFixture : IDisposable
    {
        public Cliente GerarClienteValido()
        {
            var cliente = new Cliente(
                Guid.NewGuid(),
                "Philipe",
                "Formagio",
                DateTime.Now.AddYears(-32),
                DateTime.Now,
                "phlipe.formagio@gmail.com",
                true
            );
            return cliente;
        }

        public Cliente GerarClienteInvalido()
        {
            var cliente = new Cliente(
                Guid.NewGuid(),
                "",
                "",
                DateTime.Now,
                DateTime.Now,
                "phlipe.formagio.com",
                true
            );
            return cliente;
        }

        public void Dispose()
        {
            
        }
    }
}
