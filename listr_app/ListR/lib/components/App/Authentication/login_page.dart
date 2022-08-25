import 'package:flutter/material.dart';
import 'package:listr/common/logic/Services/authentication_service.dart';
import 'package:listr/components/common/rounded_input_field_component.dart';
import 'package:listr/components/common/rounded_password_field_component.dart';
import 'package:flutter/services.dart';

class LoginPage extends StatefulWidget {
  const LoginPage({Key? key}) : super(key: key);

  @override
  State<LoginPage> createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {

  String username = '';
  String password = '';
  bool loginValid = true;
  bool isUsernameValid = false;
  bool isPasswordValid = false;


  _LoginPageState(){
    username = '';
    password = '';
  }

  void login() async {
    var success = await AuthenticationService.login(username, password);
    setState(()  {
      if (!(success)) {
        loginValid = false;
      }

      loginValid = true;
    });
  }

  void checkFormValidity() {
    setState(() {
      isUsernameValid = username.isNotEmpty;
      isPasswordValid = password.isNotEmpty;
    });
  }

  @override
  Widget build(BuildContext context) {

    return Scaffold(
      resizeToAvoidBottomInset: false,
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            Card(
              child: Padding(
                padding: EdgeInsets.all(20.0),
                child: Column(
                  children: buildLoginPage(),
                ),
              ),
            )
          ],
        ),
      )
    );
  }

  List<Widget> buildLoginPage(){
    List<Widget> form = [];

    form = [
      const SizedBox(
        height: 10.0,
      ),
      RoundedInputFieldComponent(
        text: "",
        hintText: "Username / Email",
        onChanged: (value) {
          username = value;
          checkFormValidity();
        },
      ),
      const SizedBox(
        height: 10.0,
      ),
      RoundedPasswordFieldComponent(
        onChanged: (value) {
          password = value;
          checkFormValidity();
        },
      ),
      const SizedBox(
        height: 30.0,
      ),
      Visibility(
        visible: !loginValid,
        child: const Center(
          child: Text(
              "Invalid Username/Password combination. Please try again."
          ),
        ),
      ),
      TextButton(
        style: ButtonStyle(
          padding: MaterialStateProperty.all<EdgeInsets>(const EdgeInsets.symmetric(vertical: 20, horizontal: 40)),
          backgroundColor: MaterialStateProperty.all<Color>(Theme.of(context).colorScheme.primary),
          splashFactory: InkRipple.splashFactory,
        ),
        onPressed: (isPasswordValid && isUsernameValid) ? login : null,
        child: const Text(
          "LOGIN",
          style: TextStyle(color: Colors.white),
        ),
      )
    ];

    return form;
  }
}
