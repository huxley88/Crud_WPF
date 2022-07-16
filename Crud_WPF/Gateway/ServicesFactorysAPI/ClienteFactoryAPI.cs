namespace Crud_WPF.Gateway.ServicesFactorysAPI
{
    public class ClienteFactoryAPI : ServiceFactoryAPI
    {
        public override void RenomearController()
        {
            _NomeControllerAPI = "Cliente";
        }

        public string ObterTodos()
        {
            return $"{RotaAPI()}";
        }
        public string ObterPorId(int id)
        {
            return $"{RotaAPI()}/id/{id}";
        }
        public string ObterPorCpf(string cpf)
        {
            return $"{RotaAPI()}/cpf/{cpf}";
        }
        public string Incluir()
        {
            return $"{RotaAPI()}/incluir";
        }
        public string Alterar()
        {
            return $"{RotaAPI()}/alterar";
        }
        public string Excluir()
        {
            return $"{RotaAPI()}/excluir";
        }

    }
}
