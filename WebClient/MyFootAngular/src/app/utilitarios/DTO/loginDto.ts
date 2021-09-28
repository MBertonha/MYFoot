export interface LoginResponse {
    seqLogin: number,
    emailLogin: string,
    tipoUsuario: number,
    habilitado: boolean,
    mensagemErro: string
}