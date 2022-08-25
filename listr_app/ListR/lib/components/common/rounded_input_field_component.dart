// ignore_for_file: must_be_immutable

import 'package:flutter/material.dart';

class RoundedInputFieldComponent extends StatelessWidget {
  final String hintText;
  final IconData icon;
  final ValueChanged<String>? onChanged;
  final String text;
  Color? color;
  RoundedInputFieldComponent({
    Key? key,
    this.hintText = "",
    this.icon = Icons.verified_user,
    this.onChanged,
    required this.text,
    this.color
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;
    TextEditingController txtController = TextEditingController();
    txtController.text = text;

    color ??= Theme.of(context).colorScheme.primary;

    return Container(
      margin: const EdgeInsets.fromLTRB(0.0, 10.0, 0.0, 5.0),
      padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 5),
      width: size.width * 0.8,
      decoration: BoxDecoration(
        border: Border.all(color: (color)!),
        borderRadius: BorderRadius.circular(29),
      ),
      child: TextField(
        controller: txtController,
        onChanged: onChanged,
        cursorColor: color,
        decoration: InputDecoration(
          icon: Icon(
            icon,
            color: color,
          ),
          hintText: hintText,
          border: InputBorder.none,
        ),
      ),
    );
  }
}