import 'package:flutter/material.dart';
import 'package:listr/common/logic/Services/user_group_service.dart';
import 'package:listr/common/models/Data/user_group.dart';
import 'package:listr/components/app/home/layout/home_desktop_layout.dart';
import 'package:listr/components/app/home/layout/home_layout_handler.dart';
import 'package:listr/components/app/home/layout/home_mobile_layout.dart';
import 'package:loading_animation_widget/loading_animation_widget.dart';

class HomePage extends StatelessWidget {
  const HomePage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {

    return FutureBuilder<List<UserGroup>>(
      future: UserGroupService.getUserGroupsByEmail('tristanvdm87@gmail.com'),
      builder: (BuildContext context, AsyncSnapshot<List<UserGroup>> snapshot) {
        if(snapshot.hasData){
          return HomeLayoutHandler(desktopLayout: const HomeDesktopLayout(), mobileLayout: HomeMobileLayout(userGroups: snapshot.data!,));
        }
        else{
          return Center(
            child: LoadingAnimationWidget.inkDrop(
                color: Theme.of(context).colorScheme.primary,
                size: 200
            ),
          );
        }
      },
    );

  }
}
