class Config {
  int _moduloSelecionado = 0;
  int _empresaSelecionada = 0;
  int _usuarioSelecionado = 0;

  void reset() {
    _moduloSelecionado = 0;
    _empresaSelecionada = 0;
    _usuarioSelecionado = 0;
  }

  void setModuloSelecionado(int modulo) {
    _moduloSelecionado = modulo;
  }

  void setEmpresaSelecionada(int empresa) {
    _empresaSelecionada = empresa;
  }

  void setUsuarioSelecionado(int usuario) {
    _usuarioSelecionado = usuario;
  }

  bool get isModuloSelecionado => _moduloSelecionado > 0;
  bool get isEmpresaSelecionada => _empresaSelecionada > 0;
  bool get isUsuarioSelecionado => _usuarioSelecionado > 0;

  bool get isConfiguracaoCompleta =>
      isModuloSelecionado && isEmpresaSelecionada && isUsuarioSelecionado;
}
