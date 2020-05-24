using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DevIO.App.ViewModels;

    public class VaiSerJogadoForaContext : DbContext
    {
        public VaiSerJogadoForaContext (DbContextOptions<VaiSerJogadoForaContext> options)
            : base(options)
        {
        }

        public DbSet<DevIO.App.ViewModels.FornecedorViewModel> FornecedorViewModel { get; set; }
    }
