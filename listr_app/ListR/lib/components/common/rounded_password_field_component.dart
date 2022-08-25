import 'package:flutter/material.dart';

// ignore: must_be_immutable
class RoundedPasswordFieldComponent extends StatelessWidget {
  final ValueChanged<String>? onChanged;
  Color? color;

  RoundedPasswordFieldComponent({
    Key? key,
    this.onChanged,
    this.color
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;
    color ??= Theme.of(context).colorScheme.primary;

    return Container(
      margin: const EdgeInsets.symmetric(vertical: 5),
      padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 5),
      width: size.width * 0.8,
      decoration: BoxDecoration(
        border: Border.all(color: (color)!),
        borderRadius: BorderRadius.circular(29),
      ),
      child: TextField(
        onSubmitted: onChanged,
        obscureText: true,
        keyboardType: TextInputType.text,
        onChanged: onChanged,
        cursorColor: color,
        decoration: InputDecoration(
          icon: Icon(
            Icons.lock,
            color: color,
          ),
          hintText: "Password",
          border: InputBorder.none,
        ),
      ),
    );
  }
}