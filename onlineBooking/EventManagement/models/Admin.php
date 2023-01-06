<?php
class Admin
{
    private $connection;

    public $id;
    public $username;
    public $password;
    public $fullname;
    public $address;
    public $contact;
    public $email;
    public $role;
    public $status;

    function __construct($db)
    {
        $this->connection = $db;
    }

    function LoginAccount()
    {
        $query = "SELECT * FROM admin WHERE username = :username AND password = :password";

        $statement = $this->connection->prepare($query);

        $this->email = htmlspecialchars(strip_tags($this->email));
        $this->password = htmlspecialchars(strip_tags($this->password));

        $statement->bindParam(":username", $this->username);
        $statement->bindParam(":password", $this->password);
        $statement->execute();

        $row = $statement->fetch(PDO::FETCH_ASSOC);

        if ($row > 0) {
            $this->id = $row["id"];
            $this->username = $row["username"];
            $this->password = $row["password"];
            $this->fullname = $row["fullname"];
            $this->address = $row["address"];
            $this->contact = $row["contact"];
            $this->email = $row["email"];
            $this->role = $row["role"];
            $this->status = $row["status"];
        } else {
            $this->id = 0;
            $this->username = "null";
            $this->password = "null";
            $this->fullname = "null";
            $this->address = "null";
            $this->contact = "null";
            $this->email = "null";
            $this->role = "null";
            $this->status = "null";
        }

        return $statement;
    }

    public $datenow;
    function GetGuestLogs()
    {
        $query = "SELECT guest.*, events.name AS eventname FROM guest, events WHERE guest.guest_id = events.guests_id AND events.date = :date";

        $statement = $this->connection->prepare($query);
        $statement->bindParam(":date", $this->datenow);
        $statement->execute();

        return $statement;
    }

    function GetEvents()
    {
        $query = "SELECT * FROM events";

        $statement = $this->connection->prepare($query);
        $statement->execute();

        return $statement;
    }

    function GetGuests()
    {
        $query = "SELECT * FROM guest WHERE guest_id = :id";

        $statement = $this->connection->prepare($query);
        $statement->bindParam(":id", $this->id);
        $statement->execute();

        return $statement;
    }

    function GetUsers()
    {
        $query = "SELECT * FROM admin";

        $statement = $this->connection->prepare($query);
        $statement->execute();

        return $statement;
    }

    function GetPreviousEvents()
    {
        $query = "SELECT * FROM events WHERE date_format(str_to_date(date, '%m/%d/%Y'), '%Y/%m/%d')<=date_format(curdate(), '%Y/%m/%d')";
        //$query = "SELECT * FROM events WHERE date <= date_format(curdate(), '%m/%d/%Y')";

        $statement = $this->connection->prepare($query);
        $statement->execute();

        return $statement;
    }

    function DeleteGuest()
    {
        $query = "DELETE FROM guest WHERE rfid = :id";
        $statement = $this->connection->prepare($query);
        $statement->bindParam(":id", $this->id);
        if ($statement->execute()) {
            return true;
        }

        // Print error if something goes wrong
        printf("Error: %s.\n", $statement->error);

        return false;
    }

    public $rfid;
    public $name;
    function CreateGuest()
    {
        $query = "INSERT INTO Guest SET guest_id = :id, rfid = :rfid, name = :name, address =:address, email = :email, number = :number, type = 'guest'";

        $statement = $this->connection->prepare($query);

        $statement->bindParam(":id", $this->id);
        $statement->bindParam(":rfid", $this->rfid);
        $statement->bindParam(":name", $this->name);
        $statement->bindParam(":address", $this->address);
        $statement->bindParam(":email", $this->email);
        $statement->bindParam(":number", $this->contact);

        if ($statement->execute()) {
            return true;
        }
        printf("Error: %s.\n", $statement->error);
        return false;
    }

    function UpdateGuest()
    {
        $query = "UPDATE Guest SET name = :name, address =:address, email = :email, number = :number WHERE rfid = :id";

        $statement = $this->connection->prepare($query);

        $statement->bindParam(":id", $this->id);
        $statement->bindParam(":name", $this->name);
        $statement->bindParam(":address", $this->address);
        $statement->bindParam(":email", $this->email);
        $statement->bindParam(":number", $this->contact);

        if ($statement->execute()) {
            return true;
        }
        printf("Error: %s.\n", $statement->error);
        return false;
    }

    public $timenow;
    function CreateEvent()
    {
        $query = "INSERT INTO events SET name = :eventname, date = :date, time = :time, type =:type, booker = :booker";

        $statement = $this->connection->prepare($query);

        $statement->bindParam(":eventname", $this->name);
        $statement->bindParam(":date", $this->datenow);
        $statement->bindParam(":time", $this->timenow);
        $statement->bindParam(":type", $this->type);
        $statement->bindParam(":booker", $this->fullname);

        if ($statement->execute()) {
            return true;
        }
        printf("Error: %s.\n", $statement->error);
        return false;
    }

    function UpdateEvent()
    {
        $query = "UPDATE events SET name = :eventname, date = :date, time = :time, type =:type, booker = :booker WHERE guests_id = :id";

        $statement = $this->connection->prepare($query);

        $statement->bindParam(":id", $this->id);
        $statement->bindParam(":eventname", $this->name);
        $statement->bindParam(":date", $this->datenow);
        $statement->bindParam(":time", $this->timenow);
        $statement->bindParam(":type", $this->type);
        $statement->bindParam(":booker", $this->fullname);

        if ($statement->execute()) {
            return true;
        }
        printf("Error: %s.\n", $statement->error);
        return false;
    }

    function CreateAdmin()
    {
        $query = "INSERT INTO admin SET username = :username, password = :password, fullname = :fullname, address =:address, contact = :contact, email =:email, role = :role, status = :status";

        $statement = $this->connection->prepare($query);

        $statement->bindParam(":username", $this->username);
        $statement->bindParam(":password", $this->password);
        $statement->bindParam(":fullname", $this->fullname);
        $statement->bindParam(":address", $this->address);
        $statement->bindParam(":contact", $this->contact);
        $statement->bindParam(":email", $this->email);
        $statement->bindParam(":role", $this->role);
        $statement->bindParam(":status", $this->status);

        if ($statement->execute()) {
            return true;
        }
        printf("Error: %s.\n", $statement->error);
        return false;
    }

    function UpdateAdmin()
    {
        $query = "UPDATE admin SET username = :username, password = :password, fullname = :fullname, address =:address, contact = :contact, email =:email, role = :role, status = :status WHERE id = :id";

        $statement = $this->connection->prepare($query);

        $statement->bindParam(":id", $this->id);
        $statement->bindParam(":username", $this->username);
        $statement->bindParam(":password", $this->password);
        $statement->bindParam(":fullname", $this->fullname);
        $statement->bindParam(":address", $this->address);
        $statement->bindParam(":contact", $this->contact);
        $statement->bindParam(":email", $this->email);
        $statement->bindParam(":role", $this->role);
        $statement->bindParam(":status", $this->status);

        if ($statement->execute()) {
            return true;
        }
        printf("Error: %s.\n", $statement->error);
        return false;
    }

    function DeleteAdmin()
    {
        $query = "DELETE FROM admin WHERE id = :id";
        $statement = $this->connection->prepare($query);
        $statement->bindParam(":id", $this->id);
        if ($statement->execute()) {
            return true;
        }

        // Print error if something goes wrong
        printf("Error: %s.\n", $statement->error);

        return false;
    }
}
