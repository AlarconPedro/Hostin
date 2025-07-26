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
          child: const Text('Select Modulos'),
        ),
      ),
    );
  }
}
