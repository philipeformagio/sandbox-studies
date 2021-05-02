using System;
using System.Collections.Generic;

namespace Features.Core
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        IEnumerable<T> ObterTodos();
        void Adicionar(T cliente);
        void Atualizar(T cliente);
        void Remover(Guid id);
    }
}
