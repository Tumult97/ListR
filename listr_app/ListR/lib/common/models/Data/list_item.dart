class ListItem
{
  int? id;
  int? listId;
  String? name;
  int? itemType;
  int? priority;
  bool? isCollected;
  double? price;

  ListItem(
      {this.id,
      this.listId,
      this.name,
      this.itemType,
      this.priority,
      this.isCollected,
      this.price});

  ListItem.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    listId = json['listId'];
    name = json['name'];
    itemType = json['itemType'];
    priority = json['priority'];
    isCollected = json['isCollected'];
    price = json['price'];
  }

  Map<String, dynamic> toMap() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['id'] = id;
    data['listId'] = listId;
    data['name'] = name;
    data['itemType'] = itemType;
    data['priority'] = priority;
    data['isCollected'] = isCollected;
    data['price'] = price;
    return data;
  }
}