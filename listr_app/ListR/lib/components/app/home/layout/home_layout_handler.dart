import 'package:flutter/material.dart';
import '../../../../common/models/Data/user_group.dart';

// ignore: must_be_immutable
class HomeLayoutHandler extends StatelessWidget {
  final Widget mobileLayout;
  final Widget desktopLayout;

  HomeLayoutHandler({Key? key, required this.desktopLayout, required this.mobileLayout}) : super(key: key);
  List<UserGroup> userGroups = <UserGroup>[];

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
