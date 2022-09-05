class RegisterModel {
  String? username;
  String? email;
  String? firstName;
  String? lastName;
  String? password;

  RegisterModel(
      {this.username,
      this.email,
      this.firstName,
      this.lastName,
      this.password});

  RegisterModel.fromJson(Map<String, dynamic> json) {
    username = json['username'];
    email = json['email'];
    firstName = json['firstName'];
    lastName = json['lastName'];
    password = json['password'];
  }

  Map<String, dynamic> toMap() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['username'] = username;
    data['email'] = email;
    data['firstName'] = firstName;
    data['lastName'] = lastName;
    data['password'] = password;
    return data;
  }
}
