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
  $db = $database->Connect();

  //Instantiate post object
  $admin = new Admin($db);

  //query
  $result = $admin->GetEvents();
  //get row count
  $num = $result->rowCount();
  // Check if any result
  if($num > 0){
    $post_arr = array();
    //$post_arr['data'] = array();

    while($row = $result->fetch(PDO::FETCH_ASSOC)){
      extract($row);

      $post_item = array(
        "id" => $guests_id,
        "name" => $name,
        "type" => $type,
        "date" => $date,
        "time" => $time,
        "booker" => $booker
      );
      array_push($post_arr, $post_item);
      //array_push($post_arr['data'], $post_item);
    }
    // turn it into json
    echo json_encode($post_arr);
  }else {
    // No post
    echo "No Post Found";
  }
?>
