import 'package:flutter/material.dart';

import '../classes/classes.dart';

TextFormField campoTexto({
  required TextEditingController controller,
  required String labelText,
  required String hintText,
  required String Function(String?)? validator,
  TextInputType keyboardType = TextInputType.text,
  TextInputAction textInputAction = TextInputAction.done,
  List<String> autofillHints = const [AutofillHints.email],
  bool obscureText = false,
  bool enabled = true,
  bool enableSuggestions = true,
  bool autocorrect = true,
  Color corPrimaria = Cores.cinzaEscuro,
  IconData prefixIcon = Icons.email,
}) {
  return TextFormField(
    controller: controller,
    keyboardType: keyboardType,
    textInputAction: textInputAction,
    enableSuggestions: enableSuggestions,
    autocorrect: autocorrect,
    autofillHints: autofillHints,
    obscureText: obscureText,
    decoration: InputDecoration(
      labelText: labelText,
      enabledBorder: OutlineInputBorder(
        borderSide: BorderSide(color: corPrimaria),
      ),
      labelStyle: TextStyle(color: corPrimaria),
      focusedBorder: OutlineInputBorder(
        borderSide: BorderSide(color: corPrimaria),
      ),
      errorBorder: OutlineInputBorder(
        borderSide: BorderSide(color: Colors.red),
      ),
      border: OutlineInputBorder(borderSide: BorderSide(color: corPrimaria)),
      focusColor: corPrimaria,
      hintStyle: TextStyle(color: corPrimaria),
      hintText: hintText,
      counterStyle: TextStyle(color: corPrimaria),
      prefixIcon: Icon(prefixIcon, color: corPrimaria),
    ),
    validator: (value) {
      if (validator != null) {
        return validator(value);
      }
      return null;
      // if (value == null ||
      //     value.isEmpty ||
      //     !value.contains('@') ||
      //     !value.contains('.') ||
      //     !value.contains('com') ||
      //     value.length < 10) {
      //   return 'Por favor, digite seu e-mail';
      // }
      // // setState(() {
      // //   _errorMessage = '';
      // //   _suceessMessage = '';
      // // });
      // return null;
    },
  );
}
