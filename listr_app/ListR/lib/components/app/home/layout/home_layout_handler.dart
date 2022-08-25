import 'package:flutter/material.dart';

class HomeLayoutHandler extends StatelessWidget {
  final Widget mobileLayout;
  final Widget desktopLayout;

  HomeLayoutHandler({Key? key, required this.desktopLayout, required this.mobileLayout}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return LayoutBuilder(
      builder: (context, constraints) {
        if (constraints.maxWidth < 600) {
          return mobileLayout;
        } else {
          return desktopLayout;
        }
      },
    );
  }

}
