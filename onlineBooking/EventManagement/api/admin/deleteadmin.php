<?php
  //control the models
  header("Access-Control-Allow-Origin: *");
  header("Content-Type: application/json");
  header("Access-Control-Allow-Methods: DELETE");
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

  //Set ID to update
  $admin->id = $data->id;

  //Delete post
  if($admin->DeleteAdmin()) {
    echo json_encode(
      array("Message" => "Post Delete")
    );
  } else {
    echo json_encode(
      array("Message" => "Post Not Delete")
    );
  }