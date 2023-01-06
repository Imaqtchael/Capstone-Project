<?php
class Database
{
    private $host = "localhost";
    private $username = "u608197321_van_";
    private $password = "~C3qt^9kZ";
    private $database = "u608197321_real_capstone";

    private $connection;

    function connect()
    {
        $this->connection = null;

        try {
            $this->connection = new PDO('mysql:host=' . $this->host . ';dbname=' . $this->database, $this->username, $this->password);
            $this->connection->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        } catch (PDOException $e) {
            echo "Connection Error: " . $e->getMessage();
        }

        return $this->connection;
    }
}
