import 'package:listr/common/models/Data/list_item.dart';

class ShopList {
  int? id;
  String? name;
  String? color;
  bool? isDeleted;
  bool? isCompleted;
  DateTime? dateCreated;
  DateTime? dateModified;
  String? userCreatedBy;
  int? userGroupId;
  DateTime? dateCompleted;
  List<ListItem>? listItems;

  ShopList(
      {this.id,
      this.name,
      this.color,
      this.isDeleted,
      this.isCompleted,
      this.dateCreated,
      this.dateModified,
      this.userCreatedBy,
      this.userGroupId,
      this.dateCompleted,
      this.listItems});

  ShopList.fromJson(Map<String, dynamic> json){
    id = json['id'];
    name = json['name'];
    color = json['color'];
    isDeleted = json['isDeleted'];
    isCompleted = json['isCompleted'];
    dateCreated = DateTime.tryParse(json['dateCreated']);
    dateModified = DateTime.tryParse(json['dateModified']);
    userCreatedBy = json['userCreatedBy'];
    userGroupId = json['userGroupId'];
    dateCompleted = DateTime.tryParse(json['dateCompleted']);
    
    listItems = <ListItem>[];
    for(var element in json['listItems']){
      listItems?.add(ListItem.fromJson(element));
    }
  }

  Map<String, dynamic> toMap(){
    final Map<String, dynamic> data = <String, dynamic>{};
    data['id'] = id;
    data['name'] = name;
    data['color'] = color ;
    data['isDeleted'] = isDeleted ;
    data['isCompleted'] = isCompleted ;
    data['dateCreated'] = dateCreated ;
    data['dateModified'] = dateModified;
    data['userCreatedBy'] = userCreatedBy ;
    data['userGroupId'] = userGroupId ;
    data['dateCompleted'] = dateCompleted ;
    data['listItems'] = listItems ;
    return data;
  }
}
