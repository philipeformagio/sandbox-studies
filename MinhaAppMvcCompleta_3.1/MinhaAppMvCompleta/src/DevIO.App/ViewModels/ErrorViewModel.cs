using System;

namespace DevIO.App.ViewModels
{
    public class ErrorViewModel
    {
        public string Mensagem { get; internal set; }
        public string Titulo { get; internal set; }
        public int ErrorCode { get; internal set; }
    }
}
