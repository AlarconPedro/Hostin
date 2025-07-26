import 'package:flutter/material.dart';

class SelectEmpresa extends StatefulWidget {
  const SelectEmpresa({super.key});

  @override
  State<SelectEmpresa> createState() => _SelectEmpresaState();
}

class _SelectEmpresaState extends State<SelectEmpresa> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: Container(
          width: 450,
          height: 450,
          decoration: BoxDecoration(
            color: Colors.white,
            borderRadius: const BorderRadius.all(Radius.circular(10)),
            boxShadow: [
              BoxShadow(
                color: Colors.black12,
                blurRadius: 10,
                offset: const Offset(0, 5),
              ),
            ],
          ),
          child: const Text('Select Empresa'),
        ),
      ),
    );
  }
}
