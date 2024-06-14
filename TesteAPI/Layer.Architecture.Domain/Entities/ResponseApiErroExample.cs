namespace Layer.Architecture.Domain.Entities
{
    public class ResponseApiErroExample
    {
        public ResponseErro GetExamples()
        {
            return new ResponseErro
            {
                Sucesso = false,
                Erros = new string[]
               {
                   "Erro ao processar requisição",
                   "Insira um valor válido"
               }
            };
        }
    }
}
