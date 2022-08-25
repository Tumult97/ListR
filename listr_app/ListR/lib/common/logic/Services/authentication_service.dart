import 'dart:async';
import 'dart:convert';
import 'package:listr/common/logic/Connection/api.dart' as api;
import 'package:listr/common/Constants/ApiEndpoints/auth_endpoints_constant.dart' as constants;
import 'package:listr/common/models/Requests/login_model.dart';
import 'package:listr/common/models/Responses/login_response_model.dart';
import 'package:shared_preferences/shared_preferences.dart';

class AuthenticationService{

  static Future<bool> login(String username, String password) async {
    final prefs = await SharedPreferences.getInstance();

    var request = LoginModel(username: username, password: password);
    var response = await api.Api().postAsync(constants.AuthEndpointConstants.login, request);

    LoginResponseModel responseBody = LoginResponseModel();
    if(response.success && response.body!.isNotEmpty){
      responseBody = LoginResponseModel.fromJson(jsonDecode(response.body!));
      prefs.setString('', responseBody.token!);
    }

    return response.success;
  }

  Future register(
      String userName,
      String email,
      String firstName,
      String lastName,
      String password) async {
    //final prefs = await SharedPreferences.getInstance();
    //var bearerToken = prefs.getString('BearerHeader');

  }
}