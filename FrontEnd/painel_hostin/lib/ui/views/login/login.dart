import 'package:flutter/material.dart';

import 'select_empresa.dart';
import 'login_page.dart';
import 'select_modulos.dart';

class Login extends StatefulWidget {
  const Login({super.key});

  @override
  State<Login> createState() => _LoginState();
}

class _LoginState extends State<Login> {
  final PageController _pageController = PageController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: PageView(
        physics: const NeverScrollableScrollPhysics(),
        controller: _pageController,
        children: [LoginPage(), SelectEmpresa(), SelectModulos()],
      ),
    );
  }
}
