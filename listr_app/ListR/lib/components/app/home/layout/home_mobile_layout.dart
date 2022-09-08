import 'package:flutter/material.dart';
import 'package:listr/common/models/Data/user_group.dart';

import '../../../../common/models/Data/shop_list.dart';

// ignore: must_be_immutable
class HomeMobileLayout extends StatelessWidget {
  HomeMobileLayout({Key? key}) : super(key: key);

  List<UserGroup> userGroups = <UserGroup>[
    UserGroup(
      name: 'B & T',
      lists: <ShopList>[
        ShopList(

        )
      ],
    ),
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.purple[300],
    );
  }
}
