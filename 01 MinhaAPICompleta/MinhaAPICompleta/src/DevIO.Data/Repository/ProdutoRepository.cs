﻿using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MeuDbContext context) : base(context)
        {

        }

        public async Task<Produto> ObterProdutoFornecedore(Guid id)
        {
            return await Db.Produtos.AsNoTracking().Include(p => p.Fornecedor)
                                                    .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await Db.Produtos.AsNoTracking().Include(p => p.Fornecedor)
                                                    .OrderBy(p => p.Nome)
                                                    .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            //return await Db.Produtos.AsNoTracking().Include(p => p.Fornecedor).Where(p => p.FornecedorId == fornecedorId).ToListAsync();
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }
    }
}
