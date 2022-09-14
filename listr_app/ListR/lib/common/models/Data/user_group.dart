import 'package:listr/common/models/Data/shop_list.dart';
import 'package:listr/common/models/Data/user_model.dart';

class UserGroup {
  int? id;
  String? name;
  String? userCreatedBy;
  List<UserModel>? users;
  List<ShopList>? lists;
  List<String>? userIds;
  bool? isCreator;

  UserGroup(
      {this.id,
      this.name,
      this.userCreatedBy,
      this.users,
      this.lists,
      this.userIds,
      this.isCreator});

  UserGroup.fromJson(Map<String, dynamic> json){
    id = json['id'];
    name = json['name'];
    userCreatedBy = json['userCreatedBy'];
    userIds = json['userIds'];
    isCreator = json['isCreator'];

    lists = <ShopList>[];
    for (var element in (json['lists'] as List<dynamic>)) {
      lists?.add(ShopList.fromJson(element));
    }

    users = <UserModel>[];
    for (var element in (json['users'] as List<dynamic>)) {
      users?.add(UserModel.fromJson(element));
    }
  }



  Map<String, dynamic> toJson(){
    final Map<String, dynamic> data = <String, dynamic>{};
    data['id'] = id;
    data['name'] = name;
    data['userCreatedBy'] = userCreatedBy;
    data['users'] = users;
    data['lists'] = lists;
    data['userIds'] = userIds;
    data['isCreator'] = isCreator;
    return data;
  }
}