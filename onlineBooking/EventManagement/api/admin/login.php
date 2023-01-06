<?php
//control the models
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json");
header("Access-Control-Allow-Headers: Access-Control-Allow-Headers,Content-Type,Access-Control-Allow-Methods, Authorization, X-Requested-With");

include_once "../../config/Database.php";
include_once "../../models/Admin.php";

//Instantiate DB & connect
$database = new Database();
$db = $database->connect();

//Instantiate post object
$users = new Admin($db);

//Get Username and Password
$users->username = isset($_GET['username']) ? $_GET['username'] : die();
$users->password = isset($_GET['password']) ? $_GET['password'] : die();

//Get post
$result = $users->LoginAccount();

$num = $result->rowCount();
if ($num > 0) {
    //$post_arr['data'] = array();
    $login_arr = array(
        "id" => $users->id,
        "username" => $users->username,
        "password" => $users->password,
        "fullname" => $users->fullname,
        "address" => $users->address,
        "contact" => $users->contact,
        "email" => $users->email,
        "role" => $users->role,
        "accountstatus" => $users->status,
        "status" => "Success"
    );
    echo json_encode(array($login_arr));
    //print_r(json_encode($login_arr));
} else {
    // No post
    $login_arrfailed = array(
        "id" => $users->id,
        "username" => $users->username,
        "password" => $users->password,
        "fullname" => $users->fullname,
        "address" => $users->address,
        "contact" => $users->contact,
        "email" => $users->email,
        "role" => $users->role,
        "accountstatus" => $users->status,
        "status" => "Failed"
    );
    echo json_encode(array($login_arrfailed));
}
