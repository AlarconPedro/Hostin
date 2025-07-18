import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:painel_hostin/widgets/widgets.dart';

import '../classes/classes.dart';

class LoginPage extends StatefulWidget {
  const LoginPage({super.key});

  @override
  State<LoginPage> createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  late PageController _pageController;

  GlobalKey<FormState> key = GlobalKey<FormState>();
  TextEditingController emailController = TextEditingController();
  TextEditingController passwordController = TextEditingController();
  String errorMessage = '';
  String successMessage = '';
  bool carregando = false;

  @override
  void initState() {
    super.initState();
    _pageController = PageController();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: Container(
          width: 450,
          height: 450,
          decoration: const BoxDecoration(
            color: Cores.branco,
            borderRadius: BorderRadius.all(Radius.circular(10)),
            boxShadow: [
              BoxShadow(
                color: Colors.black12,
                blurRadius: 10,
                offset: Offset(0, 5),
              ),
            ],
          ),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Container(
                margin: const EdgeInsets.only(top: 25),
                height: 100,
                decoration: const BoxDecoration(
                  image: DecorationImage(image: AssetImage('images/logo.png')),
                ),
              ),
              Container(
                margin: const EdgeInsets.symmetric(horizontal: 25, vertical: 5),
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Form(
                      key: key,
                      // autovalidateMode: AutovalidateMode.onUserInteraction,
                      child: Column(
                        children: [
                          campoTexto(
                            controller: emailController,
                            labelText: 'E-mail',
                            hintText: 'Digite seu e-mail',
                            validator: (value) {
                              if (value == null ||
                                  value.isEmpty ||
                                  !value.contains('@') ||
                                  !value.contains('.') ||
                                  !value.contains('com') ||
                                  value.length < 10) {
                                return 'Por favor, digite seu e-mail';
                              }
                              return "";
                            },
                          ),
                          const SizedBox(height: 10),
                          campoTexto(
                            controller: passwordController,
                            labelText: 'Senha',
                            hintText: 'Digite sua senha',
                            prefixIcon: Icons.lock,
                            obscureText: true,
                            validator: (value) {
                              if (value == null ||
                                  value.isEmpty ||
                                  value.length < 6) {
                                return 'Por favor, digite uma senha válida';
                              }
                              return "";
                            },
                          ),
                        ],
                      ),
                    ),
                    const SizedBox(height: 10),
                    Text(
                      errorMessage,
                      style: const TextStyle(color: Colors.red),
                    ),
                    Text(
                      successMessage,
                      style: const TextStyle(color: Colors.green),
                    ),
                  ],
                ),
              ),
              Padding(
                padding: const EdgeInsets.symmetric(horizontal: 10),
                child: ElevatedButton(
                  onPressed: () async {
                    // TextInput.finishAutofillContext();
                    if (key.currentState!.validate()) {
                      successMessage = 'Logando...';
                      //   // setState(() => carregando = true);
                      //   FirebaseAuth.instance
                      //       .signInWithEmailAndPassword(
                      //         email: emailController.text,
                      //         password: passwordController.text,
                      //       )
                      //       .then((value) async {
                      //         var retorno = await verificaLogin();
                      //         if (retorno != "") {
                      //           await logar(await FirebaseAPI.getUID() ?? "");
                      //         }
                      //       })
                      // .catchError((error) {
                      //   errorMessage =
                      //       'Erro ao autenticar usuário, verifique e-mail e senha e tente novamente';
                      // });
                    } else {
                      errorMessage =
                          'Por favor, preencha todos os campos corretamente';
                    }
                  },
                  style: ElevatedButton.styleFrom(
                    foregroundColor: Colors.white,
                    backgroundColor: Cores.verdeEscuro,
                    fixedSize: const Size(150, 40),
                    shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(10),
                    ),
                  ),
                  child:
                      carregando
                          ? const CupertinoActivityIndicator(
                            color: Cores.branco,
                          )
                          : const Text('Logar'),
                ),
              ),
              TextButton(
                style: TextButton.styleFrom(foregroundColor: Cores.cinzaEscuro),
                onPressed: () {
                  if (emailController.text.isEmpty) {
                    // setState(() {
                    errorMessage = 'Por favor, digite seu e-mail';
                    // });
                  }
                  // esqueceuSenha();
                },
                onHover: (value) {},
                child: const Text('Esqueceu a senha?'),
              ),
              const SizedBox(height: 20),
            ],
          ),
        ),
      ),
    );
  }
}
