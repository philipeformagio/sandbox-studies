using MediatR;

namespace Features.Clientes
{
    public class ClienteEmailNotification : INotification
    {
        public string Origem { get; set; }
        public string Destino { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }

        public ClienteEmailNotification(string origem, string destino, string assunto, string mensagem)
        {
            this.Origem = origem;
            this.Destino = destino;
            this.Assunto = assunto;
            this.Mensagem = mensagem;
        }
    }
}
