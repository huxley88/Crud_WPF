using Crud_WPF.DTO.Generico;
using System;
using System.Collections.Generic;

namespace DS.USE.Gateway.HttpClientBase.Classes.RetornosRequisicoesAPI
{
    public class RetornoRequisicaoAPIDTO<TRetorno> where TRetorno : class
    {
        public TRetorno retornoRequisicoAPI { get; set; }

        public bool retornoRequisicaoSucesso;

        public string MensagemErro { get; set; }
    }
}
