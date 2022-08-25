class UserModel {
  String? firstName;
  String? lastName;
  //Null? userGroups;
  String? id;
  String? userName;
  String? normalizedUserName;
  String? email;
  String? normalizedEmail;
  bool? emailConfirmed;
  String? passwordHash;
  String? securityStamp;
  String? concurrencyStamp;
  bool? phoneNumberConfirmed;
  bool? twoFactorEnabled;
  bool? lockoutEnabled;
  int? accessFailedCount;

  UserModel(
      {this.firstName,
        this.lastName,
        this.id,
        this.userName,
        this.normalizedUserName,
        this.email,
        this.normalizedEmail,
        this.emailConfirmed,
        this.passwordHash,
        this.securityStamp,
        this.concurrencyStamp,
        this.phoneNumberConfirmed,
        this.twoFactorEnabled,
        this.lockoutEnabled,
        this.accessFailedCount});

  UserModel.fromJson(Map<String, dynamic> json) {
    firstName = json['firstName'];
    lastName = json['lastName'];
    id = json['id'];
    userName = json['userName'];
    normalizedUserName = json['normalizedUserName'];
    email = json['email'];
    normalizedEmail = json['normalizedEmail'];
    emailConfirmed = json['emailConfirmed'];
    passwordHash = json['passwordHash'];
    securityStamp = json['securityStamp'];
    concurrencyStamp = json['concurrencyStamp'];
    phoneNumberConfirmed = json['phoneNumberConfirmed'];
    twoFactorEnabled = json['twoFactorEnabled'];
    lockoutEnabled = json['lockoutEnabled'];
    accessFailedCount = json['accessFailedCount'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['firstName'] = firstName;
    data['lastName'] = lastName;
    data['id'] = id;
    data['userName'] = userName;
    data['normalizedUserName'] = normalizedUserName;
    data['email'] = email;
    data['normalizedEmail'] = normalizedEmail;
    data['emailConfirmed'] = emailConfirmed;
    data['passwordHash'] = passwordHash;
    data['securityStamp'] = securityStamp;
    data['concurrencyStamp'] = concurrencyStamp;
    data['phoneNumberConfirmed'] = phoneNumberConfirmed;
    data['twoFactorEnabled'] = twoFactorEnabled;
    data['lockoutEnabled'] = lockoutEnabled;
    data['accessFailedCount'] = accessFailedCount;
    return data;
  }
}
