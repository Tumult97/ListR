class ResponseBase {
  bool success;
  String? message;
  String? body;

  ResponseBase({this.message, this.body, required this.success});
}