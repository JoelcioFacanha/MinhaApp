using System;
using System.Linq;

namespace DevIO.Business.Models.Validations.Documentos
{
    public class CpfValidacao
    {
        public const int TamanhoCPF = 11;

        public static bool Validar(string documento)
        {
            var cpfNumeros = Utils.ApenasNumeros(documento);

            if (!TamanhoValido(cpfNumeros))
            {
                return false;
            }

            return !TemDigitosRepetidos(cpfNumeros) && TemDigitosValidos(cpfNumeros);
        }

        private static bool TamanhoValido(string documento)
        {
            return documento.Length == TamanhoCPF;
        }

        private static bool TemDigitosRepetidos(string documento)
        {
            string[] invalidNumbers =
            {
                "00000000000",
                "11111111111",
                "22222222222",
                "33333333333",
                "44444444444",
                "55555555555",
                "66666666666",
                "77777777777",
                "88888888888",
                "99999999999"
            };

            return invalidNumbers.Contains(documento);
        }

        private static bool TemDigitosValidos(string documento)
        {
            var number = documento.Substring(0, TamanhoCPF - 2);
            var digitoVerificador = new DigitoVerificador(number)
                .ComMultiplicadoresDeAte(2, 11)
                .Substituindo("0", 10, 11);

            var firstDigit = digitoVerificador.CalculaDigito();
            digitoVerificador.AddDigito(firstDigit);
            var secondDigit = digitoVerificador.CalculaDigito();

            return string.Concat(firstDigit, secondDigit) == documento.Substring(TamanhoCPF - 2, 2);

        }
    }


}
