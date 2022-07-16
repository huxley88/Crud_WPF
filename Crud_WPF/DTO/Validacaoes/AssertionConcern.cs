namespace Crud_WPF.DTO.Validacaoes
{
    public class AssertionConcern
    {
        public static void ValidarSeVazio(string valor, string mensagem)
        {
            if (valor == null || valor.Trim().Length == 0)
            {
                throw new ValidationException(mensagem);
            }
        }

        public static void ValidarCPF(string cpf, string mensagem)
        {
            if (cpf != null || cpf.Trim().Length > 0)
            {
                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                string tempCpf;
                string digito;
                int soma;
                int resto;

                cpf = cpf.Trim();
                cpf = cpf.Replace(".", "").Replace("-", "");

                if (cpf.Length != 11)
                    throw new ValidationException(mensagem);

                tempCpf = cpf.Substring(0, 9);
                soma = 0;

                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

                resto = soma % 11;

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = resto.ToString();

                tempCpf = tempCpf + digito;

                soma = 0;

                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

                resto = soma % 11;

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = digito + resto.ToString();

                if(!cpf.EndsWith(digito))
                    throw new ValidationException(mensagem);
            }
            else
                throw new ValidationException(mensagem);
        }
    }
}
