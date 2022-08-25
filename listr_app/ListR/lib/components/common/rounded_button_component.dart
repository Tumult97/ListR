import 'package:flutter/material.dart';

// ignore: must_be_immutable
class RoundedButtonComponent extends StatelessWidget {
  final String text;
  final VoidCallback? onPress;
  Color? color;
  final Color textColor;
  RoundedButtonComponent({
    Key? key,
    required this.text,
    this.onPress,
    this.color,
    required this.textColor,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;
    color ??= Theme.of(context).colorScheme.primary;

    return Container(
      margin: const EdgeInsets.symmetric(vertical: 10),
      width: size.width * 0.8,
      child: ClipRRect(
        borderRadius: BorderRadius.circular(29),
        child: TextButton(
          style: ButtonStyle(
            padding: MaterialStateProperty.all<EdgeInsets>(const EdgeInsets.symmetric(vertical: 20, horizontal: 40)),
            backgroundColor: MaterialStateProperty.all<Color>((color)!),
            splashFactory: InkRipple.splashFactory
          ),
          onPressed: onPress,
          child: Text(
            text,
            style: TextStyle(color: textColor),
          ),
        ),
      ),
    );
  }
}