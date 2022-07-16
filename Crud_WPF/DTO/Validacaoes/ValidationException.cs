using System;

namespace Crud_WPF.DTO.Validacaoes
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        { }
    }
}
