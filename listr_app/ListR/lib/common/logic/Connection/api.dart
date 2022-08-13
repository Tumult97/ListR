import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:listr/common/models/Responses/response_base.dart';

class Api{
 final String apiBaseUrl = "localhost:7024";

  static const Map<String,String> headersBase = {
    'Content-type' : 'application/json',
    'Accept': 'application/json',
  };

 Future<ResponseBase> getAsync(String path, [String bearerToken = '']) async {
   ResponseBase response;

   try{
     Uri uri = Uri.http(apiBaseUrl, path);

     var headers = headersBase;
     if(bearerToken.isNotEmpty){
       Map<String,String> authHeader = {'Authorization', 'Bearer $bearerToken'} as Map<String, String>;
       headers.addAll(authHeader);
     }

     var httpResponse = await http.get(uri, headers: headers);
     response = ResponseBase(success: true, body: httpResponse.body);
   }
   catch(ex){
     response = ResponseBase(success: false, message: ex.toString());
   }

   return response;
 }

 Future<ResponseBase> postAsync(String path, dynamic body, [String bearerToken = '']) async {
   ResponseBase response;

   try{
     Uri uri = Uri.http(apiBaseUrl, 'api/$path');

     var headers = headersBase;
     if(bearerToken.isNotEmpty){
       Map<String,String> authHeader = {'Authorization', 'Bearer $bearerToken'} as Map<String, String>;
       headers.addAll(authHeader);
     }

     var jsonBody = '';
     if(body != null){
       jsonBody = json.encode(body.toMap());
     }

     var httpResponse = await http.post(uri, headers: headers, body: jsonBody);
     response = ResponseBase(success: true, body: httpResponse.body);
   }
   catch(ex){
     response = ResponseBase(success: false, message: ex.toString());
   }

   return response;
 }

 Future<ResponseBase> putAsync(String path, dynamic body, [String bearerToken = '']) async {
   ResponseBase response;

   try{
     Uri uri = Uri.http(apiBaseUrl, path);

     var headers = headersBase;
     if(bearerToken.isNotEmpty){
       Map<String,String> authHeader = {'Authorization', 'Bearer $bearerToken'} as Map<String, String>;
       headers.addAll(authHeader);
     }

     var jsonBody = '';
     if(body != null){
       jsonBody = json.encode(body);
     }

     var httpResponse = await http.put(uri, headers: headers, body: jsonBody);
     response = ResponseBase(success: true, body: httpResponse.body);
   }
   catch(ex){
     response = ResponseBase(success: false, message: ex.toString());
   }

   return response;
 }

 Future<ResponseBase> deleteAsync(String path, dynamic body, [String bearerToken = '']) async {
   ResponseBase response;

   try{
     Uri uri = Uri.http(apiBaseUrl, path);

     var headers = headersBase;
     if(bearerToken.isNotEmpty){
       Map<String,String> authHeader = {'Authorization', 'Bearer $bearerToken'} as Map<String, String>;
       headers.addAll(authHeader);
     }

     var jsonBody = '';
     if(body != null){
       jsonBody = json.encode(body);
     }

     var httpResponse = await http.delete(uri, headers: headers, body: jsonBody);
     response = ResponseBase(success: true, body: httpResponse.body);
   }
   catch(ex){
     response = ResponseBase(success: false, message: ex.toString());
   }

   return response;
 }
}