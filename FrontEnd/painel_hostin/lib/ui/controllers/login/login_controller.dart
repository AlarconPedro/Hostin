import 'package:flutter/widgets.dart';

import '../../../di/di_controllers.dart';
import '../config.dart';
// import 'package:painel_hostin/ui/controllers/controllers.dart';

class LoginController {
  final config = getIt<Config>();

  final PageController pageController = PageController();

  void dispose() {
    pageController.dispose();
  }

  int get currentPage => pageController.page?.round() ?? 0;

  void nextPage() {
    if (pageController.hasClients) {
      pageController.nextPage(
        duration: const Duration(milliseconds: 300),
        curve: Curves.easeInOut,
      );
    }
  }

  void previousPage() {
    if (pageController.hasClients) {
      pageController.previousPage(
        duration: const Duration(milliseconds: 300),
        curve: Curves.easeInOut,
      );
    }
  }

  // Selecionar módulo, empresa ou usuário
  void selectModulo(int modulo) {
    config.setModuloSelecionado(modulo);
    nextPage();
  }

  void selectEmpresa(int empresa) {
    config.setEmpresaSelecionada(empresa);
    nextPage();
  }

  void selectUsuario(int usuario) {
    config.setUsuarioSelecionado(usuario);
    nextPage();
  }
}
