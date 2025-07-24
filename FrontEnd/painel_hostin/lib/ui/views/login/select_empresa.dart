import 'package:flutter/material.dart';

class SelectEmpresa extends StatefulWidget {
  const SelectEmpresa({super.key});

  @override
  State<SelectEmpresa> createState() => _SelectEmpresaState();
}

class _SelectEmpresaState extends State<SelectEmpresa> {
  @override
  Widget build(BuildContext context) {
    return Container(
      child: Center(
        child: Text('Selecione a empresa desejada para continuar.'),
      ),
    );
  }
}
