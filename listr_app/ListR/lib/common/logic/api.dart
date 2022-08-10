class Api{
  final String ApiBaseUrl = "http://localhost:7024/api/";
  String headerToken = "";

  static Map<String,String> headers = {
    'Content-type' : 'application/json',
    'Accept': 'application/json',
  };

  Future<bool> login(String username, String password) async {

  }
}