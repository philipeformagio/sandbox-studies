namespace DevIO.Api.Extensions
{
    public class AppSettings
    {
        public string Secret { get; set; } //chave de criptografia
        public int ExpiracaoHoras { get; set; } //quantas horas até o token perder a validade
        public string Emissor { get; set; } //quem emite, no caso a aplicacao
        public string ValidoEm { get; set; } //em quais URLs esse token é valido
    }
}
