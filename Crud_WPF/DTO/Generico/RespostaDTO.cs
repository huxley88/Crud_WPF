namespace Crud_WPF.DTO.Generico
{
    public class RespostaDTO
    {
        public bool IsSucess { get; set; }
        public int StatusCode { get; set; }
        public string Mensagem { get; set; }
        public int InternalStatusCode { get; set; }
        public string ErrorLocation { get; set; }

        public RespostaDTO()
        {
            this.IsSucess = true;
            this.StatusCode = 200;            
            this.InternalStatusCode = 1;
        }

        public RespostaDTO(bool sucess, int internalStatus = 1, string errorLocation = "")
        {
            Construtor(sucess, internalStatus, errorLocation);
        }

        public void Construtor(bool sucess, int internalStatus = 1, string errorLocation = "")
        {
            this.IsSucess = sucess;

            if (sucess)
            {
                this.StatusCode = 200;
                this.InternalStatusCode = internalStatus;
            }
            else
            {
                this.StatusCode = 400;
                this.ErrorLocation = errorLocation;
                this.InternalStatusCode = internalStatus;
            }
        }
    }
}
