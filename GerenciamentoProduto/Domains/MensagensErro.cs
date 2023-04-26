namespace GerenciamentoProduto.Domains
{
    public static class MensagensErro
    {
        public static string OCampoNaoDeveSerVazio => "O campo {PropertyName} não deve ser vazio(a)";
        public static string OCampoNaoDeveSerNulo => "O campo {PropertyName} não deve ser nulo(a)";
        public static string OCampoDeveSerMaiorQue => "O campo {PropertyName} deve ser maior que {ComparisonValue}";
        public static string NaoEncontrado => "O dado não foi encontrado";
        public static string NaoAdicionado => "O dado não foi adicionado";

    }
}
