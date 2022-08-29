import 'dart:io';

import 'package:desktop_window/desktop_window.dart';
import 'package:flutter/material.dart';
import 'package:listr/common/logic/Services/authentication_service.dart';
import 'package:loading_animation_widget/loading_animation_widget.dart';
import 'package:toast/toast.dart';
import 'package:listr/common/Constants/app/navigation_routes_constants.dart' as routes;

class LoginPage extends StatefulWidget {
  LoginPage({Key? key}) : super(key: key) {
    WidgetsFlutterBinding.ensureInitialized();

    if (Platform.isMacOS || Platform.isWindows || Platform.isLinux){
      print('Benis');
      DesktopWindow.setWindowSize(Size(600.0, 600.0));
      DesktopWindow.setMinWindowSize(Size(450.0, 600.0));
    }
  }

  @override
  State<LoginPage> createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {

  String username = '';
  String password = '';
  bool loginValid = true;
  bool isUsernameValid = true;
  bool isPasswordValid = true;
  final _formKey = GlobalKey<FormState>();
  bool isLoading = false;

  _LoginPageState(){
    username = '';
    password = '';
  }

  void login(NavigatorState navigator) async {
    if(!(_formKey.currentState!.validate())){
      return;
    }

    setState(() {
      isLoading = true;
    });

    var success = await AuthenticationService.login(username, password);
    setState(() {
      isLoading = false;
    });
    if (!(success)) {
      Toast.show('Login Failed. PLease Try again.', duration: 3, gravity: 5);
      return;
    }

    navigator.pushReplacementNamed(routes.home);
  }

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;

    var body = Center(
      child: SizedBox(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            Card(
              child: SizedBox(
                width: size.width * 0.9,
                child: Padding(
                  padding: const EdgeInsets.all(20.0),
                  child: buildLoginPage(_formKey),
                ),
              ),
            )
          ],
        ),
      ),
    );

    var loading = Center(
      child: LoadingAnimationWidget.inkDrop(
          color: Theme.of(context).colorScheme.primary,
          size: 200
      ),
    );

    return Scaffold(
      resizeToAvoidBottomInset: false,
      body: isLoading ? loading : body
    );
  }

  Widget buildLoginPage(GlobalKey<FormState> key){

    NavigatorState navigator = Navigator.of(context);

    Form form = Form(
      key: key,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          Column(
            mainAxisAlignment: MainAxisAlignment.end,
            children: [
              Padding(
                padding: const EdgeInsets.fromLTRB(20, 20, 20, 20),
                child: TextFormField(
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Please enter your username / email';
                    }
                    return null;
                  },
                  decoration: const InputDecoration(
                      border: OutlineInputBorder(),
                      hintText: 'Username / Email',
                      icon: Icon(Icons.verified_user)
                  ),
                  onChanged: (value) {
                    username = value;
                  },
                ),
              ),
              Padding(
                padding: const EdgeInsets.fromLTRB(20, 0, 20, 30),
                child: TextFormField(
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Please enter your password';
                    }
                    return null;
                  },
                  decoration: const InputDecoration(
                    border: OutlineInputBorder(),
                    hintText: 'Password',
                    icon: Icon(Icons.lock),
                  ),
                  obscureText: true,
                  onChanged: (value) {
                    password = value;
                  },
                ),
              ),
              TextButton(
                style: ButtonStyle(
                  padding: MaterialStateProperty.all<EdgeInsets>(const EdgeInsets.symmetric(vertical: 20, horizontal: 40)),
                  backgroundColor: MaterialStateProperty.all<Color>(Theme.of(context).colorScheme.primary),
                  splashFactory: InkRipple.splashFactory,
                ),
                onPressed: (isPasswordValid && isUsernameValid) ? () { login(navigator); } : null,
                child: const Text(
                  'LOGIN',
                  style: TextStyle(color: Colors.white),
                ),
              )
            ],
          )
        ],
      ),
    );

    return form;
  }
}
