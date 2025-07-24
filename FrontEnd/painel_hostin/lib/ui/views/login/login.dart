import 'package:flutter/material.dart';
import 'package:painel_hostin/di/di_controllers.dart';

import '../../controllers/controllers.dart';
import 'select_empresa.dart';
import 'login_page.dart';
import 'select_modulos.dart';

class Login extends StatelessWidget {
  Login({super.key});

  final loginController = getIt<LoginController>();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: PageView(
        physics: const NeverScrollableScrollPhysics(),
        controller: loginController.pageController,
        children: [LoginPage(), SelectEmpresa(), SelectModulos()],
      ),
    );
  }
}
