using System.Collections.Generic;

namespace DevIO.Business.Models.Validations.Documentos
{
    public class DigitoVerificador
    {
        private string _numero;
        private const int _modulo = 11;
        private readonly List<int> _multiplicadores = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9 };
        private readonly IDictionary<int, string> _subtituicoes = new Dictionary<int, string>();
        private bool _complementarDoModulo = true;

        public DigitoVerificador(string numero)
        {
            _numero = numero;
        }

        public DigitoVerificador ComMultiplicadoresDeAte(int primeiroMultiplicador, int ultimoMultiplicador)
        {
            _multiplicadores.Clear();

            for (var i = primeiroMultiplicador; i <= ultimoMultiplicador; i++)
            {
                _multiplicadores.Add(i);
            }

            return this;
        }

        public DigitoVerificador Substituindo(string substituto, params int[] digitos)
        {
            foreach (var i in digitos)
            {
                _subtituicoes[i] = substituto;
            }

            return this;
        }

        public void AddDigito(string digito)
        {
            _numero = string.Concat(_numero, digito);
        }

        public string CalculaDigito()
        {
            return !(_numero.Length > 0) ? "" : GetDigitSum();
        }

        public string GetDigitSum()
        {
            var soma = 0;

            for (int i = _numero.Length - 1, m = 0; i >= 0; i--)
            {
                var produto = (int)char.GetNumericValue(_numero[i]) * _multiplicadores[m];
                soma += produto;

                if (++m >= _multiplicadores.Count)
                {
                    m = 0;
                }
            }

            var mod = (soma % _modulo);
            var resultado = _complementarDoModulo ? _modulo - mod : mod;

            return _subtituicoes.ContainsKey(resultado) ? _subtituicoes[resultado] : resultado.ToString();
        }
    }
}
