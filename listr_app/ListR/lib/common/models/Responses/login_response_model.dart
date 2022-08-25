class AuthResonseModel {
  String? token;
  String? expiration;

  AuthResonseModel({this.token, this.expiration});

  AuthResonseModel.fromJson(Map<String, dynamic> json) {
    token = json['token'];
    expiration = json['expiration'];
  }

  Map<String, dynamic> toMap() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['token'] = token;
    data['expiration'] = expiration;
    return data;
  }
}