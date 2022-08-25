import 'package:flutter/material.dart';
import 'package:listr/common/logic/Services/authentication_service.dart';

class LoginPage extends StatefulWidget {
  const LoginPage({Key? key}) : super(key: key);

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


  _LoginPageState(){
    username = '';
    password = '';
  }

  void login() async {
    if(!(_formKey.currentState!.validate())){
      return;
    }

    var success = await AuthenticationService.login(username, password);
    setState(()  {
      if (!(success)) {
        loginValid = false;
      }

      loginValid = true;
    });
  }

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;

    return Scaffold(
      resizeToAvoidBottomInset: false,
      body: Center(
        child: SizedBox(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              const Expanded(
                flex: 1,
                child: Text(''),
              ),
              Expanded(
                flex: 2,
                child: Card(
                  child: Expanded(
                    child: SizedBox(
                      width: size.width * 0.9,
                      child: Padding(
                        padding: const EdgeInsets.all(20.0),
                        child: buildLoginPage(_formKey),
                      ),
                    ),
                  ),
                ),
              ),
              const Expanded(
                flex: 1,
                child: Text(''),
              ),
            ],
          ),
        ),
      )
    );
  }

  Widget buildLoginPage(GlobalKey<FormState> key){

    Size size = MediaQuery.of(context).size;

    Form form = Form(
      key: key,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          const Expanded(
            flex: 1,
            child: SizedBox.shrink(),
          ),
          Expanded(
            flex: 2,
            child: Column(
              mainAxisAlignment: MainAxisAlignment.end,
              children: [
                Padding(
                  padding: const EdgeInsets.fromLTRB(20, 0, 20, 20),
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
                  onPressed: (isPasswordValid && isUsernameValid) ? login : null,
                  child: const Text(
                    "LOGIN",
                    style: TextStyle(color: Colors.white),
                  ),
                )
              ],
            ),
          )
        ],
      ),
    );

    return form;
  }
}
