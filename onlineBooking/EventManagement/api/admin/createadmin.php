<?php
  //control the models
  header("Access-Control-Allow-Origin: *");
  header("Content-Type: application/json");
  header("Access-Control-Allow-Methods: POST");
  header("Access-Control-Allow-Headers: Access-Control-Allow-Headers,Content-Type,Access-Control-Allow-Methods, Authorization, X-Requested-With");

  include_once "../../config/Database.php";
  include_once "../../models/Admin.php";

  //Instantiate DB & connect
  $database = new Database();
  $db = $database->connect();

  //Instantiate post object
  $admin = new Admin($db);

  // Get raw posted data
  $data = json_decode(file_get_contents("php://input"));

  $admin->username = $data->username;
  $admin->password = $data->password;
  $admin->fullname = $data->fullname;
  $admin->address = $data->address;
  $admin->contact = $data->contact;
  $admin->email = $data->email;
  $admin->role = $data->role;
  $admin->status = $data->status;

  //Create post
  if($admin->CreateAdmin()) {
    echo json_encode(
      array("Message" => "Post Created")
    );
  } else {
    echo json_encode(
      array("Message" => "Post Not Created")
    );
  }