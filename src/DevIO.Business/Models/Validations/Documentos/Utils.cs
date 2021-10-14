namespace DevIO.Business.Models.Validations.Documentos
{
    public class Utils
    {
        public static string ApenasNumeros(string value)
        {
            var onlyNumber = "";

            foreach (var s in value)
            {
                if (char.IsDigit(s))
                {
                    onlyNumber += s;
                }
            }

            return onlyNumber.Trim();
        }
    }
}
