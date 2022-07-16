using System;
using System.Collections.Generic;

namespace Crud_WPF.DTO.Cliente
{
    public class ClienteFiltroDTO
    {

        #region Propriedades
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public char Sexo { get; set; }
        public DateTime Aniversario { get; set; }
        public List<ClienteDTO> ListaExcluir { get; set; }
        #endregion

    }
}
