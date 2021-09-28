using Modelo.Dominio.Modelos.Entidade;

namespace Modelo.Dominio.Entidades
{
    public partial class GE_LOGIN : Entidade<GE_LOGIN>
    {
        #region Variaveis

        public int SeqLogin { get; private set; }
        public string EmailLogin { get; private set; }
        public string Senha { get; private set; }
        public int TipoUsuario { get; private set; }
        public string Ativo { get; private set; }

        #endregion

        public GE_LOGIN(){ }

        public GE_LOGIN(int seqLogin, string emailLogin, string senha, int tipoUsuario, string ativo) 
        {
            SeqLogin = seqLogin;
            EmailLogin = emailLogin ?? "";
            Senha = senha ?? "";
            TipoUsuario = tipoUsuario;
            Ativo = ativo ?? "S";

            //Incluir validações


            Validar(this);
        }

        public override bool EstaValido()
        {
            return ResultadoValidacao.IsValid;
        }
    }
}
