<?php
setcookie('eventName', null, time() - 86400, '/');
unset($_COOKIE['eventName']);
?>