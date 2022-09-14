import 'dart:async';
import 'dart:convert';
import 'package:listr/common/logic/Connection/api.dart' as api;
import 'package:listr/common/Constants/ApiEndpoints/user_group_endpoints_constants.dart' as constants;
import 'package:listr/common/models/Data/user_group.dart';
import 'package:listr/common/models/Responses/login_response_model.dart';
import 'package:shared_preferences/shared_preferences.dart';

class UserGroupService{

  static Future<List<UserGroup>> getUserGroupsByEmail(String email) async {
    final prefs = await SharedPreferences.getInstance();

    var response = await api.Api().getAsync(constants.userGroupGetByEmail + email);

    List<UserGroup> responseBody = <UserGroup>[];
    if(response.success && response.body!.isNotEmpty){
      List<dynamic> jsonBody = jsonDecode(response.body!);
      for (var element in jsonBody) {
        responseBody.add(UserGroup.fromJson(element));
      }
    }

    return responseBody;
  }
}