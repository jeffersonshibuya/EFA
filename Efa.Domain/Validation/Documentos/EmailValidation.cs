using System.Text.RegularExpressions;

namespace Efa.Domain.Validation.Documentos
{
    public class EmailValidation
    {
        public static bool Validar(string email)
        {
            return Regex.IsMatch(email, @"\A[a-z0-9]+([-._][a-z0-9]+)*@([a-z0-9]+(-[a-z0-9]+)*\.)+[a-z]{2,4}\z")
                   && Regex.IsMatch(email, @"^(?=.{1,64}@.{4,64}$)(?=.{6,100}$).*");
        }
    }
}
