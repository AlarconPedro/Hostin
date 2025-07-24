import 'package:flutter/material.dart';

class SelectModulos extends StatefulWidget {
  const SelectModulos({super.key});

  @override
  State<SelectModulos> createState() => _SelectModulosState();
}

class _SelectModulosState extends State<SelectModulos> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Seleção de Módulos')),
      body: Center(
        child: Text('Selecione os módulos desejados para continuar.'),
      ),
    );
  }
}
