using Crud_WPF.DTO.Cliente;
using CsvHelper.Configuration;

namespace Teste_Wipro_Moeda.Mapper
{
    public class ClienteImportacaoMap : ClassMap<ClienteDTO>
    {
        public ClienteImportacaoMap()
        {
            Map(m => m.Nome).Name("Nome");
            Map(m => m.Telefone).Name("Telefone");
            Map(m => m.Sexo).Name("Sexo");
            Map(m => m.Cpf).Name("Cpf");
            Map(m => m.Aniversario).Name("Aniversario");
            Map(m => m.Pais).Name("Pais");
            Map(m => m.Cep).Name("Cep");
            Map(m => m.Cidade).Name("Cidade");
            Map(m => m.Bairro).Name("Bairro");
            Map(m => m.Rua).Name("Rua");
            Map(m => m.Numero).Name("Numero");
        }
    }
}
