import 'package:flutter/material.dart';
import 'package:listr/components/App/Authentication/login_page.dart';
import 'package:listr/components/app/home/home_page.dart';
import 'package:listr/common/Constants/app/navigation_routes_constants.dart' as routes;

void main() {

  runApp(MaterialApp(
    debugShowCheckedModeBanner: false,
    initialRoute: '/',
    theme: ThemeData(
      useMaterial3: true,
      colorScheme: ColorScheme.fromSwatch(
          primaryColorDark: Colors.teal[300],
          primarySwatch: Colors.teal,
          accentColor: Colors.teal[700],
          cardColor: Colors.grey[750],
          brightness: Brightness.dark
      ),
    ),
    routes: {
      routes.def: (context) => LoginPage(),
      routes.login: (context) => LoginPage(),
      routes.home: (context) => HomePage()
    },
  ));
}

