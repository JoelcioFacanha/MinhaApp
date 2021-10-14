using System;
using System.Linq;

namespace DevIO.Business.Models.Validations.Documentos
{
    public class CnpjValidacao
    {
        public const int TamanhoCNPJ = 14;

        public static bool Validar(string documento)
        {
            var cnpjNumeros = Utils.ApenasNumeros(documento);

            if (!TamanhoValido(documento))
            {
                return false;
            }

            return !TemDigitosRepetidos(cnpjNumeros) && TemDigitosValidos(cnpjNumeros);
        }

        private static bool TamanhoValido(string documento)
        {
            return documento.Length == TamanhoCPF;
        }

        private static bool TemDigitosRepetidos(string documento)
        {
            string[] invalidNumbers =
            {
                "00000000000000",
                "11111111111111",
                "22222222222222",
                "33333333333333",
                "44444444444444",
                "55555555555555",
                "66666666666666",
                "77777777777777",
                "88888888888888",
                "99999999999999"
            };

            return invalidNumbers.Contains(documento);
        }

        private static bool TemDigitosValidos(string documento)
        {
            var number = documento.Substring(0, TamanhoCNPJ - 2);
            var digitoVerificador = new DigitoVerificador(number)
                .ComMultiplicadoresDeAte(2, 11)
                .Substituindo("0", 10, 11);

            var firstDigit = digitoVerificador.CalculaDigito();
            digitoVerificador.AddDigito(firstDigit);
            var secondDigit = digitoVerificador.CalculaDigito();

            return string.Concat(firstDigit, secondDigit) == documento.Substring(TamanhoCNPJ - 2, 2);

        }
    }
}
