CREATE DATABASE IF NOT EXISTS zma_tool;

USE zma_tool;

 CREATE TABLE IF NOT EXISTS player ( 
  id int(10) NOT NULL AUTO_INCREMENT,  
  name varchar(100) DEFAULT NULL,  
  level int(10) DEFAULT NULL,
  experience int(10) DEFAULT NULL,
  seconds_online int(10) DEFAULT NULL,  
  date_last_online datetime DEFAULT NULL,  
  ip varchar(100) DEFAULT NULL,  
  port int(5) DEFAULT NULL,  
  PRIMARY KEY (id)  
  ) ENGINE=InnoDB AUTO_INCREMENT=435 DEFAULT CHARSET=latin1;

   CREATE TABLE IF NOT EXISTS blocks ( 
     id int(10) NOT NULL AUTO_INCREMENT,  
     block_id int(10) DEFAULT NULL,
     action_type int(10) DEFAULT NULL,
     player_id int(10) DEFAULT NULL,
     PRIMARY KEY (id),
     FOREIGN KEY (player_id) REFERENCES player(id)
     ) ENGINE=InnoDB AUTO_INCREMENT=435 DEFAULT CHARSET=latin1;