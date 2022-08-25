import 'package:flutter/material.dart';
import 'package:listr/components/App/Authentication/login_page.dart';
import 'package:listr/components/app/home/home_page.dart';

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
      '/': (context) => const HomePage(),
    },
  ));
}

